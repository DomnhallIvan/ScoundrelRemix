using System;
using UnityEngine;

public class BaseSpace : MonoBehaviour, IParentsCards
{
    [SerializeField] private Transform CardTop;

    [SerializeField] private BaseCard currentCard;

    public event EventHandler OnCardChanged;

    public virtual void Interact()
    {
        Debug.LogError("Se te olvido poner algo en tu Interact lol");
    }

    public void ClearCard()
    {
        currentCard = null;
        OnCardChanged?.Invoke(this, EventArgs.Empty);
    }

    public BaseCard GetCard()
    {
        return currentCard;
    }

    public bool HasCard()
    {
        return currentCard != null;
    }

    public void SetCard(BaseCard card)
    {
        currentCard = card;
        OnCardChanged?.Invoke(this, EventArgs.Empty);
    }
}
