using System;
using System.Collections;
using System.Collections.Generic;
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
    private float timeToFire;


    private List<EnemyHP> Enemies = new List<EnemyHP>();

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
        Debug.Log("Pøídám v seznamu");
      

    }
    public void RemoveAttackList(EnemyHP enemy)
    {
        Enemies.Remove(enemy);
        Debug.Log("Odebrán v seznamu");



    }
    public virtual void Attacks()
    {
       if(Enemies.Count > 0 && timeToFire <=0)
        {


            for(int i = 0; i < Enemies.Count; i++)
            {
                if (Enemies[i] == null)
                {
                    Enemies.RemoveAt(i);
                }
            }
            timeToFire = fire_Rate;
            Enemies[0].DooDamage(damage);
        }
    }
    public void Sell() 
    {
        Money.Instance.Add((int)Math.Round((currentPrice / 100) * 60)); // 60 % of full price
        Destroy(gameObject);
    }
}
