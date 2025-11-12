using UnityEngine;

public interface IParentsCards
{
    public Transform GetCardObjectFollowTransform();
    public BaseCard GetCard(); //Esto es para los espacios donde irán las cartas

    public void SetCardObject(BaseCard card); //Esto es para saber que tipo de cartas estarán

    public void ClearCardObject(); //Esto es para quitar una carta de un lugar

    public bool HasCard(); //Esto es para verificar que no tenga ya una carta
}
