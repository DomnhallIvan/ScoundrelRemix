using System;
using UnityEngine;

public class C_ClubsSpades : BaseCard
{
    //public float damageAmount = 10f;
    public AttackType type = AttackType.Common;

    [SerializeField] private PlayerHealthManager phealthManager;


    private void Start()
    {

        runRef = FindFirstObjectByType<Runaway>();
        phealthManager = FindFirstObjectByType<PlayerHealthManager>();
        //
    }

    public void MakeAttack(AttackInfo attackInfo)
    {
        attackInfo.owner = gameObject;

        
    }

    public override void Interact()
    {
        //OnCardPicked?.Invoke(this, EventArgs.Empty);
        runRef.canSkip = false;

        MakeAttack(new AttackInfo { attackType = AttackType.Common, amount = CardType.damage });
        phealthManager.CalculateDamage(new AttackInfo { attackType = AttackType.Common, amount = CardType.damage });

        if (!phealthManager.HasAnActiveWeapon())
        {
            //transform.SetParent(null);
            DiscardCard();
            //Podría hacer esto un delegate mejor y así evitar referencias
           // GameManager.Instance.ShouldChangeRound();


        }
        else
        {
            if (phealthManager.CanDefendDamage(CardType.damage))
            {

              //  transform.SetParent(null);
                DiscardCard();
                //Podría hacer esto un delegate mejor y así evitar referencias
               // GameManager.Instance.ShouldChangeRound();

            }
            else
            {
                //Aquí debería de mostrar como algo que te diga que no puedes hacer eso
                print("Elige otra opción toneto");
            }
        }
          
        
    }

    public void Debuggin(string debugtext)
    {
        Debug.Log(debugtext);
    }
}
