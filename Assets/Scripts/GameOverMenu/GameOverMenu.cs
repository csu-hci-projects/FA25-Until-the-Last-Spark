using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void OnPlayButton ()
    {
        SceneManager.LoadScene(0);
    }
}
