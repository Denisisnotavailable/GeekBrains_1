using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody _enemyBulletRb;

    [SerializeField] private float _fireForceEnemy = 30f;
    [SerializeField] private float _lifeTimeEnemyBull = 3f;
    [SerializeField] public float _enemyBulletDamage = 10f;


    private void Start()
    {
        _enemyBulletRb.AddForce(transform.forward * _fireForceEnemy, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        Destroy(gameObject, _lifeTimeEnemyBull);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Wall") || collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
