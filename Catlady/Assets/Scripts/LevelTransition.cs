using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// Coded by Mark Beveridge - CGDP Year 1
/// </summary>
public class LevelTransition : MonoBehaviour
{
    [SerializeField] private float defaultcountTime = 3.0f;
    private float countTime = 3.0f;
    [SerializeField] private GameObject Countdown;
    [SerializeField] private TMP_Text countdownText;
    private bool countDown = false;

    private void Start()
    {
        countDown = false; //ensures countdown is off by default
        Countdown.SetActive(false); //hides the countdown display
        countTime = defaultcountTime; //sets the countdown timer to the default timeset in Unity editor
    }



    private void OnTriggerEnter2D(Collider2D collision) //when player enters the trigger starts the timer & makes the countdown text active
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player Entered Elevator");
            Countdown.SetActive(true);
            countDown = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision) //when player leaves the trigger - stops the timer and hides the text
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player Left Elevator");
            Countdown.SetActive(false);
            countDown = false;
            countTime = defaultcountTime;

        }
    }

    private void Update()
    {
        countdownText.text = ("Next Floor in: " + countTime.ToString("F0")); //updates the countdown display

        if (countDown == true)
        {
            countTime -= Time.deltaTime; //reduces the countdown value
        }

        if (countTime <= 0 && countDown == true)
        {
            SceneManager.LoadScene("DevScene"); //when countdown gets to 0 loads the scene DevScene
        }
    }

    private void NewGame()
    {
        SceneManager.LoadScene("DevScene");
    }

    private void QuitGame()
    {
        Application.Quit();
    }

}
