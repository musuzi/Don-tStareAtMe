using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TalentData", menuName = "data/TalentData")]

public class TalentData : ScriptableObject
{
    [Header("天赋")]
    public string talentName;
    public string talentDescription;
    public int talentID;
    public TalentType talentType;

    public Sprite talentSprite;


    [Header("天赋加成")]
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

    public enum TalentType
    {
        a,
        b,
        c,
    }
}
