using UnityEngine;
using TMPro;

public class HPVisuals : MonoBehaviour
{
    //[SerializeField] private PlayerHealthManager _healthMRef;
    [SerializeField] private TextMeshProUGUI _healthText;


    public void UpdateHealth(float currentHealth)
    {
        _healthText.text = currentHealth.ToString();
    }

}
