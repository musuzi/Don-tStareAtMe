using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class RemoteWeapon : MonoBehaviour
{
    public GameObject weaponBullet;//武器子弹
    [Space]
    public float fireFrequency;//攻击频率
    [Space]
    [SerializeField] protected bool canFire;
    [SerializeField] protected float canFireCounter;
    [Space]
    public Attribute playerAttribute;//玩家属性
    public Attribute WeaponAdditionAttritube;//武器加成属性
    public Animator animator;
    public PlayerDirection playerDirection;//获取玩家鼠标方向

   public ObjectPool<GameObject> BulletsPool;//对象池
    private GameObject poolParent;//对象池父级


    private void Awake()
    {
        //getcomponent
        playerAttribute = GameObject.Find("Player").gameObject.GetComponent<Attribute>();
        playerDirection = GameObject.Find("Player").gameObject.GetComponent<PlayerDirection>();

        WeaponAdditionAttritube = GetComponent<Attribute>();
        animator = GetComponent<Animator>();
        playerAttribute.AttributeAdd(WeaponAdditionAttritube);
        
        //创建对象池父级
        poolParent = new GameObject("poolParent");
        //创建对象池
        BulletsPool = new ObjectPool<GameObject>(createFunc,actionOnGet,actionOnRelease,actionOnDestroy,true,10,1000);
    }

    #region Pool参数
    protected virtual GameObject createFunc()
    {
        GameObject obj = Instantiate(weaponBullet, transform.position, transform.rotation, poolParent.transform);
        Bullet bullet = obj.GetComponent<Bullet>();
        bullet.playerAttribute = playerAttribute;
        bullet.bulletsPool = this.BulletsPool;

        return obj;
    }
    protected virtual void actionOnDestroy(GameObject obj)
    {
        Destroy(obj);
    }

    protected virtual void actionOnRelease(GameObject obj)
    {
        obj.SetActive(false);
    }

    protected virtual void actionOnGet(GameObject obj)
    {
        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
        Bullet bullet = obj.GetComponent<Bullet>();
        bullet.fireDir = playerDirection.playerMousePoint;
        bullet.OnReleaseCoroutineStar();

    }
    #endregion


    private void Update()
    {
        CountCanFire();
    }

    private void OnDestroy()
    {
        BulletsPool.Clear();
        Destroy(poolParent.gameObject);
        playerAttribute.AttributeMinus(WeaponAdditionAttritube);
    }

    public virtual void Attack()
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

            BulletsPool.Get();
            
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
