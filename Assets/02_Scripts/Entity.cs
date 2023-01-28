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
    private Stats stats;    //ĳ���� ����
    public Entity target;  //���� ���

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

    public abstract float MaxHP { get; } //�ִ� ü��
    public abstract float HPRecovery { get; } //�ʴ� ä�� ȸ����
    public abstract float MaxMP { get; } //�ִ� ����
    public abstract float MPRecovery { get; } //�ʴ� ���� ȸ����

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
            if (HP < MaxHP) HP += HPRecovery; //�ʴ� ü�� ȸ��
            if (MP < MaxMP) MP += MPRecovery; //�ʴ� ���� ȸ��

            yield return new WaitForSeconds(1);
        }
    }


    //������ ������ �� ������ TakeDamageȣ��
    //�Ű����� damage�� ���� ���ݷ�
    public abstract void TakeDamage(float damage);
}

