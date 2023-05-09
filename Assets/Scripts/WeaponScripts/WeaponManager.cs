using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Type",menuName = "Weapon Type")]
public class WeaponManager : ScriptableObject
{
    //public float fireRate = 0.1f;
    //public int maxAmmo;
    //public int currentAmmo;
    //public float damage = 10f;
    public GameObject bulletPrefab;
    public AudioClip fireSound;

    //public GameObject weaponInformation;
    //public bool isAutomatic = false;

}
