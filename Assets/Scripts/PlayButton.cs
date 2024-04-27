using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    WaveManager waveManager;

    private bool alreadyPressed = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!alreadyPressed)
        {
            if (collision.gameObject.name == "Player")
            {
                alreadyPressed = true;
                animator.SetTrigger("PlayButton");
                waveManager.StartWave();
            }
        }
    }
}
