using UnityEngine;

public class ShopMenu : MonoBehaviour
{

    public static bool isShopOpen = false;
    public static bool boughtTower = false;

    public int towerType = 0; // 0 = towerPrefab0, 1 = towerPrefab1, 2 = towerPrefab2
    public GameObject shopMenuUI;

    [SerializeField] int placeObjectCamerOffset = 30;
    [SerializeField] GameObject[] towerPrefab;




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

        if (boughtTower && Input.GetMouseButtonDown(0))
        {
            Debug.Log("In buy mode, click to place tower.");
           
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = placeObjectCamerOffset; // Set this to be the distance from the camera to the object you want to place
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            switch (towerType) //Can add more tower types here as needed
            {
                case 0: 
                    Instantiate(towerPrefab[0], worldPos, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(towerPrefab[1], worldPos, Quaternion.identity);
                    break;
                default:
                    Debug.LogWarning("Invalid tower type selected!");
                    break;
            }
            boughtTower = false;   
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

    public void buyTower1()
    {
        Debug.Log("Tower Purchased!");
        closeShop();
        towerType = 0;
        boughtTower = true;
    }

    public void buyTower2()
    {
        Debug.Log("Tower Purchased!");
        closeShop();
        towerType = 1;
        boughtTower = true;
    }

}
