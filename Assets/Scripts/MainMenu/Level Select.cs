using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;

    public void onLevel1Button()
    {
        SceneManager.LoadScene(1);
    }

    public void onLevel2Button()
    {
        SceneManager.LoadScene(4);
    }

    public void onMainMenuButton()
    {
        this.gameObject.SetActive(false);
        mainMenu.SetActive(true);
    }
}
