using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHP : HPSystem
{
    [Header("Reawrd for user")]
    [SerializeField]
    private int MoneyForKill;

    private float normalSpeed;
    private float freezeSpeed;

    private void Start()
    {
        base.Start();
        normalSpeed = GetComponent<NavMeshAgent>().speed;
        freezeSpeed = GetComponent<NavMeshAgent>().speed / 2;
    }
    public void DooDamage(float damage)
    {
        if ((currentHP - damage) <= 0) { 
            
            Money.Instance.Add(MoneyForKill);


        }
        base.DoDamage(damage);
    }

    internal void FreezeDamage(float coolDown)
    {
       
        StartCoroutine(freezing(coolDown));
        StopCoroutine(freezing(coolDown));
    }

    IEnumerator freezing(float coolDown)
    {
        GetComponent<NavMeshAgent>().speed = freezeSpeed;
        yield return new WaitForSeconds(coolDown);
        GetComponent<NavMeshAgent>().speed = normalSpeed;
       

    }
    private void Update()
    {
        
    }
    /* private void BuildLaserTower()
     {
         var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         if (Physics.Raycast(ray, out var hit))
         {
             Instantiate(TowerPrefab,hit.point,Quaternion.identity);
         }
     }
     private void PossibleToHitEnemy()
     {
         var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         if (Physics.Raycast(ray, out var hit))
         {
             var hitRootEnemyComponent = hit.collider.gameObject.transform.root.gameObject;
             if (hitRootEnemyComponent.GetComponent<EnemyHP>() != null) // root vrací nejvyšší koøen <---
             {
                 hitRootEnemyComponent.GetComponent<EnemyHP>().DoDamage(10);
             }
         }
     }*/

}