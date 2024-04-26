using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSystem : MonoBehaviour
{
    [Header("Enemy_Setting")]
    [SerializeField]
    protected int maxHP; // pøi startu
    protected int currentHP; // jeho aktuální

    private void Start()
    {
        currentHP = maxHP;
    }
    protected void DoDamage(int damage)
    {
        if (currentHP <= 0)
        {
            Debug.Log("HP pod nulu");
        }
        else
        {
            Debug.Log(damage);
            currentHP -= damage;
        }

    }

}