using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance; 

    [SerializeField]
    private AudioSource audioSource; 

   
    [System.Serializable]
    private class Sound
    {
        public string name; 
        public AudioClip clip; 
    }

    [SerializeField]
    private Sound[] sounds; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void PlaySound(string name)
    {
        if (instance != null)
        {
            Sound sound = System.Array.Find(instance.sounds, s => s.name == name); 

            if (sound != null && instance.audioSource != null)
            {
                instance.audioSource.PlayOneShot(sound.clip);
            }
            else
            {
            }
        }
        else
        {
        }
    }
}
