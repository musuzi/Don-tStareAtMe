using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTriggerAttack : MonoBehaviour
{
    [SerializeField] private Attribute characterAttribute;

    private void Awake()
    {
        characterAttribute = transform.GetComponentInParent<Attribute>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "HealthController")
        {
            //
        }
    }
}
