using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Coded by Mark Beveridge - CGDP Year 1
/// </summary>
public class HealthBar : MonoBehaviour
{
    [Header(" UI Life Images")]
    [SerializeField] private GameObject life1, life2, life3, life4, life5; //allows objects to be assigned in unity for the lives UI display
    private int lives;
    [SerializeField] private PlayerStatus playerStatus; //allows reference to the playerStatus script

   
    void Start() //sets the local variable to the value stored in playerLives
    {
        lives = PlayerPrefs.GetInt("playerLives");
    }

    void Update()
    {
        lives = PlayerPrefs.GetInt("playerLives"); //updates the playerLives variable
        if (lives > 5)
            lives = 5; //ensures that a value beyond the lives max is considered to be 5 max for the purposes of the switch statement
        if (lives < 0)
            lives = 0; //ensures that a value below the lives min is considered to be 0 min for the purposes of the switch statement

        switch (lives)
        {
            case 5: //displays all 5 lives
                life5.SetActive(true);
                life4.SetActive(true);
                life3.SetActive(true);
                life2.SetActive(true);
                life1.SetActive(true);
                break;

            case 4: //displays first 4 lives
                life5.SetActive(false);
                life4.SetActive(true);
                life3.SetActive(true);
                life2.SetActive(true);
                life1.SetActive(true);
                break;

            case 3://displays first 3 lives
                life5.SetActive(false);
                life4.SetActive(false);
                life3.SetActive(true);
                life2.SetActive(true);
                life1.SetActive(true);
                break;

            case 2://displays first 2 lives
                life5.SetActive(false);
                life4.SetActive(false);
                life3.SetActive(false);
                life2.SetActive(true);
                life1.SetActive(true);
                break;

            case 1: //displays first life only
                life5.SetActive(false);
                life4.SetActive(false);
                life3.SetActive(false);
                life2.SetActive(false);
                life1.SetActive(true);
                break;

            case 0: //displays no lives
                life5.SetActive(false);
                life4.SetActive(false);
                life3.SetActive(false);
                life2.SetActive(false);
                life1.SetActive(false);
                playerStatus.Death(); //runs the Death method in the playerStatus script
                break;
        }
    }
}
