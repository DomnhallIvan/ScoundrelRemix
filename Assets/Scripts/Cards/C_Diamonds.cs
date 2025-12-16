using UnityEngine;
using UnityEngine.UI;

public class C_Diamonds : BaseCard
{
    //Los Diamantes son las armas de los jugadores. Irán del 1-10
    //La idea es que cuando las uses en vez de tomar el daño completo de una carta, usas el daño de tu arma para protegerte
    //y solo tomas el restante del daño.
    public bool hasAPlayer;
    [SerializeField] private Material[] materialList;
    [SerializeField] private Image[] spriteRenderer;

    [SerializeField] private float damageLimit;

    private void Start()
    {
        damageLimit = float.MaxValue;
        ChangeMaterial(false);

    }

    public override void  Interact()
    {

       // bool HasCardPlayerParent= GetCardParent().GetPlayerWeaponsManager();
        //A como esta solo genera un bug ya que jamás se pone el booleano al momento de spawnearlo lo que por default destruye el arma y evita que otra se vuelva a crear. Probablemente cambiar cómo detectar si el jugador ya tiene esa arma.
        if(!hasAPlayer)
        {
            FindFirstObjectByType<PlayerWeaponsManager>().AddWeapon(GetCardSO());
              
            
            DiscardCard();
            
            //Podría hacer esto un delegate mejor y así evitar referencias
           // GameManager.Instance.ShouldChangeRound();

        }
        else
        {
            FindFirstObjectByType<PlayerWeaponsManager>().UseWeapon();
        }
 

    }

    public void ChangeMaterial(bool isActive)
    {
        if (!isActive)
        {
            spriteRenderer[0].material = materialList[0];
            spriteRenderer[1].material = materialList[1];
        }
           
        else
        {
            spriteRenderer[0].material = materialList[2];
            spriteRenderer[1].material = materialList[3];
        }

    }

    public void SetDamageLimit(float newDamageLimit)
    {
        damageLimit= newDamageLimit;
    }

    public float GetDamageLimit() { return damageLimit; }

    public bool GetPlayer()    { return hasAPlayer;   }


    public void SetHasAplayer(bool Yes)
    {
        hasAPlayer = Yes;
    }

    
}
