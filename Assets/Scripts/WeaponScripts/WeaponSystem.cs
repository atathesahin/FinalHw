using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSystem : MonoBehaviour
{
    public Transform firePoint;
    public AudioSource audioSource;
    public TextMeshProUGUI ammoText;
    //public GameObject crosshair;
    private GameObject bullet;
    public WeaponManager _weaponManager;
    private EnemyScript _enemyScript;
    private float nextTimeToFire = 1f;
    [SerializeField] private bool isAutomatic = false;
    [SerializeField] TextMeshProUGUI fireModeText;
    [SerializeField] TextMeshProUGUI weaponNameText;
    [SerializeField] private string weaponName;
    
    private bool isReloading = false;
    [SerializeField] private int maxAmmo = 30;
    private float reloadTime = 1.5f;
    [SerializeField] private int currentAmmo;
    [SerializeField] private float fireRate;
        

    private void Start()
    {
        _enemyScript = GetComponent<EnemyScript>();
        bullet = GetComponent<GameObject>();
        fireModeText = GameObject.Find("FireModeText").GetComponent<TextMeshProUGUI>();
        ammoText = GameObject.Find("AmmoText").GetComponent<TextMeshProUGUI>();
        weaponNameText = GameObject.Find("WeaponText").GetComponent<TextMeshProUGUI>();
        UpdateFireModeText();
        UpdateUI();
        WeaponName();

    }

    void Update()
    {

        ReloadWeapon();
        
        //if (Input.GetKeyDown(KeyCode.X))
        //{
            
        //isAutomatic = !isAutomatic;
            
        //UpdateFireModeText();
        //}

    }

    void Shoot()
    {
        audioSource.PlayOneShot(_weaponManager.fireSound);
        currentAmmo--;
        UpdateUI();

        /*
        RaycastHit hit;
        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit))
        {
            _enemyScript = hit.collider.GetComponent<EnemyScript>();
           //_enemyScript.TakenDamage(weaponData.damage);
        }
        

        if (hit.collider != null)
        {
            
        }
        */
        bullet = Instantiate(_weaponManager.bulletPrefab, firePoint.position, firePoint.rotation);
        //bullet.GetComponent<Rigidbody>().velocity = firePoint.forward * 25f;
       
        /*
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
        }
        */
    }
    void UpdateFireModeText()
    {
        if (isAutomatic)
        {
            fireModeText.text = "Automatic";
        }
        else
        {
            fireModeText.text = "Manual";
        }
    }

    void UpdateUI()
    {
        ammoText.text = string.Format("{0}/{1}", currentAmmo, maxAmmo);
    }

    void WeaponName()
    {
        weaponNameText.text = weaponName;
    }

    void ReloadWeapon()
    {
        if (isReloading)
        {
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.R) && !isReloading && currentAmmo < maxAmmo)
        {
            StartCoroutine(Reload());
            return;
        }

        if (currentAmmo <= 0 || isReloading)
        {
            return;
        }

        if (isAutomatic)
        {
            if (Input.GetButton("Fire1") && Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + fireRate;
                Shoot();
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1") && Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + fireRate;
                Shoot();
            }
        }

    }
    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
        UpdateUI();
    }
 


 
}
