using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class BaseCard : MonoBehaviour
{
    public CardSO CardType;

    [SerializeField] private List<Image> Icons = new List<Image>();
    [SerializeField] private List<TextMeshProUGUI> CardName = new List<TextMeshProUGUI>();

    private IParentsCards cardParent;

    public virtual void Interact()
    {
        print("Falta una interacción");

        DiscardCard();
       

    }

    public CardSO GetCardSO()
    {
        return CardType;
    }

    public void SetCardObjectParent(IParentsCards cardsParents)
    {
        if(this.cardParent != null)
        {
            this.cardParent.ClearCardObject();
        }

        this.cardParent = cardsParents;

        if (cardsParents.HasCard())
        {
            Debug.LogError("ICardParent already has a CardParent!");
        }

        cardsParents.SetCardObject(this);

        transform.parent = cardsParents.GetCardObjectFollowTransform();
        transform.localPosition = Vector3.zero;
        transform.localRotation=Quaternion.identity;

        
    }

    public IParentsCards GetCardParent()
    {
        return cardParent;
    }

    public void DestroySelf()
    {
        if (cardParent != null)
        {
            cardParent.ClearCardObject();
        }
        Destroy(gameObject);
    }

    /*
    public bool TryGetWeaponSpace(out PlayerWeaponsManager weaponSpace)
    {
        if(this is  PlayerWeaponsManager)
        {
            weaponSpace = this as PlayerWeaponsManager;
            return true;
        }
        else
        {
            weaponSpace = null;
            return false;
        }
    }*/

    public static BaseCard SpawnCardObject(CardSO cardSO, IParentsCards ICardParent)
    {
        Transform cardObjectTransform = Instantiate(cardSO.prefab);
        BaseCard cardObject= cardObjectTransform.GetComponent<BaseCard>();

        if(ICardParent != null)
        {
            cardObject.SetCardObjectParent(ICardParent);
        }

        return cardObject;
    }

    public void ReplaceWithIngredient(CardSO newCardSO)
    {
        if (newCardSO == null)
        {
            Debug.LogError("El nuevo cardSO no es válido.");
            return;
        }

        Vector3 originalPosition = transform.position;

        // Desemparentar el ingrediente original
        transform.SetParent(null);
        // Debug.Log($"su parent es {cardSO}");

        // Instanciar el nuevo ingrediente en la misma posición
        BaseCard newCard = SpawnCardObject(newCardSO, null);
        newCard.transform.position = originalPosition; // Asegura que el nuevo ingrediente aparezca en el mismo lugar

        cardParent.ClearCardObject();
        Destroy(gameObject);

    }

    public void DiscardCard()
    {
        DiscardPileManager discardPManager = FindFirstObjectByType<DiscardPileManager>();
        discardPManager.listofDCards.Add(CardType);
        DestroySelf();
    }
}
