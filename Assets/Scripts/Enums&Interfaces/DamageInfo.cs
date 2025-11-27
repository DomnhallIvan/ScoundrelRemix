using UnityEngine;

public enum AttackType
{
    Common,
    Special,
    Healing
}
public struct AttackInfo
{
    public GameObject owner;
    public AttackType attackType;
    public float amount;
}
