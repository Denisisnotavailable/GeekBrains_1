using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour
{

    public Rigidbody _rb;

    [SerializeField] public float _fireForce = 10f;
    [SerializeField] public float lifeTime = 3f;
    [SerializeField] public float _bulletDamage = 10f;

    private void Start()
    {
        this._rb.AddForce(transform.forward * _fireForce, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Wall") || collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        } 
    }
}

