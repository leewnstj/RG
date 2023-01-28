using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Entity
{
    private void Awake()
    {
        base.SetUp();
    }
    //
    public override float MaxHP => MaxHPBasic + MaxHPAttrBonus;
    //100 + ÇöÀç ·¹º§ * 30
    public float MaxHPBasic => 100 + 1 * 30;
    //Èû * 10
    public float MaxHPAttrBonus => 10 * 10;

    public override float HPRecovery => 10;
    public override float MaxMP => 200;
    public override float MPRecovery => 25;

    public override void TakeDamage(float damage)
    {
        HP -= damage;
    }
}
