using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Coded by Mark Beveridge - CGDP Year 1
/// </summary>
public class ProjectileBehaviour : MonoBehaviour
{
    //projectile speed
    [SerializeField] private float defaultSpeed = 0.05f;
    private float Speed = 0.1f;
    //max lifetime of the projectile
    [SerializeField] private float lifeTime = 4f;
    [SerializeField] private Vector3 offset;
    private PlayerMovement playerMovement;
    public bool vertical = false;

    

    public void Start()
    {

        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerMovement.offset = offset;
        vertical = playerMovement.isVertical;
        Debug.Log(offset);
        //Sets the player idle direction to default to the right
        if (playerMovement.isNegative == false)
        {
            Speed = defaultSpeed;
        }
        if (playerMovement.isNegative == true)
        {
            Speed = defaultSpeed * -1;
        }
        
    }
    

    // Update is called once per frame
    public void Update()
    {
        //moves the projectile
        if (vertical == false)
        {
            transform.position = new Vector3(transform.position.x + Speed, transform.position.y);
        }
        if (vertical == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Speed);
        }

        // counts down the lifetime
        lifeTime -= Time.deltaTime;

        //destroys the projectile when time is finished.
        if (lifeTime <= 0 )
       {
            Destroy(gameObject);
        }
   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }

        if (gameObject.name == "GasCloud(Clone)")
        {
            Debug.Log("Something Entered the Gas!");   
        }
        else
        {
            Debug.Log("Projectile Collided!");
            Destroy(gameObject);
        }
    }
}

