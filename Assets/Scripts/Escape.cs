using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Escape : MonoBehaviour
{
    [SerializeField]GameObject escapPaner;
    [SerializeField]GameObject settingsPaner;
    [SerializeField] Slider slider;
    void Start()
    {
        
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
            }
            else
            {
                if(!settingsPaner.activeInHierarchy)
                {
                    escapPaner.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
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
    public void ChnageFow()
    {
        Camera.main.fieldOfView = slider.value;
    }
}
