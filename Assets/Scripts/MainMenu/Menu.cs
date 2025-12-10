using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject levelSelectMenu;
    void Start() 
    {
        this.gameObject.SetActive(true);
        levelSelectMenu.SetActive(false);
    }
    
    public void OnPlayButton ()
    {
        this.gameObject.SetActive(false);
        levelSelectMenu.SetActive(true);
    }

    public void OnQuitButton ()
    {
        Application.Quit();
    }
}
