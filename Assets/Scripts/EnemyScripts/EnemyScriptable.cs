using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Enemy Type",menuName = "Enemy Type")]

public class EnemyScriptable : ScriptableObject
{
    
    public Color enemyColor = Color.white;
    //public float enemySpeed = 5;
    public Vector3 enemyScale = Vector3.one;
    public string enemyName = "Type";
    public int enemyDamage;
    public GameObject dropObject;
    public float dropChance;

}