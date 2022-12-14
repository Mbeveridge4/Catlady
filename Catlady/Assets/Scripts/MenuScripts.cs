using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScripts : MonoBehaviour
{
    [SerializeField] private GameObject Settings;
    [SerializeField] private GameObject MainButtons;
    [SerializeField] private GameObject Cats;
    void LoadSettings()
    {
       Settings.SetActive(true);
       MainButtons.SetActive(false);
       Cats.SetActive(false);
    }

    void ExitSettings()
    {
        Settings.SetActive(false);
        MainButtons.SetActive(true);
        Cats.SetActive(true);
    }
}
