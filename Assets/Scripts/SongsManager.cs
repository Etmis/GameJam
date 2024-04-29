using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongsManager : MonoBehaviour
{
    [SerializeField] List<AudioClip> clips;
    [SerializeField] AudioSource source;
    AudioClip lastClip;
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            source.clip = clips[Random.Range(0, 4)];
            if(source.clip == lastClip)
            {
                return;
            }
            lastClip = source.clip;

            source.Play();
        }

    }
}
