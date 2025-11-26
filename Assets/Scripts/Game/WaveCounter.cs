using UnityEngine;
using TMPro;

public class WaveCounter : MonoBehaviour
{
    public TMP_Text txt;

    private void Start()
    {
        txt = GetComponent<TMP_Text>(); //Get a reference to the TMP_Text component
    }

    public void Update()
    {
        txt.text = "Wave " + GameLoopManager.wave; //Update the text to show current money
    }

    public void startWave()
    {
        GameLoopManager.wave++;
    }
}
