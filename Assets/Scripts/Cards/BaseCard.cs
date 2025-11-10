using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class BaseCard : MonoBehaviour
{
    public CardSO CardType;

    [SerializeField] private List<Image> Icons = new List<Image>();
    [SerializeField] private List<TextMeshProUGUI> CardName = new List<TextMeshProUGUI>();
   
}
