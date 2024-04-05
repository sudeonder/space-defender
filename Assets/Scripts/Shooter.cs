using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileLifetime = 5f;
    [SerializeField] private float baseFiringRate = 0.1f;

    [Header("AI")]
    [SerializeField] private float firingRateVariance = 0f;
    [SerializeField] private float minimumFiringRate = 0.1f;
    [SerializeField] private bool useAI;
    [HideInInspector]
    public bool isFire;
    private Coroutine firingCoroutine;

    void Start()
    {
        if(useAI)
        {
            isFire = true;
        }
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(isFire & firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFire && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    private IEnumerator FireContinuously()
    {
        while(true)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = transform.up * projectileSpeed;
            Destroy(projectile, projectileLifetime);

            float timeToNextShot = baseFiringRate + Random.Range(-firingRateVariance, firingRateVariance);
            float fireRate = Mathf.Clamp(timeToNextShot, minimumFiringRate, float.MaxValue);

            yield return new WaitForSeconds(timeToNextShot);
        }
    }
}
