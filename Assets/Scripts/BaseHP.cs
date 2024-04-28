using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHP : HPSystem
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.root.gameObject.GetComponent<EnemyHP>()) { 
         Debug.Log(other.gameObject.transform.root.gameObject.GetComponent<EnemyHP>().currentHP + "<--");
        DoDamage(other.gameObject.transform.root.gameObject.GetComponent<EnemyHP>().currentHP);
        other.gameObject.transform.root.gameObject.GetComponent<EnemyHP>().DooDamage(100000);
         Debug.Log(currentHP);




        }

    }
}
