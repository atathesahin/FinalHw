using System.Collections;
using TMPro;
using UnityEngine;

using Random = UnityEngine.Random;

public class WeaponSystem : MonoBehaviour
{
    public Transform firePoint;
    private AudioSource audioSource;
    public TextMeshProUGUI ammoText;
    //public GameObject crosshair;
    private GameObject bullet;
    [SerializeField] private WeaponManager _weaponManager;
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
   
    //
    public Transform weaponTransform;
    public float fireShakeAmount = 0.1f;
    public float fireShakeDuration = 0.1f;
    
    private Quaternion weaponOriginRotation;
    
    //
    private PlayerMovement _player;
    private bool isDead = false;
    //
    private bool _isShopOpen = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        bullet = GetComponent<GameObject>();
        //_player = GetComponent<PlayerMovement>();
        fireModeText = GameObject.Find("FireModeText").GetComponent<TextMeshProUGUI>();
        ammoText = GameObject.Find("AmmoText").GetComponent<TextMeshProUGUI>();
        weaponNameText = GameObject.Find("WeaponText").GetComponent<TextMeshProUGUI>();
        weaponTransform = GetComponent<Transform>();

        UpdateFireModeText();
        UpdateUI();
        weaponOriginRotation = weaponTransform.localRotation;
    }

    void Update()
    {
        if (isDead == false)
        {
            ReloadWeapon();
        }
    }
    void Shoot()
    {
        audioSource.PlayOneShot(_weaponManager.fireSound);
        currentAmmo--;
        UpdateUI();

        
        bullet = Instantiate(_weaponManager.bulletPrefab, firePoint.position, firePoint.rotation);
        
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
                StartCoroutine(FireShake());
      
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1") && Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + fireRate;
                Shoot();
                StartCoroutine(FireShake());
       
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
    IEnumerator FireShake()
    {
        float elapsed = 0.0f;

        while (elapsed < fireShakeDuration)
        {
            elapsed += Time.deltaTime;

            float percentComplete = elapsed / fireShakeDuration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);
            float alpha = Random.value * 2.0f - 1.0f;
            Quaternion shake = Quaternion.Euler(0.0f, 0.0f, alpha * fireShakeAmount * damper);

            weaponTransform.localRotation = weaponOriginRotation * shake;

            yield return null;
        }

        weaponTransform.localRotation = weaponOriginRotation;
    }

    
 
}
