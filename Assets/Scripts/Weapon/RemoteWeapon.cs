using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class RemoteWeapon : MonoBehaviour
{
    public GameObject weaponBullet;//�����ӵ�
    [Space]
    public float fireFrequency;//����Ƶ��
    [Space]
    [SerializeField] protected bool canFire;
    [SerializeField] protected float canFireCounter;
    [Space]
    public Attribute playerAttribute;//�������
    public Attribute WeaponAdditionAttritube;//�����ӳ�����
    public Animator animator;
    public PlayerDirection playerDirection;//��ȡ�����귽��

   public ObjectPool<GameObject> BulletsPool;//�����
    private GameObject poolParent;//����ظ���


    private void Awake()
    {
        //getcomponent
        playerAttribute = GameObject.Find("Player").gameObject.GetComponent<Attribute>();
        playerDirection = GameObject.Find("Player").gameObject.GetComponent<PlayerDirection>();

        WeaponAdditionAttritube = GetComponent<Attribute>();
        animator = GetComponent<Animator>();
        playerAttribute.AttributeAdd(WeaponAdditionAttritube);
        
        //��������ظ���
        poolParent = new GameObject("poolParent");
        //���������
        BulletsPool = new ObjectPool<GameObject>(createFunc,actionOnGet,actionOnRelease,actionOnDestroy,true,10,1000);
    }

    #region Pool����
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
