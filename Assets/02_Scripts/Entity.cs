using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Stats
{
    [HideInInspector] public float HP;
    [HideInInspector] public float MP;
}

public abstract class Entity : MonoBehaviour
{
    private Stats stats;    //캐릭터 정보
    public Entity target;  //공격 대상

    public float HP
    {
        set => stats.HP = Mathf.Clamp(value, 0, MaxHP);
        get => stats.HP;
    }

    public float MP
    {
        set => stats.MP = Mathf.Clamp(value, 0, MaxMP);
        get => stats.MP;
    }

    public abstract float MaxHP { get; } //최대 체력
    public abstract float HPRecovery { get; } //초당 채력 회복량
    public abstract float MaxMP { get; } //최대 마력
    public abstract float MPRecovery { get; } //초당 마력 회복량

    protected void SetUp()
    {
        HP = MaxHP;
        MP = MaxMP;

        StartCoroutine("Recovery");
    }

    protected IEnumerator Recovery()
    {
        while(true)
        {
            if (HP < MaxHP) HP += HPRecovery; //초당 체력 회복
            if (MP < MaxMP) MP += MPRecovery; //초당 마나 회복

            yield return new WaitForSeconds(1);
        }
    }


    //상대방을 공격할 때 상대방의 TakeDamage호출
    //매개변수 damage는 본인 공격력
    public abstract void TakeDamage(float damage);
}

