using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{

    public bool endLoop;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    IEnumerator GameLoop() {
        while (endLoop == false) {
            //Spawn Enemies

            // Spawn Towers

            //Move Enemies

            //Tick Towers

            //Apply Effects

            //Damage Enemies

            //Remove Enemies

            //Remove Towers

            yield return null;
        }
    }
}
