using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vidaManager : MonoBehaviour
{
    public Slider HPslider;
    public PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        if(playerHealth != null)
        UpdateUI();
    }
     void OnEnable()
    {
        if(playerHealth != null)
        
        playerHealth.HPChanged += OnHPChange;
        UpdateUI();
        
    }

    void OnDisable()
    {
        if(playerHealth != null)
        
        playerHealth.HPChanged -= OnHPChange;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnHPChange()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        if(playerHealth == null) return;

        if(HPslider != null)
        {
            HPslider.value = playerHealth.currentHP;
        }
    }

        void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("bullet"))
        {
            playerHealth.ReduceHP(1);
        }
    }
}
