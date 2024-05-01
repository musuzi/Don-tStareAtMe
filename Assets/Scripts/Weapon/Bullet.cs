using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    public float existTime;
    public float FlySpeed;
    public Vector2 fireDir;
    public Attribute playerAttribute;

    public Rigidbody2D rigidbody2;
    public ObjectPool<GameObject> bulletsPool;

    public void Awake()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rigidbody2.velocity = FlySpeed * fireDir;
    }

    IEnumerator ReleaseCoroutine()
    {
        yield return new WaitForSeconds(existTime);
        bulletsPool.Release(gameObject);
    }

    public void OnReleaseCoroutineStar()
    {
        StartCoroutine(ReleaseCoroutine());
    }
}
