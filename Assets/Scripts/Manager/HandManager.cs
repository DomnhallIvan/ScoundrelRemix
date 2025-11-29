using NUnit.Framework;
using UnityEngine;
using System;
using System.Collections.Generic;

public class HandManager : MonoBehaviour
{
   // public GameObject cardPrefab;

    public List<BaseSpace> handSpaces=new List<BaseSpace>();

    public float fanSpread = 5f;

    public List<GameObject> cardsInHand=new List<GameObject>();

    private void Start()
    {
        //AddCardToHand();
    }

    public void AddCardTo1Space( CardSO cardSO, BaseSpace spaceHand)
    {

        if(!spaceHand.HasCard())
            BaseCard.SpawnCardObject(cardSO, spaceHand);
           
            
           // GameObject card = Instantiate(cardSO.prefab, handTransform[i].transform.position, Quaternion.identity, handTransform[i]);
           // cardsInHand.Add(card);
        
        //GameObject card = Instantiate(cardPrefab,handTransform.position,Quaternion.identity,handTransform);
        //cardsInHand.Add(card);

        // UpdateHandVisuals();
    }

    private void UpdateHandVisuals()
    {
        int cardCount=cardsInHand.Count;

        for(int i=0;i<cardCount;i++)
        {
            float rotationAngle = (fanSpread * (i - (cardCount - 1) / 2));
            cardsInHand[i].transform.localRotation=Quaternion.Euler(0f,0f,rotationAngle);
        }
    }
}
