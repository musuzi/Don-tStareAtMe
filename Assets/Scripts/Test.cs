using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Test : MonoBehaviour
{
    public TalentData talentData;

    public Attribute playerAttributer;

    private void Awake()
    {
        playerAttributer = GameObject.Find("Player").GetComponent<Attribute>();
    }

    public void test1()
    {
        if (playerAttributer != null) 
        {
            playerAttributer.AttributeTalentAdd(talentData);
        }
    }
}
