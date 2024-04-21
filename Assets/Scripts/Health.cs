using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private bool isPlayer;
    [SerializeField] private int health = 20;
    [SerializeField] private int score = 50;
    [SerializeField] private ParticleSystem hitEffect;
    [SerializeField] bool applyCameraShake;
    ScoreKeeper scoreKeeper;
    CameraShake cameraShake;

    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            ShakeCamera();
            damageDealer.Hit();
        }
    }

    public int GetHealth()
    {
        return health;
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    
    private void Die()
    {
        if(!isPlayer)
        {
            scoreKeeper.ModifyScore(score);
        }
        Destroy(gameObject);
    }

    private void PlayHitEffect()
    {
        Instantiate(hitEffect, transform.position, Quaternion.identity);
    }

    private void ShakeCamera()
    {
        if (cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }

    
}
