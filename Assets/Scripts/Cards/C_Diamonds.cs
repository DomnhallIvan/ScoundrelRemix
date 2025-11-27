using UnityEngine;

public class C_Diamonds : BaseCard
{
    //Los Diamantes son las armas de los jugadores. Irán del 1-10
    //La idea es que cuando las uses en vez de tomar el daño completo de una carta, usas el daño de tu arma para protegerte
    //y solo tomas el restante del daño.
    public bool HasAPlayer;

    public override void  Interact()
    {

       // bool HasCardPlayerParent= GetCardParent().GetPlayerWeaponsManager();
        //A como esta solo genera un bug ya que jamás se pone el booleano al momento de spawnearlo lo que por default destruye el arma y evita que otra se vuelva a crear. Probablemente cambiar cómo detectar si el jugador ya tiene esa arma.
        if(!HasAPlayer)
        {
            FindFirstObjectByType<PlayerWeaponsManager>().AddWeapon(GetCardSO());

            DiscardCard();
            print("No tiene Papy con PlayerWeaponsManager");
        }
        else
        {
            FindFirstObjectByType<PlayerWeaponsManager>().UseWeapon();
        }
 

    }

    public bool GetPlayer()
    {
        return HasAPlayer;
    }

    public void SetHasAplayer(bool Yes)
    {
        HasAPlayer = Yes;
    }
}
