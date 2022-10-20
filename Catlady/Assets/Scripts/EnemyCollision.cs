using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Coded by Mark Beveridge - CGDP Year 1
/// </summary>
public class EnemyCollision : MonoBehaviour
{

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Collider2D col;
    [SerializeField] private PlayerStatus playerStatus;
    [SerializeField] private int pointValue = 20;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))  //if object that collides with it has the player tag
        {
            Debug.Log("You ran into an enemy");
            playerStatus.LoseLives(1); //runs the lose life method in the playerStatus script, feeding it a int value of 1
        }

        if (collision.gameObject.CompareTag("Projectile")) //if object that collides with it has the projectile tag
        {
            Debug.Log("You killed an enemy");
            playerStatus.GainScore(pointValue); //adds to the score the value set for pointValue in unity (for this specific enemy)
            playerStatus.GainKills(); //adds to the kill counter
            Destroy(gameObject); //destroys this enemy object

        }

    }

}
