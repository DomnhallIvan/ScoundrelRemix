using UnityEngine;

public class C_Hearts : BaseCard
{
    [SerializeField] private PlayerHealthManager phealthManager;

    private void Start()
    {

        runRef = FindFirstObjectByType<Runaway>();

        phealthManager = FindFirstObjectByType<PlayerHealthManager>();

    }

    public override void Interact()
    {
        runRef.canSkip = false;
        phealthManager.HealDamage(new AttackInfo { attackType = AttackType.Healing, amount = CardType.damage });
        // this.GetCardParent().ClearCardObject();

        
        DiscardCard();
        //GameManager.Instance.ShouldChangeRound();

    }
}
