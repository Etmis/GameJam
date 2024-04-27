using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    [SerializeField]GameObject paner;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paner.activeInHierarchy)
            {
                paner.SetActive(false);
            }else
            {
                paner.SetActive(true);
            }

        }
    }
}
