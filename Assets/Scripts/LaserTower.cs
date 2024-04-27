using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTower : Tower
{
    [SerializeField]
    protected Transform LaserPlace;
    [SerializeField]
    protected LineRenderer lineRenderer;
  
    public override void Attacks()
    {
        if (Enemies.Count > 0 && timeToFire <= 0)
        {
            StartCoroutine(DrawLineForDuration());
            StopCoroutine(DrawLineForDuration());

        }
        base.Attacks();
        
    }

    IEnumerator DrawLineForDuration()
    {
        // laser view

        lineRenderer.enabled = true;
        lineRenderer.startWidth = 0.4f;
        lineRenderer.SetPosition(0, LaserPlace.position);
        lineRenderer.SetPosition(1, Enemies[0].transform.position);

        yield return new WaitForSeconds(1.5f);

        // Vypnutí LineRenderer po uplynutí èasu duration
        lineRenderer.enabled = false;
    }

}
