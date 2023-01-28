using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : Entity
{
    [SerializeField] float maxHP;
    [SerializeField] float hpRecovery;
    [SerializeField] float maxMP;
    [SerializeField] float mpRecovery;


    private void Awake()
    {
        base.SetUp();
    }

    public override float MaxHP => maxHP;
    public override float HPRecovery => hpRecovery;
    public override float MaxMP => maxMP;
    public override float MPRecovery => mpRecovery;

    public override void TakeDamage(float damage)
    {
        HP -= damage;
    }
}
