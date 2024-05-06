using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthControll : MonoBehaviour
{
    public Attribute characterAttribute;

    private void Awake()
    {
        characterAttribute = this.GetComponentInParent<Attribute>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterAttribute.invulnerable)
        {
            characterAttribute.invulnerableCounter -= Time.deltaTime;
            if (characterAttribute.invulnerableCounter <= 0)
            {
                characterAttribute.invulnerable = false;
            }
        }
        if(characterAttribute.Health<=0&& transform.parent.gameObject.tag=="Player" )
        {
            Debug.Log("PlayerDie");
        }
        if (characterAttribute.Health <= 0 && transform.parent.gameObject.tag == "Enemy")
        {
            Debug.Log("EnemyDie");
        }
    }

    public void TakeDamage(Attribute attacker)
    {
        if(characterAttribute.MissRate >0)
        {
            if(Probability.SetProbabilityEventSingle(characterAttribute.MissRate))
            {
                Debug.Log("miss!!");
                TriggerInvulnerable();
                return;
            }
        }

        if(characterAttribute.invulnerable)
        {
            return;
        }

        float Damage = Calculation.calculateFinalPhyDamage(attacker, characterAttribute);

        if(characterAttribute.Health - Damage >= 0)
        {
            characterAttribute.Health -= Damage;
            TriggerInvulnerable();
        }
        else
        {
            characterAttribute.Health = 0;
        }
    }

    private void TriggerInvulnerable()
    {
        if (!characterAttribute.invulnerable)
        {
            characterAttribute.invulnerable = true;
            characterAttribute.invulnerableCounter = characterAttribute.invulnerableDuration;
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Weapon" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Bullet")
    //    {
    //        Attribute attacker = collision.gameObject.GetComponent<Attribute>();
    //        if (attacker != null)
    //            TakeDamage(attacker);
    //    }
    //}
}
