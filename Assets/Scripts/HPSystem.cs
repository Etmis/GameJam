using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSystem : MonoBehaviour
{
    [Header("Enemy_Setting")]
    [SerializeField]
    protected int maxHP; // p�i startu
    protected float currentHP; // jeho aktu�ln�

    private void Start()
    {
        currentHP = maxHP;
    }
    protected void DoDamage(float damage)
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