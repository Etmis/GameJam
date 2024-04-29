using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IceTower : Tower
{

  
    public override void Attacks()
    {
    
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range / 2);

        closestN = null;
        if (hitColliders != null && hitColliders[0].GetComponent<EnemyHP>())
        {
            Debug.Log("dìlej");
            SoundManager.PlaySound("iceTower", base.audioSource);

        }

        for (int i = 0; i < hitColliders.Length; i++)
        {

            Collider collider = hitColliders[i];
            if (collider.gameObject.transform.root.gameObject.GetComponent<EnemyHP>() != null)
            {
                Vector3 poziceNepriatele = collider.transform.position;
                collider.gameObject.transform.root.gameObject.GetComponent<EnemyHP>().FreezeDamage(coolDown);




            }
        }
        SoundManager.PlaySound("iceTower");

        
    }
}
