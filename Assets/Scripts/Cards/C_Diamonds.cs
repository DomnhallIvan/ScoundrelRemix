using UnityEngine;

public class C_Diamonds : BaseCard
{
    //Los Diamantes son las armas de los jugadores. Irán del 1-10
    //La idea es que cuando las uses en vez de tomar el daño completo de una carta, usas el daño de tu arma para protegerte
    //y solo tomas el restante del daño.




    public override void  Interact()
    {
        FindFirstObjectByType<PlayerWeaponsManager>().AddWeapon(GetCardSO());

        DiscardCard();
    }
}
