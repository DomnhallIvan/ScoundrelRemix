using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance { get; private set; }

    //Cada vez que se colecte una carta se llama este evento, cuando hayan suficientes entonces 
    //en RoundManager podremos pasar a la siguiente ronda de ser posible.
    [SerializeField] private Runaway runawayRef;
    public event EventHandler CardsCollected;
    public float cardsTakenCounter;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private IEnumerator Start()
    {
        //Esto es solo para retrasar por un frame GameManager y permitir que el resto de Scripts se suscriban apropiadamente antes de iniciar el juego
        yield return null;
        StartGame();
        print("Start GameManager");

    }
    
    public void StartGame()
    {
        RoundManager.Instance.NextRound();
        print("RoundManager Start");
        
    }

    public void ShouldChangeRound()
    {
        cardsTakenCounter++;
        if (cardsTakenCounter >= 3)
        {
            runawayRef.canSkip = true;
            CardsCollected?.Invoke(this, EventArgs.Empty);
            cardsTakenCounter = 0;
            // RoundManager.Instance.OnRoundEnd+=
            //roundMRef.NextRound();
        }
    }

}
