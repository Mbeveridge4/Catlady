using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScripts : MonoBehaviour
{
    [SerializeField] private GameObject Settings;
    [SerializeField] private GameObject MainButtons;
    [SerializeField] private GameObject Cats;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private AudioSettings audioSettings;
    public void LoadSettings()
    {
       Settings.SetActive(true);
       MainButtons.SetActive(false);
       Cats.SetActive(false);
       
   
    }

    public void LoadSettingsGame()
    {
        audioSettings.LoadValues();
        Settings.SetActive(true);
        MainButtons.SetActive(false);
        Cats.SetActive(false);
        playerMovement.paused = true;
        Time.timeScale = 0f;

    }

    public void ExitSettings()
    {
        Settings.SetActive(false);
        MainButtons.SetActive(true);
        Cats.SetActive(true);
     
       
    }
    public void ExitSettingsGame()
    {
        Settings.SetActive(false);
        MainButtons.SetActive(true);
        Cats.SetActive(true);
        playerMovement.paused = false;
        Time.timeScale = 1f;

    }
}
