using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
using UnityEngine.Audio;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    float countdown;
    bool hasExploded = false;
    public GameObject explosionEffect;
    public float radius = 5f;
    public float force = 700f;
    
    void Start()
    {
        countdown = delay;
    }

    
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
            
        }
    }
    void Explode()
    {
        FindObjectOfType<AudioManager>().Play("GrenadeExplosion");
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyobject in colliders)
        {
            Rigidbody rb = nearbyobject.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
        Destroy(gameObject);
        

    }
}
