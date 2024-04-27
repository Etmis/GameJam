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
        Debug.Log("vOLÁM OVERLAY");
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
                    closestN = collider.gameObject;
                    closestRange = vzdalenost;
                }
            }
        }

        if (closestN != null)
        {
            lineRenderer.SetPosition(1, LaserPlace.transform.position);

            lineRenderer.SetPosition(2, closestN.transform.position);
            closestN.active = false;

            enemies.Add(closestN);
            // CanonHead.LookAt(closestN.gameObject.transform.root.gameObject.transform);
        //    closestN.gameObject.transform.root.gameObject.GetComponent<EnemyHP>().DooDamage(damage);
            StartCoroutine(DrawLineForDuration(closestN));
        }
    }

    IEnumerator DrawLineForDuration(GameObject closest)
    {

        lineRenderer.enabled = true;
        lineRenderer.startWidth = 1f;
        lineRenderer.SetPosition(1, closest.transform.position);
        yield return new WaitForSeconds(1f);

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
                    closest = collider.gameObject;
                    closestRange = vzdalenost;
                }
            }
        }

        if (closest != null)
        {
            lineRenderer.SetPosition(2, closest.transform.position);
            closest.active = false;
            enemies.Add(closest);
            // CanonHead.LookAt(closestN.gameObject.transform.root.gameObject.transform);
       //     closest.gameObject.transform.root.gameObject.GetComponent<EnemyHP>().DooDamage(damage);
      //      lineRenderer.SetPosition(0, LaserPlacestatic.position);
            StartCoroutine(DrawLineForDuration(closest));
        }

        StartCoroutine(DrawLineForDurationTwo(closest));
        lineRenderer.enabled = false;
    }

    private IEnumerator DrawLineForDurationTwo(GameObject closest)
    {
        lineRenderer.enabled = true;
        lineRenderer.startWidth = 1f;
        lineRenderer.SetPosition(1, closest.transform.position);
        yield return new WaitForSeconds(1f);

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
                    closest = collider.gameObject;
                    closestRange = vzdalenost;
                }
            }
        }

        if (closest != null)
        {

            lineRenderer.SetPosition(2, closest.transform.position);

            closest.active = false;

            enemies.Add(closest);
            // CanonHead.LookAt(closestN.gameObject.transform.root.gameObject.transform);
         //   closest.gameObject.transform.root.gameObject.GetComponent<EnemyHP>().DooDamage(damage);
          //  lineRenderer.SetPosition(0, LaserPlacestatic.position);
            StartCoroutine(DrawLineForDuration(closest));
            for(int i = 0; i < enemies.Count; i++) 
            {
               // enemies[i].gameObject.transform.root.gameObject.GetComponent<EnemyHP>().DooDamage(damage);
            }
            enemies.Clear();
        }
    }
}
