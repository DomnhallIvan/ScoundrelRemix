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

    public void TakeDamage(AttackInfo attack)
    {
        //Podría poner que pasen diferentes efectos dependiendo del tipo de daño
        //Ejemplo if(attack.attackType=Magical)
        //Efecto de magia o algo así

        if (!_weaponsManagerRef.activateWeapon)
        {
            _health -= attack.amount;
            if (_health <= 0)
            {
                YouAreDead();
            }
        }
        else
        {
            _weaponsManagerRef.activateWeapon = false;
            float weaponDamage= _weaponsManagerRef.GetCard().GetCardSO().damage;
            float totaldamage = attack.amount - weaponDamage;
            if (totaldamage >= 0) //Si el daño es mayor o igual a 0 entonces procede con el cálculo del daño.
            {
                _health -= totaldamage;
                //Falta especificar a qué tipo de cartas puede defender un arma
                if (_health <= 0)
                {
                    YouAreDead();
                }
            }
            
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
}
