using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Upgrader : MonoBehaviour
{
    [SerializeField] GameObject paner;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Perform the raycast
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, 5))
            {

                var nig = hitInfo.transform.GetComponent<Tower>();
                if (nig != null)
                {
                    Aktivuj();

                }
            }


        }
    }
    public void Return()
    {
        paner.SetActive(false);
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
        Time.timeScale = 1;
        if(PlayerPrefs.HasKey("sensitivity"))
        {
            PlayerMovement.sensitivity = PlayerPrefs.GetFloat("sensitivity");
        }
        else
        {
            PlayerMovement.sensitivity = 5;
        }
        
    }
    void Aktivuj()
    {
        paner.SetActive(true);
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
        Time.timeScale = 0;
        PlayerMovement.sensitivity = 0;
    }

   
}
