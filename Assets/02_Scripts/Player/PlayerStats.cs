using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Entity
{
    [SerializeField] float hpRecovery;
    [SerializeField] float maxMP;
    [SerializeField] float mpRecovery;

    private void Awake()
    {
        base.SetUp();
    }

    //기본 체력 + 스탯 보너스 + 버프 등과 같이 계산
    public override float MaxHP => MaxHPBasic + MaxHPAttrBonus;
    //100 + 현재 레벨 * 30
    public float MaxHPBasic => 100 + 1 * 30;
    //힘 * 10
    public float MaxHPAttrBonus => 10 * 10;

    public override float HPRecovery => hpRecovery;
    public override float MaxMP => maxMP;
    public override float MPRecovery => mpRecovery;

    public override void TakeDamage(float damage)
    {
        HP -= damage;
    }
}
