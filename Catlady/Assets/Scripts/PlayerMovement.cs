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
    [Tooltip("assign gun1 gun2 and gun3 to the UI graphic for each weapon. Assign each projectile to the relevant projectile the gun fires")]
    [SerializeField] private GameObject gun1, gun2, gun3, projectile1, projectile2, projectile3;
    public Rigidbody2D rb;
    private float mx = 2f;
    private float my;
    [Tooltip("Variables for projectile spawns. Edit in Prefab for consistency.")]
    public Transform firePositionR1, firePositionR2, firePositionR3, firePositionRFB, firePositionL1, firePositionL2, firePositionL3, firePositionLFB, firePositionD1, firePositionD2, firePositionD3, firePositionU1, firePositionU2, firePositionU3;
    public bool isVertical = false, isNegative = false, canMove = true;
    [Tooltip("Variables for rate of fire for each weapon.")]
    [SerializeField] private float timerdefault, gun1delay, gun2delay, gun3delay;
    private float timer = .4f;
    private int snotPos = 1;
    public LevelTransition levelTrans;
    [Tooltip("Audio for each weapontype")]
    [SerializeField] AudioSource weaponSource;
    [SerializeField] AudioClip[] snotClipsArray;
    [SerializeField] AudioClip[] furballClipsArray;
    [SerializeField] AudioClip[] fartClipsArray;
    [SerializeField] AudioClip snoring;
    [SerializeField] GameObject menu;
    public bool paused = false;



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
        if (DialogueManager.GetInstance().DialogueIsPlaying)
        {
            return;
        }
       
        if (paused)
        {
            return;
        }
        

            int playerWeapon = PlayerPrefs.GetInt("playerWeapon");

            //if Escape key is pressed - reloads the DevelopmentScene **remove before final build!**
            if (Input.GetKeyDown(KeyCode.Escape))
            {
            menu.SetActive(true);
            Time.timeScale = 0f;
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

                isNegative = true;

            }
            if (mx > 0) // if player is moving right, set negative to false and cancel the SR flip if there is one
            {
                spriteRenderer.flipX = false;

                isNegative = false;

            }

            if (my > 0) //if player is moving up, set vertical to true, negative to false.
            {
                isVertical = true;
                isNegative = false;
            }
            if (my < 0) //if player is moving down, set vertical to true, negative to true.
            {

                isVertical = true;
                isNegative = true;
            }

            if (my == 0) //if player is moving horizontally or not moving at all, set vertical to false
            {

                isVertical = false;

            }

            if (mx == 0 && my >=0) //if player is moving vertically or not moving at all, set vertical to false
            {

                isNegative = false;

            }


            timer -= Time.deltaTime;
           
           


            if (Input.GetKeyDown(KeyCode.Space) && timer <= 0)
            {


                switch (playerWeapon)
                {
                    case 1: // creates an instance of projectile1 if weapon 1 is the current weapon
                        if (isNegative == false && isVertical == false)
                        {
                            Projectile1R(); //calls the function to shoot right & cycle between positions
                        weaponSource.clip = snotClipsArray[Random.Range(0, snotClipsArray.Length)];
                        weaponSource.Play();
                    }
                        if (isNegative == true && isVertical == false)
                        {
                            Projectile1L(); //calls the function to shoot left & cycle between positions
                        weaponSource.clip = snotClipsArray[Random.Range(0, snotClipsArray.Length)];
                        weaponSource.Play();
                    }

                        if (isNegative == false && isVertical == true)
                        {
                            Projectile1Up(); //calls the function to shoot up & cycle between positions
                        weaponSource.clip = snotClipsArray[Random.Range(0, snotClipsArray.Length)];
                        weaponSource.Play();
                    }
                        if (isNegative == true && isVertical == true)
                        {
                            Projectile1Down(); //calls the function to shoot down & cycle between positions
                        weaponSource.clip = snotClipsArray[Random.Range(0, snotClipsArray.Length)];
                        weaponSource.Play();
                    }

                        break;

                    case 2: // creates an instance of projectile2 if weapon 2 is the current weapon

                        if (isNegative == false && isVertical == false)
                        {
                            Projectile2R(); //calls the function to shoot right
                        weaponSource.clip = furballClipsArray[Random.Range(0, furballClipsArray.Length)];
                        weaponSource.Play();
                    }
                        if (isNegative == true && isVertical == false)
                        {
                            Projectile2L(); //calls the function to shoot left
                        weaponSource.clip = furballClipsArray[Random.Range(0, furballClipsArray.Length)];
                        weaponSource.Play();
                    }


                        break;

                    case 3: // creates an instance of projectile3 at the players position if weapon 3 is the current weapon
                        Instantiate(projectile3, transform.position, transform.rotation);
                        Debug.Log("You fired gun 3");
                    weaponSource.clip = fartClipsArray[Random.Range(0, fartClipsArray.Length)];
                    weaponSource.Play();

                    break;


                }

                timer = timerdefault; //resets the timer to default (used to prevent excessive rate of fire.
            }
            if (timer <= 0 !&& Input.GetKeyDown(KeyCode.Space))
        {
            weaponSource.clip = snoring;
            weaponSource.Play();
        }



            if (Input.GetKeyDown(KeyCode.Q)) //Cycles between weapon types
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
                        timer = 0.2f;
                        break;
                    case 2: //changes the weapon to the next weapon in the cycle, and changes the active ui displayed weapon
                        PlayerPrefs.SetInt("playerWeapon", 3);
                        gun3.SetActive(true);
                        gun2.SetActive(false);
                        gun1.SetActive(false);
                        timerdefault = gun3delay;
                        timer = 0.2f;
                        break;
                    case 3: //changes the weapon to the next weapon in the cycle, and changes the active ui displayed weapon
                        PlayerPrefs.SetInt("playerWeapon", 1);
                        gun3.SetActive(false);
                        gun2.SetActive(false);
                        gun1.SetActive(true);
                        timerdefault = gun1delay;
                        timer = 0.2f;
                        break;
                }

            }

        }
        void Projectile1R() //spawns a projectile to the right of the character, cycling through the 3 positions each time
        {
            if (snotPos == 1)
            {
                Debug.Log("current snotPos Value: " + snotPos);
                Instantiate(projectile1, firePositionR1.position, firePositionR1.rotation);
                Debug.Log("You fired gun 1 in pos1");

            }

            if (snotPos == 2)
            {
                Debug.Log("current snotPos Value: " + snotPos);
                Instantiate(projectile1, firePositionR2.position, firePositionR2.rotation);
                Debug.Log("You fired gun 1 in pos2");

            }


            if (snotPos == 3)
            {
                Debug.Log("current snotPos Value: " + snotPos);
                Instantiate(projectile1, firePositionR3.position, firePositionR3.rotation);
                Debug.Log("You fired gun 1 in pos3");

            }

            snotPos++;
            if (snotPos > 3)
            {
                snotPos = 1;
            }
        }
        void Projectile1L() //spawns a projectile to the left of the character, cycling through the 3 positions each time
        {
            if (snotPos == 1)
            {
                Debug.Log("current snotPos Value: " + snotPos);
                Instantiate(projectile1, firePositionL1.position, firePositionL1.rotation);
                Debug.Log("You fired gun 1 in Lpos1");

            }

            if (snotPos == 2)
            {
                Debug.Log("current snotPos Value: " + snotPos);
                Instantiate(projectile1, firePositionL2.position, firePositionL2.rotation);
                Debug.Log("You fired gun 1 in Lpos2");

            }


            if (snotPos == 3)
            {
                Debug.Log("current snotPos Value: " + snotPos);
                Instantiate(projectile1, firePositionL3.position, firePositionL3.rotation);
                Debug.Log("You fired gun 1 in Lpos3");

            }

            snotPos++;
            if (snotPos > 3)
            {
                snotPos = 1;
            }
        }

        void Projectile1Up() //spawns a projectile to the top of the character, cycling through the 3 positions each time
        {
            if (snotPos == 1)
            {
                Debug.Log("current snotPos Value: " + snotPos);
                Instantiate(projectile1, firePositionU1.position, firePositionU1.rotation);
                Debug.Log("You fired gun 1 in Lpos1");

            }

            if (snotPos == 2)
            {
                Debug.Log("current snotPos Value: " + snotPos);
                Instantiate(projectile1, firePositionU2.position, firePositionU2.rotation);
                Debug.Log("You fired gun 1 in Lpos2");

            }


            if (snotPos == 3)
            {
                Debug.Log("current snotPos Value: " + snotPos);
                Instantiate(projectile1, firePositionU3.position, firePositionU3.rotation);
                Debug.Log("You fired gun 1 in Lpos3");

            }

            snotPos++;
            if (snotPos > 3)
            {
                snotPos = 1;
            }
        }

        void Projectile1Down() //spawns a projectile to the bottom of the character, cycling through the 3 positions each time
        {
            if (snotPos == 1)
            {
                Debug.Log("current snotPos Value: " + snotPos);
                Instantiate(projectile1, firePositionD1.position, firePositionD1.rotation);
                Debug.Log("You fired gun 1 in Lpos1");

            }

            if (snotPos == 2)
            {
                Debug.Log("current snotPos Value: " + snotPos);
                Instantiate(projectile1, firePositionD2.position, firePositionD2.rotation);
                Debug.Log("You fired gun 1 in Lpos2");

            }


            if (snotPos == 3)
            {
                Debug.Log("current snotPos Value: " + snotPos);
                Instantiate(projectile1, firePositionD3.position, firePositionD3.rotation);
                Debug.Log("You fired gun 1 in Lpos3");

            }

            snotPos++;
            if (snotPos > 3)
            {
                snotPos = 1;
            }
        }

        void Projectile2L() //spawns projectile 2 to the left of the character
        {
            Instantiate(projectile2, firePositionLFB.position, firePositionLFB.rotation);
            Debug.Log("You fired gun 2");
        }

        void Projectile2R() //spawns projectile 2 to the right of the character
        {
            Instantiate(projectile2, firePositionRFB.position, firePositionRFB.rotation);
            Debug.Log("You fired gun 2");
        }

    public void Pause()
    {
        paused = true;
    }
    public void Unpause()
    {
        paused = false;
    }



}
    
