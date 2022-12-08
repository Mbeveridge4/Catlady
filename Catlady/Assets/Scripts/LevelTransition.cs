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
    [SerializeField] private GameObject NeedPass;
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private int defaultLives = 3;
    [SerializeField] private string nextLevel;
    private bool countDown = false;

    private void Start()
    {
        countDown = false; //ensures countdown is off by default
        Countdown.SetActive(false); //hides the countdown display
        NeedPass.SetActive(false); //hides the countdown display
        countTime = defaultcountTime; //sets the countdown timer to the default timeset in Unity editor
    }



    private void OnTriggerEnter2D(Collider2D collision) //when player enters the trigger starts the timer & makes the countdown text active
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player Entered Elevator");
            if (PlayerPrefs.GetInt("passHeld") == PlayerPrefs.GetInt("currentFloor"))
            {
                Debug.Log("Floor:" + PlayerPrefs.GetInt("currentFloor") + "  Pass Held:" + PlayerPrefs.GetInt("passHeld")); //prints in log what it has been set to for error checking
                Countdown.SetActive(true);
                countDown = true;
            }
            if (PlayerPrefs.GetInt("passHeld") != PlayerPrefs.GetInt("currentFloor"))
            {
                Debug.Log("Floor:" + PlayerPrefs.GetInt("currentFloor") + "  Pass Held:" + PlayerPrefs.GetInt("passHeld")); //prints in log what it has been set to for error checking
                NeedPass.SetActive(true);
                countDown = true;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision) //when player leaves the trigger - stops the timer and hides the text
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player Left Elevator");
            Countdown.SetActive(false);
            NeedPass.SetActive(false); //hides the countdown display
            countDown = false;
            countTime = defaultcountTime;

        }
    }

    private void Update()
    {
        countdownText.text = ("Next Floor in: " + countTime.ToString("F0")); //updates the countdown display

        if (countDown == true )
        {
            countTime -= Time.deltaTime; //reduces the countdown value
        }

        if (countTime <= 0 && countDown == true && (PlayerPrefs.GetInt("passHeld") == PlayerPrefs.GetInt("currentFloor")))
        {
            int currentScore = PlayerPrefs.GetInt("playerScore");
            PlayerPrefs.SetInt("savedScore", currentScore);
            NextLevel();
        }
    }

   public void NewGame()
    {
        PlayerPrefs.SetInt("playerLives", defaultLives); //sets the value stored for lives to default.
        PlayerPrefs.SetInt("playerKills", 0); //sets kills to 0
        PlayerPrefs.SetInt("playerScore", 0); //sets score to 0
        PlayerPrefs.SetInt("savedScore", 0); //sets stored value saved (between levels) to 0
        PlayerPrefs.SetInt("currentFloor", 1); //sets current Floor Value to 0
        PlayerPrefs.SetInt("passHeld", 0); //sets pass held value to 0
        SceneManager.LoadScene("Lobby");
        
        Debug.Log("Score set to:" + PlayerPrefs.GetInt("playerScore")); //prints in log what it has been set to for error checking
        Debug.Log("Starting Lives set to:" + PlayerPrefs.GetInt("playerLives")); //prints in log what it has been set to for error checking
        Debug.Log("Kills set to:" + PlayerPrefs.GetInt("playerScore")); //prints in log what it has been set to for error checking
        Debug.Log("Floor:" + PlayerPrefs.GetInt("currentFloor")+ "  Pass Held:" + PlayerPrefs.GetInt("passHeld")); //prints in log what it has been set to for error checking
    }

    public void QuitGame()
    {
        Debug.Log("Quit Button Clicked");
        Application.Quit();
    }

    public void NextLevel()
    {
        int nextFloor = (PlayerPrefs.GetInt("currentFloor") +1);
       // nextFloor++;
        PlayerPrefs.SetInt("currentFloor", nextFloor);
        SceneManager.LoadScene(nextFloor); //when countdown gets to 0 loads the nextFloor
    }

}
