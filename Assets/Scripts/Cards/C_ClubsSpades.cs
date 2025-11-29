using UnityEngine;

public class C_ClubsSpades : BaseCard
{
    //public float damageAmount = 10f;
    public AttackType type = AttackType.Common;

    [SerializeField] private PlayerHealthManager phealthManager;

    private void Start()
    {
       CardType=this.GetComponent<BaseCard>().CardType;
       Icons=this.GetComponent<BaseCard>().Icons;
       CardName=this.GetComponent<BaseCard>().CardName;

       phealthManager=FindFirstObjectByType<PlayerHealthManager>();

    }

    public void MakeAttack(AttackInfo attackInfo)
    {
        attackInfo.owner = gameObject;

        
    }

    public override void Interact()
    {
        
        MakeAttack(new AttackInfo { attackType = AttackType.Common, amount = CardType.damage });
        phealthManager.CalculateDamage(new AttackInfo { attackType = AttackType.Common, amount = CardType.damage });

        if (!phealthManager.HasAnActiveWeapon())
        {

            
            if(this.GetCardParent() != null)
            {
                ClearCardParent();
            }
            GameManager.Instance.ShouldChangeRound();
            DiscardCard();
         
        }
        else
        {
            if (phealthManager.GetEnoughDamage(CardType.damage))
            {
                GameManager.Instance.ShouldChangeRound();
                ClearCardParent();
                DiscardCard();
             
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
