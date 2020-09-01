using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;          // damage dealt to the target
    public float lifetime;      // how long until the bullet despawns>
    private float shootTime;    // time the bullet was shot

    void OnEnable()
    {
        shootTime = Time.time;
    }

    void Update()
    {
        // disable the bullet after 'lifetime' seconds
        if (Time.time - shootTime >= lifetime)
            gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        // did we hit the player?
        if (other.CompareTag("Player"))
            other.GetComponent<Player>().TakeDamage(damage);
        else if (other.CompareTag("Enemy"))
            other.GetComponent<Enemy>().TakeDamage(damage);

        // disable the bullet
        gameObject.SetActive(false);
    }
}
