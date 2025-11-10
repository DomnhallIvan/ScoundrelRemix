using NUnit.Framework;
using UnityEngine;
using System;
using System.Collections.Generic;

public class HandManager : MonoBehaviour
{
    public GameObject cardPrefab;

    public List<Transform> handTransform=new List<Transform>();

    public float fanSpread = 5f;

    public List<GameObject> cardsInHand=new List<GameObject>();

    private void Start()
    {
        AddCardToHand();
    }

    public void AddCardToHand()
    {
        int handTransforms=handTransform.Count;
        for(int i=0;i< handTransforms;i++)
        {
            GameObject card = Instantiate(cardPrefab, handTransform[i].transform.position, Quaternion.identity, handTransform[i]);
            cardsInHand.Add(card);
        }
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
