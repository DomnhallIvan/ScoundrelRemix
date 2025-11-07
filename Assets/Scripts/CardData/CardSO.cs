using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CartScriptableOJ", menuName = "Scriptable Objects/CardsSO")]
public class CardSO : ScriptableObject
{
    public Transform prefab;
    public List<EnumCards.CardType> cardType;
    public string cardName;
    public Sprite ingredientSprite;
    public int health;
    public int damage;
}
