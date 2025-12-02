using UnityEngine;

public class Runaway : MonoBehaviour
{
    [SerializeField] private DeckManager _deckMRef;
    [SerializeField] private HandManager _handMRef;

    
    public void SkipHand()
    {
        //La idea es regresar las cuatro cartas de la Mano de vuelta al DeckManager, y darle la opción al jugador de elegir el orden en el que serán puestas
        /*for(int i=0; i < _handMRef.cardsInHand.Count; i++)
        {
            _handMRef.cardsInHand[0]
        }*/

        foreach (CardSO cardsinHand in _handMRef.cardsInHand)
        {
            _deckMRef.shuffledList.Add(cardsinHand);
            
           // _handMRef.cardsInHand.Remove(cardsinHand);
            //_handMRef.cardsInHand.RemoveAt(0);
        }
        _handMRef.cardsInHand.Clear();
    }
}
