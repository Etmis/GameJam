using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTower : Tower
{

  
    public override void Attacks()
    {
    
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range / 2);

        closestN = null;

        for (int i = 0; i < hitColliders.Length; i++)
        {

            Collider collider = hitColliders[i];
            if (collider.gameObject.transform.root.gameObject.GetComponent<EnemyHP>() != null)
            {
                Vector3 poziceNepriatele = collider.transform.position;
                collider.gameObject.transform.root.gameObject.GetComponent<EnemyHP>().FreezeDamage(coolDown);




            }
        }

        
    }
}
