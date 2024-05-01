using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public ObjectPool<GameObject> pool;
    public GameObject aaa;

    private void Awake()
    {
        pool = new ObjectPool<GameObject>(createFunc,actionOnGet,actionOnRelease,actionOnDestroy,true,10,100);
    }

    private GameObject createFunc()
    {
        GameObject obj = Instantiate(aaa,transform);

        return obj;
    }
    private void actionOnDestroy(GameObject @object)
    {
        Destroy(@object);
    }

    private void actionOnRelease(GameObject @object)
    {
        @object.SetActive(false);
    }

    private void actionOnGet(GameObject @object)
    {
        @object.SetActive(true);
    }

    

    void Start()
    {
        pool.Get();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
