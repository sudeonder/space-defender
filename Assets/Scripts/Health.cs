using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 20;


    void OnTriggerEnter2D(Collider2D other)
    {
        
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            Debug.Log("collided with something! : " + other.gameObject.name);
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }
    }

    private void TakeDamage(int damage)
    {
        Debug.Log("taking damage!");
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
