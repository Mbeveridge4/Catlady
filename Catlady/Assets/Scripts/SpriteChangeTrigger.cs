using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChangeTrigger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Sprite FaceNew;
    [SerializeField] private Sprite FaceDefault;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            sr.sprite = FaceNew;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            sr.sprite = FaceDefault;
        }
    }
}
