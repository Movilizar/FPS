using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 20f;

    public void Takedamage(float amount)
    {
        health -= amount;
        if (health <= 0)
            Die();
    }
    void Die()
    {
        FindObjectOfType<Destructible>().Shatter();
        Destroy(gameObject);
    }
}
