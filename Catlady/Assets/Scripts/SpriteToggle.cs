using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteToggle : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private SpriteRenderer[] sprites;
    public GameObject[] Hearts;
    [SerializeField] public int playerLives;

    public void Update()
    {
       
        if (PlayerPrefs.GetInt("Lives") >= 3)
        {
            
          
        }

        if (PlayerPrefs.GetInt("Lives") == 2)
        {


        }

        if (PlayerPrefs.GetInt("Lives") == 1)

        {


        }

        if (PlayerPrefs.GetInt("Lives") <= 0)
        {


        }
    }

}
