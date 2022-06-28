using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    public Transform pivot;
    public Transform weaponSlot;
    public ProjectileWeaponData weaponData;

    public void Equip()
    {
        Instantiate(weaponData.weaponPrefab, weaponSlot.position, Quaternion.identity, weaponSlot);
    }

    public void Attack()
    {
        var projectileGO = Instantiate(weaponData.projectilePrefab, weaponSlot.position, pivot.transform.rotation);
        var projectileComp = projectileGO.AddComponent<Projectile>();
        projectileComp.Damage = weaponData.baseDamage;
        projectileComp.Speed = weaponData.projectileSpeed;
    }
}
