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
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Vypis enterTrigger");
    }
    public void Attack() {

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range);

        GameObject closestN = null;
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
            RotateHeadofTower.LookAt(closestN.gameObject.transform.root.gameObject.transform);
            closestN.gameObject.transform.root.gameObject.GetComponent<EnemyHP>().DoDamage(damage);
        }

    }
   public void Sell() 
    {
        Money.Instance.Add((int)Math.Round((currentPrice / 100) * 60)); // 60 % of full price
        Destroy(gameObject);
    }
}
