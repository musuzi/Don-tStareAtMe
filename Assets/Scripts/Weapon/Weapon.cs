using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Attribute playerAttribute;
    public Attribute WeaponAdditionAttritube;

    private void Awake()
    {
        WeaponAdditionAttritube = GetComponent<Attribute>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "HealthController")
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
