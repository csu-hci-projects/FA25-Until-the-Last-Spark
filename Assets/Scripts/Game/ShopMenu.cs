using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    public static bool isShopOpen = false;
    public GameObject shopMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S key pressed!");
            if (isShopOpen)
            {
                closeShop();
                
            }
            else
            {
                openShop();
            }
        }
    }

    void openShop()
    {
        shopMenuUI.SetActive(true);
        Time.timeScale = 0;
        isShopOpen = true;
    }

    public void closeShop()
    {
        shopMenuUI.SetActive(false);
        Time.timeScale = 1;
        isShopOpen = false;
    }
}
