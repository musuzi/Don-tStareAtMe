using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrow : MonoBehaviour
{
    // Start is called before the first frame update
    private Attribute at;
    public static int  level;


    private void Awake()
    {
        at=GetComponent<Attribute>();
    }
}
