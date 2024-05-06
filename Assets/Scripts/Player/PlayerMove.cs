using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool isMoveAble;

    private Attribute playerAttribute;
    private Rigidbody2D rb;

    public float Move_x;
    public float Move_y;
    private void Awake()
    {
        playerAttribute = GetComponent<Attribute>();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move_x = Input.GetAxis("Horizontal");
        Move_y = Input.GetAxis("Vertical");
        Vector2 Direction = new Vector2(Move_x, Move_y).normalized;
        Vector2 newPosition = rb.position + Direction * playerAttribute.Speed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }
}
