using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //GameManager se encarga de detectar cuando hay suficientes cartas para pasar a la siguiente ronda.
    //También se encarga de que al pasar a la siguiente ronda reseteé la opción de huir a la siguiente ronda
    public static GameManager Instance { get; private set; }

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
