using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Tower : MonoBehaviour
{
    [Header("Properties of Tower")]
    [SerializeField]
    protected int range;
    [SerializeField]
    protected float fire_Rate;
    [SerializeField]
    protected float damage;
    [SerializeField]
    protected float coolDown;
    [SerializeField]
    protected int price;
    [SerializeField]
    protected int upgradePrice;
    protected float currentPrice;
    [SerializeField]
    protected Transform RotateHeadofTower;
    [SerializeField]
    protected Transform RangeTransform;
    protected float timeToFire;
   


    protected List<EnemyHP> Enemies = new List<EnemyHP>();

    public void Start()
    {
        RangeTransform.localScale = new Vector3(range/2,0.001f,range/2);
    }
    public void Upgrade() 
    {
        if (Money.Instance.CurrentMoney >= upgradePrice) 
        {
        Money.Instance.Remove(upgradePrice);
        }
    }

    private void Update()
    {
        timeToFire -= Time.deltaTime;
        Attacks();
    }
   
    public void AddAttackList(EnemyHP enemy) {
        Enemies.Add(enemy);
      

    }
    public void RemoveAttackList(EnemyHP enemy)
    {
        Enemies.Remove(enemy);



    }
    public virtual void Attacks()
    {
       if(Enemies.Count > 0 && timeToFire <=0)
        {
            // laser view
            
            timeToFire = fire_Rate;
            Enemies[0].DooDamage(damage);
            if (Enemies[0].currentHP - damage <= 0) {
                Enemies.RemoveAt(0);
            }
        }
    }
    public void Sell() 
    {
        Money.Instance.Add((int)Math.Round((currentPrice / 100) * 60)); // 60 % of full price
        Destroy(gameObject);
    }
}
