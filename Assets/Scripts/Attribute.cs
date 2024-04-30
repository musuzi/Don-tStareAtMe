using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attribute : MonoBehaviour
{
    [Header("ÊôÐÔ")]
    public float MaxHealth;
    public float Health;

    public float MaxSan;
    public float San;

    public float PhyDamage;
    public float MaDamage;

    public float MissRate;
    public float PhyDenfend;
    public float MaDenfend;

    public float Speed;

    public float CriticalRate;
    public float CriticalDamageMagnification;

    public float invulnerableDuration;

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
}
