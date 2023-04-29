using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Type",menuName = "Weapon Type")]
public class WeaponData : ScriptableObject
{
    public float fireRate = 0.1f;
    //public float damage = 10f;
    public GameObject bulletPrefab;
    public AudioClip fireSound;
}
