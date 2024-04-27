using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    WaveManager waveManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            animator.SetTrigger("PlayButton");
            waveManager.StartWave();
        }
    }
}
