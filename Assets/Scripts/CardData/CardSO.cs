using UnityEngine;

[CreateAssetMenu(fileName = "CartScriptableOJ", menuName = "Scriptable Objects/CardsSO")]
public class CardSO : ScriptableObject
{
    public Transform prefab;
    public EnumCards.CardType cardType;
    public string cardName;
    public Sprite ingredientSprite;
    public int health;
    public int damage;
}
