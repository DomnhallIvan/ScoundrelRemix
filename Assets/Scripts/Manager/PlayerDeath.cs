using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{



    public void YouAreDead()
    {
        print("YouAreDead");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
