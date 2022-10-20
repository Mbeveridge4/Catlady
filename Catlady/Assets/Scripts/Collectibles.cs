using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Coded by Mark Beveridge - CGDP Year 1
/// </summary>
public class Collectibles : MonoBehaviour
{
    [SerializeField] private bool isLife = false; //used to differentiate behavior between lives and point collectibles
    [SerializeField] private int pointValue = 10; //set in unity, decides what this collectible is worth in points
    private PlayerStatus playerStatus;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("You got the Collectible");
            playerStatus = collision.gameObject.GetComponent<PlayerStatus>();
            if (isLife == false) //if a point collectible, runs the score method and then destroys the collectible
            {
                playerStatus.GainScore(pointValue);
                Destroy(gameObject);
            }
            if (isLife == true) //if a life collectible, runs the life method and then destroys the collectible
            {
                playerStatus.GainLives(1);
                Destroy(gameObject);
            }
        }
    }
}
