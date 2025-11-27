using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] private float _health = 20f;



    public void TakeDamage(AttackInfo attack)
    {
        //Podría poner que pasen diferentes efectos dependiendo del tipo de daño
        //Ejemplo if(attack.attackType=Magical)
        //Efecto de magia o algo así
        _health -= attack.amount;
        if (_health <= 0)
        {
            YouAreDead();


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
