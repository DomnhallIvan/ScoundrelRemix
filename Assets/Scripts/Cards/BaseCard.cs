using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System;

public class BaseCard : MonoBehaviour
{
    public CardSO CardType;

    public List<Image> Icons = new List<Image>();
    public List<TextMeshProUGUI> CardName = new List<TextMeshProUGUI>();
    public Runaway runRef;

    private IParentsCards cardParent;

    public event EventHandler OnCardPicked;

    private void Start()
    {
        runRef = FindFirstObjectByType<Runaway>();
    }

    public virtual void Interact()
    {
        //Aquí se debería de llamar el evento de OnCardPicked
        OnCardPicked?.Invoke(this, EventArgs.Empty);
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

    public void SetCardPlayerWeapon(PlayerWeaponsManager manager)
    {
        //this.cardParent.GetPlayerWeaponsManager()=manager;
    }

    public IParentsCards GetCardParent()
    {
        return cardParent;
    }

    public void ClearCardParent()
    {
        cardParent.ClearCardObject();
    }



    public void DestroySelf()
    {
        if (cardParent != null)
        {
            cardParent.ClearCardObject();
           // GameManager.Instance.ShouldChangeRound();
        }
       
        Destroy(gameObject);

        
    }

    public void DiscardCard()
    {
        HandManager handManager = FindFirstObjectByType<HandManager>();
        handManager.cardsInHand.Remove(CardType);
        DiscardPileManager discardPManager = FindFirstObjectByType<DiscardPileManager>();
        discardPManager.listofDCards.Add(CardType);
       
        DestroySelf();
        GameManager.Instance.ShouldChangeRound();

    }

    public void ReturnCardtoDeck()
    {
        HandManager handRef = FindFirstObjectByType<HandManager>();
        handRef.cardsInHand.Remove(CardType);
        DeckManager deckRef = FindFirstObjectByType<DeckManager>();
        deckRef.shuffledList.Add(CardType);
        DestroySelf();
    }

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

    public void ReplaceWithCard(CardSO newCardSO)
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

}
