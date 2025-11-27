using UnityEngine;

public class C_Hearts : BaseCard
{
    [SerializeField] private PlayerHealthManager phealthManager;

    private void Start()
    {
        CardType = this.GetComponent<BaseCard>().CardType;
        Icons = this.GetComponent<BaseCard>().Icons;
        CardName = this.GetComponent<BaseCard>().CardName;

        phealthManager = FindFirstObjectByType<PlayerHealthManager>();

    }

    public override void Interact()
    {
        phealthManager.HealDamage(new AttackInfo { attackType = AttackType.Healing, amount = CardType.damage });
        DiscardCard();
        print("I Healed");
    }
}
