using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTower : Tower
{
    [SerializeField]
    protected Transform LaserPlace;
    [SerializeField]
    protected Transform LaserPlacestatic;
    [SerializeField]
    protected LineRenderer lineRenderer;
  
    public override void Attacks()
    {

        if (Enemies.Count > 0 && timeToFire <= 0)
        {
            lineRenderer.SetPosition(0, LaserPlacestatic.position);
            StartCoroutine(DrawLineForDuration());
            StopCoroutine(DrawLineForDuration());

        }
        base.Attacks();
        
    }

    IEnumerator DrawLineForDuration()
    {
        // laser view

        lineRenderer.enabled = true;
        lineRenderer.startWidth = 1f;
        lineRenderer.SetPosition(1, LaserPlace.position);
        lineRenderer.SetPosition(2, Enemies[0].transform.position);

        yield return new WaitForSeconds(1f);

        // Vypnut� LineRenderer po uplynut� �asu duration
        lineRenderer.enabled = false;
    }

}
