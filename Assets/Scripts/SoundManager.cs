using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    [SerializeField]
    private AudioSource defaultAudioSource; // Výchozí AudioSource pro pøehrávání zvukù

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
        PlaySound(name, instance.defaultAudioSource);
    }

    public static void PlaySound(string name, AudioSource targetAudioSource)
    {
        if (instance != null)
        {
            Sound sound = System.Array.Find(instance.sounds, s => s.name == name);

            if (sound != null && targetAudioSource != null)
            {
                targetAudioSource.PlayOneShot(sound.clip);
            }
            else
            {
                Debug.LogWarning("Zvuk " + name + " nebyl nalezen nebo není definován cílový AudioSource.");
            }
        }
        else
        {
            Debug.LogWarning("Instance SoundManageru není inicializována.");
        }
    }
}
