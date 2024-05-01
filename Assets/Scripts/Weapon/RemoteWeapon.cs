using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteWeapon : MonoBehaviour
{
    public Attribute playerAttribute;
    public Attribute WeaponAdditionAttritube;
    public Animator animator;

    public GameObject weaponBullet;
    public float fireFrequency;

    [SerializeField] protected bool canFire;
    [SerializeField] protected float canFireCounter;
    private void Awake()
    {
        playerAttribute = GameObject.Find("Player").gameObject.GetComponent<Attribute>();
        WeaponAdditionAttritube = GetComponent<Attribute>();

        playerAttribute.AttributeAdd(WeaponAdditionAttritube);

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CountCanFire();
    }

    private void OnDestroy()
    {
        playerAttribute.AttributeMinus(WeaponAdditionAttritube);
    }

    public void Attack()
    {
        Debug.Log("ATTACK");
        if(canFire) 
        {
            if(fireFrequency == 0)
            {
                canFireCounter = 0;
            }
            else
            {
                canFireCounter = 1 / fireFrequency;
            }
            canFire = false;
            Instantiate(weaponBullet, transform.position, transform.rotation);
        }

        if(animator)
        {
            animator.SetTrigger("Attack");
            
        }
        else
        {
            Debug.Log("animator missing!");
        }
    }

    public void CountCanFire()
    {
        if (!canFire)
        {
            canFireCounter -= Time.deltaTime;

            if (canFireCounter <= 0)
            {
                canFire = true;
                canFireCounter = 0;
            }
        }
    }
}
