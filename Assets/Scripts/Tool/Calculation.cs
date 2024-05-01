using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculation
{
    public static float calculateFinalPhyDamage(Attribute attacker,Attribute victim)
    {
        float finalPhyDamage;
        finalPhyDamage = 0;

        float basicPhyDamage;
        basicPhyDamage = attacker.PhyDamage - victim.PhyDenfend;

        if(basicPhyDamage <= 0)
        {
            basicPhyDamage = 1;
        }

        if(Probability.SetProbabilityEventSingle(attacker.CriticalRate))
        {
            finalPhyDamage = basicPhyDamage * attacker.CriticalDamageMagnification;
        }
        else
        {
            finalPhyDamage = basicPhyDamage;
        }

        return finalPhyDamage;
    }

    public static float calculateFinalMaDamage(Attribute attacker, Attribute victim)
    {
        float finalMaDamage;
        finalMaDamage = 0;

        float basicMaDamage;
        basicMaDamage = attacker.MaDamage - victim.MaDenfend;

        if (basicMaDamage <= 0)
        {
            basicMaDamage = 1;
        }

        if (Probability.SetProbabilityEventSingle(attacker.CriticalRate))
        {
            finalMaDamage = basicMaDamage * attacker.CriticalDamageMagnification;
        }
        else
        {
            finalMaDamage = basicMaDamage;
        }

        return finalMaDamage;
    }
}
