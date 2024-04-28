using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaTower : Tower
{
    [SerializeField]
    private int countOfLighting;
    [SerializeField]
    protected Transform LaserPlace;
    [SerializeField]
    protected LineRenderer lineRenderer;

    List<GameObject> enemies = new List<GameObject>();
    public override void Attacks()
    {
        timeToFire = fire_Rate;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range / 2);

        closestN = null;
        float closestRange = Mathf.Infinity;

        for (int i = 0; i < hitColliders.Length; i++)
        {

            Collider collider = hitColliders[i];
            if (collider.gameObject.transform.root.gameObject.GetComponent<EnemyHP>() != null)
            {
                Vector3 poziceNepriatele = collider.transform.position;

                float vzdalenost = Vector3.Distance(transform.position, poziceNepriatele);

                if (vzdalenost < closestRange)
                {
                    closestN = collider.gameObject.transform.root.gameObject;
                    closestRange = vzdalenost;
                }
            }
        }

        if (closestN != null)
        {
            SoundManager.PlaySound("teslaTower", base.audioSource);
            lineRenderer.enabled = false;
            enemies.Add(closestN);
            // CanonHead.LookAt(closestN.gameObject.transform.root.gameObject.transform);
        //    closestN.gameObject.transform.root.gameObject.GetComponent<EnemyHP>().DooDamage(damage);
            StartCoroutine(DrawLineForDuration(closestN));
        }
    }

    IEnumerator DrawLineForDuration(GameObject closest)
    {

    
        yield return new WaitForSeconds(1f);
        lineRenderer.enabled = false;
        if(closest != null) { 
        timeToFire = fire_Rate;
        Collider[] hitColliders = Physics.OverlapSphere(closest.transform.position, range / 2);

        closest = null;
        float closestRange = Mathf.Infinity;

        for (int i = 0; i < hitColliders.Length; i++)
        {

            Collider collider = hitColliders[i];
            if (collider.gameObject.transform.root.gameObject.GetComponent<EnemyHP>() != null)
            {
                Vector3 poziceNepriatele = collider.transform.position;

                float vzdalenost = Vector3.Distance(transform.position, poziceNepriatele);

                if (vzdalenost < closestRange && !enemies.Contains(closest))
                {
                    closest = collider.gameObject.transform.root.gameObject;
                    closestRange = vzdalenost;
                }
            }
        }

        if (closest != null)
        {
        
            enemies.Add(closest);

            // CanonHead.LookAt(closestN.gameObject.transform.root.gameObject.transform);
            //     closest.gameObject.transform.root.gameObject.GetComponent<EnemyHP>().DooDamage(damage);
            //      lineRenderer.SetPosition(0, LaserPlacestatic.position);

        }

        StartCoroutine(DrawLineForDurationTwo(closest));
        }
    }

    private IEnumerator DrawLineForDurationTwo(GameObject closest)
    {
 
        yield return new WaitForSeconds(1f);
        timeToFire = fire_Rate;
        if(closest != null) { 
            Collider[] hitColliders = Physics.OverlapSphere(closest.transform.position, range / 2);
    

            closest = null;
            float closestRange = Mathf.Infinity;

            for (int i = 0; i < hitColliders.Length; i++)
            {

            Collider collider = hitColliders[i];
            if (collider.gameObject.transform.root.gameObject.GetComponent<EnemyHP>() != null)
            {
                Vector3 poziceNepriatele = collider.transform.position;

                float vzdalenost = Vector3.Distance(transform.position, poziceNepriatele);

                if (vzdalenost < closestRange && !enemies.Contains(closest))
                {
                    closest = collider.gameObject.transform.root.gameObject;
                    closestRange = vzdalenost;
                }
            }
        }

        if (closest != null)
        {

            closest.GetComponent<Renderer>();

                enemies.Add(closest);
            // CanonHead.LookAt(closestN.gameObject.transform.root.gameObject.transform);
         //   closest.gameObject.transform.root.gameObject.GetComponent<EnemyHP>().DooDamage(damage);
          //  lineRenderer.SetPosition(0, LaserPlacestatic.position);
            for(int i = 0; i < enemies.Count; i++) 
            {
                    if (enemies[i] != null)
                enemies[i].gameObject.transform.root.gameObject.GetComponent<EnemyHP>().DooDamage(damage);
            }
            Debug.Log("KOlod DOne Tesla");
            enemies.Clear();
        }

      }
    }

}
