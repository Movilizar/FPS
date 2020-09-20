using UnityEngine;

public class BarrelExplosives : MonoBehaviour
{
    public float health = 10f;
    public GameObject explosionEffect;

    public void Takedamage(float amount)
    {
        health -= amount;
        if (health <= 0)
            Die();
    }
    void Die()
    {
        Destroy(gameObject);
        Instantiate(explosionEffect, transform.position, transform.rotation);
    }
}
