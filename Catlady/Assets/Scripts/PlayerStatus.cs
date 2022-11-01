using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


/// <summary>
/// Coded by Mark Beveridge - CGDP Year 1
/// </summary>
public class PlayerStatus : MonoBehaviour
{
    
    [SerializeField] private TMP_Text scoreText; //text object that displays the score
    [SerializeField] private TMP_Text killText; //text object that displays the kill counter
    public Transform playerPos; //location that the player should respawn if they die
    public GameObject player; //the player gameobject
    public PlayerMovement playerMov;


    
    public void Update()
    {
        int currentScore = PlayerPrefs.GetInt("playerScore"); //fetches the value of player score
        int currentKills = PlayerPrefs.GetInt("playerKills");
        int currentLives = PlayerPrefs.GetInt("playerLives");
        scoreText.text = "Score: " + currentScore.ToString(); // changes the text to display the current score
        killText.text = "Kills: " + currentKills.ToString();
        if (currentLives < 1)
        {
            Death();
        }
    }


    //can be called to subtract from the players current Life count

    public void LoseLives(int lives)
    {
        
        int currentlives = PlayerPrefs.GetInt("playerLives"); //fetches the current lives value
        currentlives -= lives; //subtracts value given to method
        PlayerPrefs.SetInt("playerLives", currentlives); //saves the updated lives value
        Debug.Log("Lives updated to: " + PlayerPrefs.GetInt("playerLives"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);   //reloads the current level
        PlayerPrefs.SetInt("playerScore", PlayerPrefs.GetInt("savedScore"));
        Debug.Log("score Reset to: " + PlayerPrefs.GetInt("playerScore"));


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

   public void GainKills()
    {
        int currentKills = PlayerPrefs.GetInt("playerKills"); //fetches the current saved score value
        currentKills++; // adds the points fed in to the method
        PlayerPrefs.SetInt("playerKills", currentKills); //saves the updated score
    }

    public void Death()
    {
        SceneManager.LoadScene("MainMenu");
    }

   
}
