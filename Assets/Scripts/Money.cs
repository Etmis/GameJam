using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Money
{
    private static Money instance;
    //prefs Money
    public static Money Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Money();
            }
            return instance;
        }
    }

    private int _money;
    public int CurrentMoney => _money;

    private void Start()
    {
       
    }


    public void ResetMoney()
    {
        _money = 0;
    }

    public void Remove(int value)
    {
        _money -= value;
    }

    public void Add(int value)
    {
        _money += value;
    }

}
