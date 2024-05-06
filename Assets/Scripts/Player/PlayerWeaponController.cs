using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public List<GameObject> weaponsList = new List<GameObject>();
    [SerializeField]private GameObject currentWeapon;
    [Space]
    private PlayerDirection playerDirection;


    private void Awake()
    {
        playerDirection = transform.parent.gameObject.GetComponent<PlayerDirection>();
    }

    // Update is called once per frame
    void Update()
    {
        Controllrotate();
        if(Input.GetMouseButtonDown(0)) 
        {
            PlayerAttack();
        }
    }

    public void PlayerAttack()
    {
        if (currentWeapon != null && transform.GetChild(0) != null) 
        {
            if(transform.GetChild(0).GetComponent<Weapon>() != null)
                transform.GetChild(0).GetComponent<Weapon>().Attack();
            else if(transform.GetChild(0).GetComponent<RemoteWeapon>() != null)
                transform.GetChild(0).GetComponent<RemoteWeapon>().Attack();
        }
    }

    private void Controllrotate()
    {
        
        float angle = Vector3.SignedAngle(Vector3.up, playerDirection.playerMousePoint, Vector3.forward);//以向上为正方向
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }

    private void CurrentWeaponSummon()
    {
        if(transform.childCount != 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }

        if(currentWeapon != null)
            Instantiate(currentWeapon, this.transform, false);
    }

    public void ChangeCurrentWeapon()
    {
        if (weaponsList[0] == null && weaponsList[1] == null)
        {
            Debug.Log("NONE");
            return;
        }
        Debug.Log("switch");
        if (currentWeapon == null)
        {
            currentWeapon = weaponsList[0];
            CurrentWeaponSummon();
            return;
        }
        if (currentWeapon == weaponsList[weaponsList.Count - 1])
        {
            currentWeapon = weaponsList[0];
            CurrentWeaponSummon();
        }
        else
        {
            for (int i = 0; i < weaponsList.Count; i++)
            {
                if (currentWeapon == weaponsList[i])
                {
                    currentWeapon = weaponsList[i + 1];
                    CurrentWeaponSummon();
                    break;
                }
            }
        }
    }

    public void GetNewWeapon(GameObject newWeapon)
    {
        GameObject oldWeapon = currentWeapon;
        
        for(int i = 0;i < weaponsList.Count;i++)
        {
            if(oldWeapon == weaponsList[i])
            {
                weaponsList[i] = newWeapon;
                currentWeapon = newWeapon;
                CurrentWeaponSummon();
                return;
            }
        }
    }
}
