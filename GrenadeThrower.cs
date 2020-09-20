using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    public float throwForce = 40f;
    public GameObject GrenadePrefab;
    public float grenadeAmmo = 3f;
    public Transform aim;
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && grenadeAmmo > 0)
        {
            ThrowGrenade();
        }
    }
    void ThrowGrenade()
    {
        grenadeAmmo = grenadeAmmo - 1;
        GameObject grenade = Instantiate(GrenadePrefab, aim.position, aim.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(aim.forward * throwForce, ForceMode.VelocityChange);      
    }
}
