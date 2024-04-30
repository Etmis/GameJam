using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IceTower : Tower
{
    bool alreadyPlayedMusic;
  
    public override void Attacks()
    {

        timeToFire = fire_Rate;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range / 2);

        closestN = null;
        alreadyPlayedMusic = false;

        for (int i = 0; i < hitColliders.Length; i++)
        {

            Collider collider = hitColliders[i];
            if (collider.gameObject.transform.root.gameObject.GetComponent<EnemyHP>() != null)
            {
                if (!alreadyPlayedMusic) 
                {
                    SoundManager.PlaySound("iceTower");
                    alreadyPlayedMusic = true;
                }
                Debug.Log(i + "hoooooooooooooooooooooooooooo" + collider.gameObject.transform.root.gameObject.GetComponent<EnemyHP>());
                Vector3 poziceNepriatele = collider.transform.position;
                collider.gameObject.transform.root.gameObject.GetComponent<EnemyHP>().FreezeDamage(coolDown);




            }
        }

        
    }
}
