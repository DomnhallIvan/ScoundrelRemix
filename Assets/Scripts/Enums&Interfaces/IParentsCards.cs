using UnityEngine;

public interface IParentsCards
{
    public BaseCard GetCard(); //Esto es para los espacios donde irán las cartas

    public void SetCard(BaseCard card); //Esto es para saber que tipo de cartas estarán

    public void ClearCard(); //Esto es para quitar una carta de un lugar

    public bool HasCard(); //Esto es para verificar que no tenga ya una carta
}
