using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

public class DeckManager : MonoBehaviour
{
    [SerializeField] private List<CardSO> cards = new List<CardSO>();
    [SerializeField] private List<CardSO> shuffledList = new List<CardSO>();

    [SerializeField] private HandManager handManagerRef;


    private void Start()
    {
        ShuffleDeck();
        //NewShuffle();
       
    }

    private void ShuffleDeck()
    {
        shuffledList = cards.OrderBy(x => Random.value).ToList();

        AddHandCard();
    }

    public void AddHandCard()
    {
        int spacesCount = handManagerRef.handSpaces.Count;

        for(int i=0;i<spacesCount&&i<shuffledList.Count;i++)
        {
            var card = shuffledList[0];
            handManagerRef.AddCardTo1Hand(card, handManagerRef.handSpaces[i]);
            shuffledList.RemoveAt(0);
        }
        /*
        var shuffledListCount = shuffledList.Count;
        for (int i = 0; i < shuffledListCount; i++)
        {

            int handManagerSpaces = handManagerRef.handSpaces.Count;
            for (int u = 0; u < handManagerSpaces; u++)
            {


                handManagerRef.AddCardTo1Hand(shuffledList[i], handManagerRef.handSpaces[u]);
               //shuffledList.Remove(shuffledList[i]);


            }

        }*/
        
    }
}

