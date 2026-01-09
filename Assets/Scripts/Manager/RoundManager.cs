using UnityEngine;
using System;

public class RoundManager : MonoBehaviour
{
    public static RoundManager Instance { get; private set; }

    //RoundManager should Change Rounds when there's 1 card left to pick from
   // [SerializeField] private DeckManager deckMRef;

    public event EventHandler OnRoundEnd;

    [SerializeField] private int roundNumber = 0;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        GameManager.Instance.CardsCollected += StartNextRound;
    }

    private void StartNextRound(object sender,EventArgs e)
    {
        NextRound();

    }

    public void NextRound()
    {
        
        roundNumber++;
        //deckMRef.ShuffleDeck();

        //Cuando recolecte 3 cartas entonces se debería de llamar este evento.
        //Puede ser para actualizar UI, o algún efecto como poner nuevas cartas
        OnRoundEnd?.Invoke(this, EventArgs.Empty);


    }

    public int GetRoundNumber()
    {
        return roundNumber;
    }

  
}
