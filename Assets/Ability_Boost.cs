using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_Boost : Hero_Abilities
{
    [SerializeField]
    private int boostPercentage;
    [SerializeField]
    private Hero playerMove;

    private float boostAsPercent;

    private void Start()
    {
        playerMove = GetComponent<Hero>();
        boostAsPercent = (100 + boostPercentage) / 100;
    }
    
    void Update()
    {
        if (Time.time >= abilityTimer && Input.GetKeyDown(KeyCode.B))
        {
            AbilityEffect();
            abilityTimer = Time.time + coolDown;
        }
    }

    private void AbilityEffect()
        {
            playerMove.Boost(boostAsPercent);
            Invoke("ResetAbility", duration);
        }
    private void ResetAbility()
    {
        playerMove.ResetBoost(boostAsPercent);
    }
    
}
