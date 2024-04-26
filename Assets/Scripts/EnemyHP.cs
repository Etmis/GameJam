using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : HPSystem
{
    [Header("Reawrd for user")]
    [SerializeField]
    private int MoneyForKill;
    public void DoDamage(float damage)
    {
        if ((currentHP - damage) <= 0)
            Money.Instance.Add(MoneyForKill);
        base.DoDamage(damage);
        LaserTower laserTower = new LaserTower();
        laserTower.Attack();
    }

    private void Update()
    {
        //testing this all
        if (Input.GetMouseButtonDown(0))
        {
            PossibleToHitEnemy();
            Debug.Log("hittiing");
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
    }

}