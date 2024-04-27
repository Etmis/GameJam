using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Escape : MonoBehaviour
{
    [SerializeField]GameObject escapPaner;
    [SerializeField]GameObject settingsPaner;
    [SerializeField] Slider fovSlider;
    [SerializeField] Slider sensSlider;
    void Start()
    {
        if(PlayerPrefs.HasKey("sensitivity"))
        {
            LoadSettings();
        }
        else
        {
            PlayerPrefs.SetFloat("sensitivity", 5f);
            PlayerPrefs.SetFloat("FOV", 60);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(escapPaner.activeInHierarchy)
            {
                escapPaner.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                LoadSettings();

            }
            else
            {
                if(!settingsPaner.activeInHierarchy)
                {
                    escapPaner.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    PlayerMovement.sensitivity = 0;
                    Camera.main.fieldOfView = 0;

                }
                
            }

        }
    }
    public void GoToSettings()
    {
        escapPaner.SetActive(false);
        settingsPaner.SetActive(true);
    }
    public void BackToMenu()
    {
        escapPaner.SetActive(true);
        settingsPaner.SetActive(false);
    }
    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("sensitivity", sensSlider.value);
        PlayerPrefs.SetFloat("FOV", fovSlider.value);
        BackToMenu();
        LoadSettings();
    }
    public void LoadSettings()
    {
        var sens = PlayerPrefs.GetFloat("sensitivity");
        var fov = PlayerPrefs.GetFloat("FOV");
        PlayerMovement.sensitivity = sens;
        Camera.main.fieldOfView = fov;
        sensSlider.value = sens;
        fovSlider.value = fov;
    }
   
    
    
    
        
        
    
}



    
