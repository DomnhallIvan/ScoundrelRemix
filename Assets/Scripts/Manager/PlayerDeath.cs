using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] LoseWinManager _LWManagerRef;


    public void YouAreDead()
    {
        _LWManagerRef.ShowEnding(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
