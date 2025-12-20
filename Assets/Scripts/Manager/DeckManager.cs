using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System;

public class DeckManager : MonoBehaviour
{
    [SerializeField] private List<CardSO> cards = new List<CardSO>();
    public List<CardSO> shuffledList = new List<CardSO>();

    [SerializeField] private HandManager handManagerRef;
    [SerializeField] LoseWinManager _LWManagerRef;

    private void Awake()
    {
        RoundManager.Instance.OnRoundEnd += StartShuffling;
    }

    private void Start()
    {
        // ShuffleDeck();
        //NewShuffle();
        
    }

    private void StartShuffling(object sender, EventArgs e)
    {
        if (RoundManager.Instance.GetRoundNumber() == 1)
        {
            ShuffleDeck();
        }
        else
        {
            AddHandCard();
        }
    }

    public void ShuffleDeck()
    {

        shuffledList = cards.OrderBy(x => UnityEngine.Random.value).ToList();

        AddHandCard();
    }

    public void AddHandCard()
    {
        foreach (BaseSpace space in handManagerRef.handSpaces)
        {
            if (shuffledList.Count <= 3)
            {

                _LWManagerRef.ShowEnding(true);
                //YOU WIN FUNCTION Podría llamar un delegado para así saber que ya se acabó.
                break;
            }

            else if (!space.HasCard())
            {
                var card = shuffledList[0];
                handManagerRef.AddCardTo1Space(card, space);
                shuffledList.RemoveAt(0);
            }
        }

    }
}

