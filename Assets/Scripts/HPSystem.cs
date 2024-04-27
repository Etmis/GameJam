using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSystem : MonoBehaviour
{
    [Header("Enemy_Setting")]
    [SerializeField]
    protected int maxHP; // p�i startu
    public float currentHP; // jeho aktu�ln�

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
            currentHP -= damage;
        }

    }

}