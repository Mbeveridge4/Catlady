using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private PlayerStatus playerStatus;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Debug.Log("Checkpoint entered");
      
    }
}
