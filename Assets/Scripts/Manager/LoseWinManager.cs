using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseWinManager : MonoBehaviour
{
    //Manager for the Canvas if you lose or win
    //También se encarga de que los botones tengan la función para reiniciar la escena o cambiar de escena
    [SerializeField] GameObject Canvas;
    [SerializeField] TextMeshProUGUI defaultText;

    public void ShowEnding(bool win)
    {
        if (!win)
        {
            Canvas.SetActive(true);
            defaultText.SetText("YOU LOST COWARD!!!");
        }
        else
        {
            Canvas.SetActive(true);
            defaultText.SetText("YOU WIN SMART-WITZ!!!");
        }
    }

    public void RestartCurrentScene()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

   
}
