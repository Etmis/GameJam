using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTower : Tower
{
    [SerializeField]
    protected Transform RotateHeadofTower;


    public override void Attacks()
    {
        base.Attacks();
        if (closestN != null)
        {
            SoundManager.PlaySound("bulletTower", base.audioSource);

            RotateHeadofTower.LookAt(closestN.gameObject.transform.root.gameObject.transform);
        }
    }
}
