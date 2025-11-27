using System;
using UnityEngine;
using static EnumCards;

public class PlayerWeaponsManager : BaseSpace
{
    [SerializeField] private CardSO currentweaponCardSO;
    [SerializeField] private BaseCard currentWeaponCard;

    public void Interact(CardSO weaponCardSO)
    {
        /*
        if (currentweaponCardSO != null)
        {
            UseWeapon(weaponCardSO);
        }
        else
        {
            AddWeapon(weaponCardSO);
        }*/
    }

    public void UseWeapon()
    {
        //Here the player can Use the Weapon. Once the weapon it's Selected then It will interact with another enemy, or card. Interacting with another enemies changes them, while using another card doesnt
        print("Use esta arma");
    }

    public void AddWeapon(CardSO newWeapon)
    {
        if(currentweaponCardSO != null)
        {
            DiscardCurrentWeapon();
            SpawnCard(newWeapon);

        }
        else
        {
            SpawnCard(newWeapon);
        }
    }

    private void SpawnCard(CardSO newCard)
    {
        BaseCard.SpawnCardObject(newCard, this);
        currentWeaponCard=GetCard();
        C_Diamonds current_Diamond = currentWeaponCard.GetComponent<C_Diamonds>();
        current_Diamond.HasAPlayer = true;
        currentweaponCardSO = newCard;             
    }

    private void DiscardCurrentWeapon()
    {
        DiscardPileManager discardPManager = FindFirstObjectByType<DiscardPileManager>();
        discardPManager.listofDCards.Add(currentweaponCardSO);
        Destroy(currentWeaponCard);
    }

    
}
