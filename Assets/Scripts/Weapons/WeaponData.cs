using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Custom Scriptable Objects/WeaponData", order = 1)]
public class WeaponData : ScriptableObject
{
    public int baseDamage = 1;
    public float attackDelay = 0.5f;
    public GameObject weaponPrefab;
}
