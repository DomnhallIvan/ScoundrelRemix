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

    private void UseWeapon()
    {
        throw new NotImplementedException();
    }

    public void AddWeapon(CardSO newWeapon)
    {
        if(currentweaponCardSO != null)
        {
            DiscardPileManager discardPManager = FindFirstObjectByType<DiscardPileManager>();
            discardPManager.listofDCards.Add(currentweaponCardSO);
            Destroy(currentWeaponCard);
            currentweaponCardSO = newWeapon;
            currentWeaponCard = newWeapon.prefab.GetComponent<BaseCard>();
        }
        else
        {           
            BaseCard.SpawnCardObject(newWeapon, this);
            currentweaponCardSO = newWeapon;
            currentWeaponCard = newWeapon.prefab.GetComponent<BaseCard>();
        }
    }
    
}
