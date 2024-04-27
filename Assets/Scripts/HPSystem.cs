using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSystem : MonoBehaviour
{
    [Header("Enemy_Setting")]
    [SerializeField]
    protected int maxHP; // pøi startu
    protected float currentHP; // jeho aktuální

    private void Start()
    {
        currentHP = maxHP;
    }
    protected void DoDamage(float damage)
    {
        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log(damage);
            currentHP -= damage;
        }

    }

}