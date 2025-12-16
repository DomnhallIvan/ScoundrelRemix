using System;
using UnityEngine;
using static EnumCards;

public class PlayerWeaponsManager : BaseSpace
{
    [SerializeField] private CardSO currentweaponCardSO;
    [SerializeField] private BaseCard currentWeaponCard;

    [SerializeField] private PlayerHealthManager playerHealthRef;
    [SerializeField] private VisualWeapon _visualWRef;
    public bool activateWeapon;

    public void UseWeapon()
    {

        //Here the player can Use the Weapon. Once the weapon it's Selected then It will interact with another enemy, or card. Interacting with another enemies changes them, while using another card doesnt
        //El siguiente daño que tome el jugador tendrá que restarle primero el daño de esta arma al daño que debería de recibir.

        //Falta implementar checar que en caso de que ya haya sido utilizada un arma, entonces  que tenga un valor igual o meno
       // print("Use esta arma");
        if (!activateWeapon)
        {
            activateWeapon = true;
           ActivateWeaponVisual();
        }
      
        else
        {
            activateWeapon = false;
            ActivateWeaponVisual();
            _visualWRef.ActiveWeapon(activateWeapon);
        }
          

    } 

    //Se añade una nueva arma
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
        
    public float GetCardDamage()
    {
        return GetCard().GetCardSO().damage;
    }

    public C_Diamonds GetDiamondCard()
    {
        return GetCard().GetComponent<C_Diamonds>();
    }
    //Maneja la lógica de añadir una nueva arma
    private void SpawnCard(CardSO newCard)
    {
        BaseCard.SpawnCardObject(newCard, this);
        currentWeaponCard=GetCard();
        C_Diamonds current_Diamond = currentWeaponCard.GetComponent<C_Diamonds>();
        current_Diamond.hasAPlayer = true;
        currentweaponCardSO = newCard;
       // Material NewDiamondMaterial=current_Diamond.GetComponent<Material>();

    }

    private void DiscardCurrentWeapon()
    {
        DiscardPileManager discardPManager = FindFirstObjectByType<DiscardPileManager>();
        discardPManager.listofDCards.Add(currentweaponCardSO);
        Destroy(currentWeaponCard);
    }


    public void ActivateWeaponVisual()
    {
        C_Diamonds current_Diamond = currentWeaponCard.GetComponent<C_Diamonds>();
        current_Diamond.ChangeMaterial(activateWeapon);
    }
    
}
