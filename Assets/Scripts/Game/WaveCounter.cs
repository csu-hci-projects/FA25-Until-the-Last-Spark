using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class WaveCounter : MonoBehaviour
{
    public TMP_Text txt;
    [SerializeField] public Button startWaveButton;

    private void Start()
    {
        txt = GetComponent<TMP_Text>(); //Get a reference to the TMP_Text component
    }

    public void Update()
    {
        txt.text = "Wave " + GameLoopManager.wave; //Update the text to show current money
        if (SpawnEnemy.activeWave)
        {
            startWaveButton.interactable = false;
        }
        if (SpawnEnemy.activeWave == false)
        {
            startWaveButton.interactable = true;
        }

    }

    public void startWave()
    {
        GameLoopManager.wave++;
    }
}
