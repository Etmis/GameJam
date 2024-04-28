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
        base.Attacks();
        if (closestN != null)
        {
            lineRenderer.positionCount = 3;
            lineRenderer.SetPosition(0, LaserPlacestatic.position);
            StartCoroutine(DrawLineForDuration());
            StopCoroutine(DrawLineForDuration());
        }
        
        
    }

    IEnumerator DrawLineForDuration()
    {
        // laser view

        lineRenderer.enabled = true;
        lineRenderer.startWidth = 1f;
        lineRenderer.SetPosition(1, LaserPlace.position);
        lineRenderer.SetPosition(2, closestN.transform.position);

        yield return new WaitForSeconds(1f);

        // Vypnutí LineRenderer po uplynutí èasu duration
        lineRenderer.enabled = false;
    }

}
