using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] private float _health = 20f;
    [SerializeField] private float _maxHealth = 20f;
    [SerializeField] private PlayerWeaponsManager _weaponsManagerRef;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void CalculateDamage(AttackInfo attack)
    {
        //Podría poner que pasen diferentes efectos dependiendo del tipo de daño
        //Ejemplo if(attack.attackType=Magical)
        //Efecto de magia o algo así

        if (!HasAnActiveWeapon())
        {
            TakeDamage(attack);
        }
        else
        {
            if (GetEnoughDamage(attack.amount))
            {
                _weaponsManagerRef.activateWeapon = false;
                var DiamondCard = _weaponsManagerRef.GetCard().GetComponent<C_Diamonds>();
                DiamondCard.SetDamageLimit(attack.amount);
                //Hace el calculo total del daño 
                float weaponDamage = _weaponsManagerRef.GetCardDamage();
                float totaldamage = attack.amount - weaponDamage;

                if (totaldamage >= 0) //Si el daño es mayor o igual a 0 entonces procede con el cálculo del daño.
                {
                    TakeDamage(attack);
                }
            }
            else
            {
                //You Can't Attack
                print("You Cant Attack this");
            }
        }
    }

    public void TakeDamage(AttackInfo attack)
    {
        _health -= attack.amount;
        if (_health <= 0)
        {
            YouAreDead();
        }

    }

    public void HealDamage(AttackInfo attack)
    {
        float newHealth=_health+attack.amount;
        

        if(!(newHealth >= _maxHealth)) 
        {
            _health += attack.amount;
        }
        else
        {
            _health = _maxHealth;
        }
    }

    public void YouAreDead()
    {
        //You are Dead
        if (TryGetComponent<PlayerDeath>(out var playerDeath))
        {
            playerDeath.YouAreDead();
        }
    }

    public bool GetEnoughDamage(float attackAmount)
    {
        float currentweaponLimit = _weaponsManagerRef.GetDiamondCard().GetDamageLimit();
        if (currentweaponLimit >= attackAmount)
            return true;
        else
            return false;
    }

    public bool HasAnActiveWeapon()
    {
        if (_weaponsManagerRef.activateWeapon) 
            return true;
        else
            return false;
    }
}
