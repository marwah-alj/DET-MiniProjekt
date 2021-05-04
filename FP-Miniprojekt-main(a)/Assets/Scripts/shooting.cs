using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{

    public Transform gunPoint;
    public Transform firePoint;

    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;

    public GameObject weaponPrefab1;
    public GameObject weaponPrefab2;

    bool weapon1_equiped = false;
    bool weapon2_equiped = false;

    public float bulletForce_weapon1 = 15f;
    public float bulletForce_weapon2 = 30f;

    public int maxAmmo_weapon1 = 10;
    public int maxAmmo_weapon2 = 4;

    private int currentAmmo_weapon1;
    private int currentAmmo_weapon2;

    public float reloadTime_weapon1 = 1f;
    public float reloadTime_weapon2 = 3f;

    private bool isReloading = false;


    void Start()
    {
        currentAmmo_weapon1 = maxAmmo_weapon1;
        currentAmmo_weapon1 = maxAmmo_weapon2;
        weapon1_equiped = true;
        swapWeapon();
    }

    // Update is called once per frame
    void Update()
    {

        if (isReloading)
        {
            return;
        }

        if(weapon1_equiped == true && currentAmmo_weapon1 <= 0)
        {
            StartCoroutine(reloadWeapon1());
            return;
        }

        if (weapon2_equiped == true && currentAmmo_weapon2 <= 0)
        {
            StartCoroutine(reloadWeapon2());
            return;
        }

        if (Input.GetButtonDown("Reload"))
        {
            if (weapon1_equiped)
            {
                StartCoroutine(reloadWeapon1());
            }
            else
            {
                StartCoroutine(reloadWeapon2());
            }
            
            return;
        }

        if (Input.GetButtonDown("Fire2") && weapon1_equiped==true)
        {
            weapon1_equiped = false;
            weapon2_equiped = true;
            swapWeapon();
        }
        else if (Input.GetButtonDown("Fire2") && weapon2_equiped == true)
        {
            weapon1_equiped = true;
            weapon2_equiped = false;
            swapWeapon();
        }

        if (Input.GetButtonDown("Fire1") && weapon1_equiped == true)
        {
            shoot_weapon1();
        }
        else if (Input.GetButtonDown("Fire1") && weapon2_equiped == true)
        {
            shoot_weapon2();
        }

    }

    IEnumerator reloadWeapon1()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime_weapon1);
        currentAmmo_weapon1 = maxAmmo_weapon1;
        isReloading = false;
    }

    IEnumerator reloadWeapon2()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime_weapon2);
        currentAmmo_weapon2 = maxAmmo_weapon2;
        isReloading = false;
    }

    void swapWeapon()
    {

        if (weapon1_equiped == true)
        {
            if(gunPoint.transform.childCount != 0)
            {
                Destroy(gunPoint.transform.GetChild(0).gameObject);
            }
            GameObject weapon1 = Instantiate(weaponPrefab1, gunPoint.position, gunPoint.rotation);
            weapon1.transform.SetParent(gunPoint);
        }
        else if (weapon2_equiped == true)
        {
            if (gunPoint.transform.childCount != 0)
            {
                Destroy(gunPoint.transform.GetChild(0).gameObject);
            }
            GameObject weapon2 = Instantiate(weaponPrefab2, gunPoint.position, gunPoint.rotation);
            weapon2.transform.SetParent(gunPoint);
        }
    }

    void shoot_weapon1()
    {
        GameObject bullet = Instantiate(bulletPrefab1, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce_weapon1, ForceMode2D.Impulse);
        currentAmmo_weapon1--;
    }

    void shoot_weapon2()
    {
        GameObject bullet = Instantiate(bulletPrefab2, firePoint.position, firePoint.rotation);
        bullet.transform.Rotate(0, 0, 90);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce_weapon2, ForceMode2D.Impulse);
        currentAmmo_weapon2--;
    }
}
