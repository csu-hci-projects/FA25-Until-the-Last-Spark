using UnityEngine;
using TMPro;

public class HealthCounter : MonoBehaviour
{
    public TMP_Text txt;

    private void Start()
    {
        txt = GetComponent<TMP_Text>(); //Get a reference to the TMP_Text component
    }

    public void Update()
    {
        txt.text = "HP " + GameLoopManager.health; //Update the text to show current money
    }
}
