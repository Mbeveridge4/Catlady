using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScripts : MonoBehaviour
{
    [SerializeField] private GameObject Settings;
    [SerializeField] private GameObject MainButtons;
    [SerializeField] private GameObject Cats;
    
    public void LoadSettings()
    {
       Settings.SetActive(true);
       MainButtons.SetActive(false);
       Cats.SetActive(false);
        AudioListener.volume = 0;
       Time.timeScale = 0f;
   
    }

    public void ExitSettings()
    {
        Settings.SetActive(false);
        MainButtons.SetActive(true);
        Cats.SetActive(true);
        AudioListener.volume = 1;
        Time.timeScale = 1f;
       
    }
}
