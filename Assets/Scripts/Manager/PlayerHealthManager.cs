using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] private float _health = 20f;
    [SerializeField] private float _maxHealth = 20f;
    [SerializeField] private PlayerWeaponsManager _weaponsManagerRef;
    [SerializeField] private HPVisuals _HPVisual;

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
            TakeDamage(attack.amount);
        }
        else
        {
            if (CanDefendDamage(attack.amount))
            {
                _weaponsManagerRef.activateWeapon = false;
                var DiamondCard = _weaponsManagerRef.GetCard().GetComponent<C_Diamonds>();
                DiamondCard.SetDamageLimit(attack.amount);
                DiamondCard.ChangeMaterial(false);
                //Hace el calculo total del daño 
                float weaponDamage = _weaponsManagerRef.GetCardDamage();
                float totaldamage = attack.amount - weaponDamage;

                if (totaldamage >= 0) //Si el daño es mayor o igual a 0 entonces procede con el cálculo del daño Para evitar que daño negativo cure al jugador.
                {
                    TakeDamage(totaldamage);
                }
            }
            else
            {
                //You Can't Attack
                print("You Cant Attack this");
            }
        }
    }

    public void TakeDamage(float attack)
    {
        _health -= attack;
        _HPVisual.UpdateHealth(_health);
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
            _HPVisual.UpdateHealth(_health);
        }
        else
        {
            _health = _maxHealth;
            _HPVisual.UpdateHealth(_health);
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

    public bool CanDefendDamage(float attackAmount)
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
