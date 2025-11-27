using UnityEngine;

public enum AttackType
{
    Common,
    Special
}
public struct AttackInfo
{
    public GameObject owner;
    public AttackType attackType;
    public float amount;
}
