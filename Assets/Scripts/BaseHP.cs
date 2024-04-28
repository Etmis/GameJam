using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseHP : HPSystem
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.root.gameObject.GetComponent<EnemyHP>()) {

            if (base.currentHP - other.gameObject.transform.root.gameObject.GetComponent<EnemyHP>().currentHP <= 0)
            {
                SceneManager.LoadScene("Menu");
            }
            DoDamage(other.gameObject.transform.root.gameObject.GetComponent<EnemyHP>().currentHP);
            other.gameObject.transform.root.gameObject.GetComponent<EnemyHP>().DooDamage(100000);
            
            
        




        }

    }
}
