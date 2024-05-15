using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrow : MonoBehaviour
{
    public static int  Level;
    private Attribute EnemyAttribute;

    public float HpAddition;
    public float SanAddition;
    public float PhyDamageAddition;
    public float MaDamageAddition;
    public float PhyDenfendAddition;
    public float MaDenfendAddition;

    private int level;
    private void Awake()
    {
        Level =level= 0;
        EnemyAttribute = GetComponentInParent<Attribute>();
    }

    private void Update()
    {
        
        Level = (FindES.TotalEnemiesDied) / 2;
        if (level < Level) 
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        EnemyAttribute.MaxHealth += Level * HpAddition;
        EnemyAttribute.Health=EnemyAttribute.MaxHealth;
        EnemyAttribute.MaxSan += Level * SanAddition;
        EnemyAttribute.San=EnemyAttribute.MaxSan;
        EnemyAttribute.PhyDamage += Level * PhyDamageAddition;
        EnemyAttribute.MaDamage += Level * MaDamageAddition;
        EnemyAttribute.PhyDenfend += Level * PhyDenfendAddition;
        EnemyAttribute.MaDenfend += Level * MaDenfendAddition;
        level = Level;
    }


}
