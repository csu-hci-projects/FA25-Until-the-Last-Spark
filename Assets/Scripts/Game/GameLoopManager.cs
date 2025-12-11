using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoopManager : MonoBehaviour
{
    public static int money = 20; // Starting money
    public static int health = 10;
    public static int wave = 0;
    public bool endLoop;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        money = 20;
        health = 10;
        wave = 0;
    }

    void Update()
    {
        if (health < 1)
        {
            SceneManager.LoadScene(2); //Game Over Scene
        }
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
