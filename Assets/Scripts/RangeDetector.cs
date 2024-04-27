using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Je tzam sometg");
        if(other.transform.root.gameObject.GetComponent<EnemyHP>() != null || other.GetComponent<PlayerMovement>() != null)
        gameObject.transform.root.gameObject.GetComponent<Tower>().AddAttackList(
            other.gameObject.transform.root.gameObject.GetComponent<EnemyHP>());
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.gameObject.GetComponent<EnemyHP>() != null || other.GetComponent<PlayerMovement>() != null)
            gameObject.transform.root.gameObject.GetComponent<Tower>().RemoveAttackList(
            other.gameObject.transform.root.gameObject.GetComponent<EnemyHP>());
    }
}
