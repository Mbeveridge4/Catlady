using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassDialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    private bool playerInRange;
    [Header("Next Level")]
    [SerializeField] private int nextLevel;

    private void Awake()
    {
        
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().DialogueIsPlaying)
        {
            visualCue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                PlayerPrefs.SetInt("passHeld", nextLevel); //sets pass held value to new value
                Debug.Log("Pass value now:" + PlayerPrefs.GetInt("passHeld"));
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if ( other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

}
    