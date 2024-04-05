using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileLifetime = 5f;
    [SerializeField] private float fireRate = 0.1f;
    [SerializeField] private bool useAI;
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
            yield return new WaitForSeconds(fireRate);
        }
    }
}
