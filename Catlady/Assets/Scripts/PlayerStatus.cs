using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


/// <summary>
/// Coded by Mark Beveridge - CGDP Year 1
/// </summary>
public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private int defaultLives = 3; //integer value for default number of lives to begin the game with.
    [SerializeField] private TMP_Text scoreText; //text object that displays the score
    [SerializeField] private TMP_Text killText; //text object that displays the kill counter
    public Transform deathRespawn; //location that the player should respawn if they die
    public GameObject player; //the player gameobject


    public void Start()
    {
        DefaultLives(); //on start resets lives to the default
        ResetScore(); // on start resets the score to 0
        ResetKills();
    }

    public void Update()
    {
        int currentScore = PlayerPrefs.GetInt("playerScore"); //fetches the value of player score
        int currentKills = PlayerPrefs.GetInt("playerKills");
        scoreText.text = "Score: " + currentScore.ToString(); // changes the text to display the current score
        killText.text = "Kills: " + currentKills.ToString();
    }


    public void DefaultLives()
    {
        PlayerPrefs.SetInt("playerLives", defaultLives); //sets the value stored for lives to default.
        Debug.Log("Starting Lives set to:" + PlayerPrefs.GetInt("playerLives")); //prints in log what it has been set to for error checking
    }

    //can be called to subtract from the players current Life count

    public void LoseLives(int lives)
    {
        int currentlives = PlayerPrefs.GetInt("playerLives"); //fetches the current lives value
        currentlives -= lives; //subtracts value given to method
        PlayerPrefs.SetInt("playerLives", currentlives); //saves the updated lives value
        Debug.Log("Lives updated to: " + PlayerPrefs.GetInt("playerLives"));
       gameObject.transform.position = deathRespawn.position;
    }

    //Can be called to add to the players current Life count
    public void GainLives(int lives)
    {
        int currentlives = PlayerPrefs.GetInt("playerLives"); //fetches the current lives value
        currentlives += lives; //adds value given to method
        PlayerPrefs.SetInt("playerLives", currentlives); //saves the updated lives value
        Debug.Log("Lives updated to: " + PlayerPrefs.GetInt("playerLives"));
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("playerScore", 0); //sets score to 0
        Debug.Log("Score set to:" + PlayerPrefs.GetInt("playerScore")); //prints in log what it has been set to for error checking
    }

    public void GainScore(int points)
    {
        int currentScore = PlayerPrefs.GetInt("playerScore"); //fetches the current saved score value
        currentScore += points; // adds the points fed in to the method
        PlayerPrefs.SetInt("playerScore", currentScore); //saves the updated score
    }

    public void ResetKills()
    {
        PlayerPrefs.SetInt("playerKills", 0); //sets score to 0
        Debug.Log("Kills set to:" + PlayerPrefs.GetInt("playerScore")); //prints in log what it has been set to for error checking
    }

    public void GainKills()
    {
        int currentKills = PlayerPrefs.GetInt("playerKills"); //fetches the current saved score value
        currentKills++; // adds the points fed in to the method
        PlayerPrefs.SetInt("playerKills", currentKills); //saves the updated score
    }

    public void Death()
    {

    }
}
