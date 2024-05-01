using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{   
    public Vector2 Movement {  get; set; }
    private Attribute at;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private void Awake()
    {
        at = GetComponent<Attribute>();
        rb= GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if (Movement.magnitude > 0.1f && at.Speed >= 0)
        {
            rb.velocity=Movement*at.Speed;
            if (Movement.x < 0)
            {
                sr.flipX = false;
            }
            if (Movement.x > 0)
            {
                sr.flipX = true;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    }

