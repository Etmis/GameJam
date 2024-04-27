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
    protected Transform RangeTransform;
    protected float timeToFire;



    protected GameObject closestN = null;

    public void Start()
    {
        RangeTransform.localScale = new Vector3(range,0.001f,range);
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
        if (timeToFire < 0) { 
        Attacks();
        }
    }
   

    
    public virtual void Attacks()
    {
        
        timeToFire = fire_Rate;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range / 2);

         closestN = null;
        float closestRange = Mathf.Infinity;

        for (int i = 0; i < hitColliders.Length; i++)
        {

            Collider collider = hitColliders[i];
            if (collider.gameObject.transform.root.gameObject.GetComponent<EnemyHP>() != null)
            {
                Vector3 poziceNepriatele = collider.transform.position;

                float vzdalenost = Vector3.Distance(transform.position, poziceNepriatele);

                if (vzdalenost < closestRange)
                {
                    closestN = collider.gameObject;
                    closestRange = vzdalenost;
                }
            }
        }

        if (closestN != null)
        {
           // CanonHead.LookAt(closestN.gameObject.transform.root.gameObject.transform);
            closestN.gameObject.transform.root.gameObject.GetComponent<EnemyHP>().DooDamage(damage);
        }
    }

    public void Sell() 
    {
        Money.Instance.Add((int)Math.Round((currentPrice / 100) * 60)); // 60 % of full price
        Destroy(gameObject);
    }
}

