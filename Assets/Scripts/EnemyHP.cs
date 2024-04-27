using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : HPSystem
{
    [Header("Reawrd for user")]
    [SerializeField]
    private int MoneyForKill;

   
    public void DooDamage(float damage)
    {
        if ((currentHP - damage) <= 0) { 
            Money.Instance.Add(MoneyForKill);


        }
        base.DoDamage(damage);
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