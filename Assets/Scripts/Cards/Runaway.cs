using UnityEngine;

public class Runaway : MonoBehaviour
{
    [SerializeField] private DeckManager _deckMRef;
    [SerializeField] private HandManager _handMRef;

    public bool canSkip=true;
    
    //Este va a escuchar un Delegate que todas las cartas básicas pueden llamar



    public void SkipHand()
    {
        //La idea es regresar las cuatro cartas de la Mano de vuelta al DeckManager, y darle la opción al jugador de elegir el orden en el que serán puestas
        /*for(int i=0; i < _handMRef.cardsInHand.Count; i++)
        {
            _handMRef.cardsInHand[0]
        }*/

        //Falta mandar un delegate que le diga a Runaway que si el jugador toma una carta entonces no podrá skipear
        if(canSkip)
        {
            canSkip = false;

            foreach (BaseSpace cardinSpace in _handMRef.handSpaces)
            {
                cardinSpace.GetCard().ReturnCardtoDeck();
                RoundManager.Instance.NextRound();
            }
        }
    }

}
