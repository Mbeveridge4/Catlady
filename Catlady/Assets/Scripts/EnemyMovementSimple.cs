using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementSimple : MonoBehaviour
{
    private bool increasing = true;
    [SerializeField] private float maxValue = 7.0f; //value that can be changes in Unity to set the max x or y value for the object
    [SerializeField] private float lowestValue = 7.0f; //value that can be changes in Unity to set the lowest x or y value for the object
    [SerializeField] private bool movesVertical = false; //used to change the movement from horizontal, to vertical
    [SerializeField] private float speed = 0.03f; //value that determines the speed of the object
    [SerializeField] private SpriteRenderer sr; //spriterenderer attached to the object
    

    // Update is called once per frame
    void Update()
    {
        CheckDirection();
        Move();
    }

    void CheckDirection()
    {
        if (movesVertical == false && transform.position.x >= maxValue) //checks if the object x transform is at the maxXvalue
        {
            increasing = false; //sets the value to false to change the if statement behavior above.
        }

        if (movesVertical == false && transform.position.x <= lowestValue)//checks if the object x transform is at the lowestX value
        {
            increasing = true; //sets the value to true to change the if statement behavior above.
        }

        if (movesVertical == true && transform.position.y >= maxValue) //checks if the object Y transform is at the maxY value
        {
            increasing = false; //sets the value to false to change the if statement behavior above.
        }

        if (movesVertical == true && transform.position.y <= lowestValue)//checks if the object x transform is at the LowestY value
        {
            increasing = true; //sets the value  to true to change the if statement behavior above.
        }
    }


    void Move()
    {
        if (increasing == true && movesVertical == false)
        {
            sr.flipX = false; //sets the directection the sprite is facing
            transform.Translate(speed, 0, 0); //increases the x transform by the value of speed to move right
        }
        if (increasing == false && movesVertical == false)
        {
            sr.flipX = true;//sets the directection the sprite is facing
            transform.Translate(-speed, 0, 0);//decreases the x transform by the value of speed to move left
        }

        if (increasing == true && movesVertical == true)
        {

            transform.Translate(0, speed, 0); //increases the Y transform by the value of speed to move right
        }
        if (increasing == false && movesVertical == true)
        {

            transform.Translate(0, -speed, 0);//decreases the Y transform by the value of speed to move left
        }
    }
}
