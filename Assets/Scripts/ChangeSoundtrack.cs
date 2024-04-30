using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSoundtrack : MonoBehaviour
{
    [SerializeField] AudioSource a;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void zmenSong()
    {
        a.Stop();
    }
}
