using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Attribute playerAttribute;
    public Attribute WeaponAdditionAttritube;
    public Animator animator;

    private  void Awake()
    {
        playerAttribute = GameObject.Find("Player").gameObject.GetComponent<Attribute>();
        WeaponAdditionAttritube = GetComponent<Attribute>();

        playerAttribute.AttributeAdd(WeaponAdditionAttritube);

        animator = GetComponent<Animator>();
    }
    private void OnDestroy()
    {
        playerAttribute.AttributeMinus(WeaponAdditionAttritube);
    }

    public virtual void Attack()
    {
        if (animator)
        {
            animator.SetTrigger("Attack");

        }
        else
        {
            Debug.Log("animator missing!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "HealthController" && collision.transform.parent.tag == "Enemy")
        {
            Debug.Log("TAKEDAMAGE!");
            HealthControll victimHealthControll = collision.gameObject.GetComponent<HealthControll>();

            if(victimHealthControll != null) 
            {
                victimHealthControll.TakeDamage(playerAttribute);
            }
        }
    }
}
