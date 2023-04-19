using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class vida : MonoBehaviour
{
    int minHP = 0;
    int maxHP = 10;
    public int currentHP;


    public int CurrentHP
    {
        get => currentHP;
        //set => currentHP = value;
    }

    public Action HPChanged;

    void Awake()
    {
        currentHP = maxHP;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ReduceHP(float damage)
    {
        currentHP = currentHP - (int)damage;
        UpdateHP();
        Debug.Log(currentHP);
    }

    public void CureHealth()
    {
        currentHP = maxHP;
        UpdateHP();
        Debug.Log(currentHP);
    }

    public void UpdateHP()
    {
        HPChanged?.Invoke();
    }

}

