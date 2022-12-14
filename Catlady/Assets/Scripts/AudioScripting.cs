using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScripting : MonoBehaviour
{

    [SerializeField] AudioSource firstAudio;
    [SerializeField] AudioSource secondAudio;

    private void Awake()
    {
        firstAudio.enabled = true;
        secondAudio.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            firstAudio.enabled = false;
            secondAudio.enabled = true;
        }

    }
}
