using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

/// <summary>
/// Coded by Mark Beveridge - CGDP Year 1
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject gun1, gun2, gun3, projectile1, projectile2, projectile3;
    public Rigidbody2D rb;
    private float mx = 2f;
    private float my;
    public Transform firePosition;
    public bool isVertical = false;
    public bool isNegative = false;
    public Vector3 offset, currentOffset;
    [SerializeField] private float timerdefault;
    [SerializeField] private float gun1delay, gun2delay, gun3delay;
    private float timer = .4f;

    private void Start() //on start, sets the default weapon and ui display to weapon 1, and the player looking right
    {
        PlayerPrefs.SetInt("playerWeapon", 1);
        gun3.SetActive(false);
        gun2.SetActive(false);
        gun1.SetActive(true);
        spriteRenderer.flipX = false;
    }


    private void Update()
    {
        int playerWeapon = PlayerPrefs.GetInt("playerWeapon");
        //if Escape key is pressed - reloads the DevelopmentScene **remove before final build!**
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("DevScene");
        }

        //sets mx float to the horizontal player input from unity (A,D or left or right keys)
        mx = Input.GetAxisRaw("Horizontal");
        //sets my float to the vertical player input from unity (W,S or up or right keys)
        my = Input.GetAxisRaw("Vertical");

        //multiplies the inputs above by movespeed to move the player character
        rb.velocity = new(mx * moveSpeed, my * moveSpeed);
        

       
        if (mx < 0)
        {
            spriteRenderer.flipX = true; //if player is moving left, sets negative to true and SR flips, offset is set to negative value.
            currentOffset = -offset;
            isNegative = true;
            
        }
        if (mx > 0) // if player is moving right, set negative to false and cancel the SR flip if there is one
        {
            spriteRenderer.flipX = false;
            currentOffset = offset;
            isNegative = false;
            
        }

        if (my > 0) //if player is moving up, set vertical to true, negative to false.
        {
            isVertical = true;
            isNegative = false;
        }
        if (my <0) //if player is moving down, set vertical to true, negative to true.
        {

            isVertical = true;
            isNegative = true;
        }

        if (my == 0) //if player is moving horizontally or not moving at all, set vertical to false
        {

            isVertical = false;
        }

        timer -= Time.deltaTime;

       
        if (Input.GetKeyDown(KeyCode.Space) && timer <= 0)
        {
           

            switch (playerWeapon)
            {
                case 1: // creates an instance of projectile1 if weapon 1 is the current weapon
                    Instantiate(projectile1, firePosition.position + currentOffset, firePosition.rotation);
                    Debug.Log("You fired gun 1");
                    Debug.Log(currentOffset);
                    break;

                case 2: // creates an instance of projectile2 if weapon 2 is the current weapon
                    Instantiate(projectile2, firePosition.position + currentOffset, firePosition.rotation);
                    Debug.Log("You fired gun 2");
                    Debug.Log(currentOffset);
                    break;

                case 3: // creates an instance of projectile3 if weapon 3 is the current weapon
                    Instantiate(projectile3, firePosition.position + currentOffset, firePosition.rotation);
                    Debug.Log("You fired gun 3");
                    Debug.Log(currentOffset);
                    break;


            }

            timer = timerdefault; //resets the timer to default (used to prevent excessive rate of fire.
        }


        
        if (Input.GetKeyDown(KeyCode.E)) //Cycles between weapon types
        {
            
            int currentweapon = PlayerPrefs.GetInt("playerWeapon"); //fetches the stored value for playerWeapon and stores it in a local variable

            switch (currentweapon)
            {
                case 1: //changes the weapon to the next weapon in the cycle, and changes the active ui displayed weapon
                    PlayerPrefs.SetInt("playerWeapon", 2);
                    gun3.SetActive(false);
                    gun2.SetActive(true);
                    gun1.SetActive(false);
                    timerdefault = gun2delay;
                    break;
                case 2: //changes the weapon to the next weapon in the cycle, and changes the active ui displayed weapon
                    PlayerPrefs.SetInt("playerWeapon", 3);
                    gun3.SetActive(true);
                    gun2.SetActive(false);
                    gun1.SetActive(false);
                    timerdefault = gun3delay;
                    break;
                case 3: //changes the weapon to the next weapon in the cycle, and changes the active ui displayed weapon
                    PlayerPrefs.SetInt("playerWeapon", 1);
                    gun3.SetActive(false);
                    gun2.SetActive(false);
                    gun1.SetActive(true);
                    timerdefault = gun1delay;
                    break;
            }

        }

    }

}
    
