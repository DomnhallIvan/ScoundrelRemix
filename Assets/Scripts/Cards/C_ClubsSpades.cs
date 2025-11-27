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

        //AttackSystem.Instance?.MakeAttack(attackInfo);
    }

    public override void Interact()
    {
        MakeAttack(new AttackInfo { attackType = AttackType.Common, amount = CardType.damage });
    }

    public void Debuggin(string debugtext)
    {
        Debug.Log(debugtext);
    }
}
