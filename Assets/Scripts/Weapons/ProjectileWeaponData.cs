using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[CreateAssetMenu(fileName = "ProjectileWeaponData", menuName = "Custom Scriptable Objects/ProjectileWeaponData", order = 1)]
public class ProjectileWeaponData : WeaponData
{
    public float projectileSpeed = 10f;
    public GameObject projectilePrefab;
    public VisualEffect impactVFX;
}
