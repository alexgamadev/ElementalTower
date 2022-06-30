using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ProjectileWeaponData WeaponData { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * WeaponData.projectileSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var contactPoint = collision.GetContact(0);
        var angle = Quaternion.FromToRotation(Vector3.up, contactPoint.point - (Vector2)collision.transform.position);
        var vfx = Instantiate(WeaponData.impactVFX, contactPoint.point, angle);
        vfx.SetFloat("Impact Speed", WeaponData.projectileSpeed);
        vfx.Play();
        Destroy(this.gameObject);
        Health healthComp = collision.transform.GetComponent<Health>();
        healthComp.Damage(WeaponData.baseDamage);
    }
}
