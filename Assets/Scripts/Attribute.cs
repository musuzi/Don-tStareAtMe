using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attribute : MonoBehaviour
{
    [Header("����")]
    [Header("����ֵ")]
    public float MaxHealth;
    public float Health;
    [Header( "����ֵ")]
    public float MaxSan;
    public float San;
    [Header("�˺�")]
    public float PhyDamage;
    public float MaDamage;
    [Header("�����������ֵ")]
    public float MissRate;
    public float PhyDenfend;
    public float MaDenfend;
    [Header("�ٶ�")]
    /*[Range(0f,30f)]*/public float Speed;
    [Header("����")]
    public float CriticalRate;
    public float CriticalDamageMagnification;
    [Header("�޵�֡ʱ��")]
    public float invulnerableDuration;
    [Space]
    public float MaxinvulnerableDuration;
    public float invulnerableCounter;
    public bool invulnerable;
private void Awake()
    {
        Health = MaxHealth;
        San = MaxSan;
    }
    public void AttributeAdd(Attribute attributeAddition)
    {
        MaxHealth += attributeAddition.MaxHealth;
        Health += attributeAddition.Health;

        MaxSan += attributeAddition.MaxSan;
        San += attributeAddition.San;

        PhyDamage += attributeAddition.PhyDamage;
        MaDamage += attributeAddition.MaDamage;

        MissRate += attributeAddition.MissRate;
        PhyDenfend += attributeAddition.PhyDenfend;
        MaDenfend += attributeAddition.MaDenfend;

        Speed += attributeAddition.Speed;

        CriticalRate += attributeAddition.CriticalRate;
        CriticalDamageMagnification += attributeAddition.CriticalDamageMagnification;

        invulnerableDuration += attributeAddition.invulnerableDuration;
    }

    public void AttributeTalentAdd(TalentData attributeAddition)
    {
        MaxHealth += attributeAddition.MaxHealth;
        Health += attributeAddition.Health;

        MaxSan += attributeAddition.MaxSan;
        San += attributeAddition.San;

        PhyDamage += attributeAddition.PhyDamage;
        MaDamage += attributeAddition.MaDamage;

        MissRate += attributeAddition.MissRate;
        PhyDenfend += attributeAddition.PhyDenfend;
        MaDenfend += attributeAddition.MaDenfend;

        Speed += attributeAddition.Speed;

        CriticalRate += attributeAddition.CriticalRate;
        CriticalDamageMagnification += attributeAddition.CriticalDamageMagnification;

        invulnerableDuration += attributeAddition.invulnerableDuration;
    }

    public void zero()
    {

    }

    public void AttributeMinus(Attribute attributeDecrease) 
    {
        MaxHealth -= attributeDecrease.MaxHealth;
        if(Health > MaxHealth)
        {
            Health = MaxHealth;
        }

        MaxSan -= attributeDecrease.MaxSan;
        if(San > MaxSan)
        {
            San = MaxSan;
        }

        PhyDamage -= attributeDecrease.PhyDamage;
        MaDamage -= attributeDecrease.MaDamage;

        MissRate -= attributeDecrease.MissRate;
        PhyDenfend -= attributeDecrease.PhyDenfend;
        MaDenfend -= attributeDecrease.MaDenfend;

        Speed -= attributeDecrease.Speed;

        CriticalRate -= attributeDecrease.CriticalRate;
        CriticalDamageMagnification -= attributeDecrease.CriticalDamageMagnification;

        invulnerableDuration -= attributeDecrease.invulnerableDuration;
    }

    public void AttributeTalentMinus(TalentData attributeDecrease)
    {
        MaxHealth -= attributeDecrease.MaxHealth;
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }

        MaxSan -= attributeDecrease.MaxSan;
        if (San > MaxSan)
        {
            San = MaxSan;
        }

        PhyDamage -= attributeDecrease.PhyDamage;
        MaDamage -= attributeDecrease.MaDamage;

        MissRate -= attributeDecrease.MissRate;
        PhyDenfend -= attributeDecrease.PhyDenfend;
        MaDenfend -= attributeDecrease.MaDenfend;

        Speed -= attributeDecrease.Speed;

        CriticalRate -= attributeDecrease.CriticalRate;
        CriticalDamageMagnification -= attributeDecrease.CriticalDamageMagnification;

        invulnerableDuration -= attributeDecrease.invulnerableDuration;
    }

    private void ObjectDie()
    {
        if(Health<=0)
        {
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        ObjectDie();
    }
}
