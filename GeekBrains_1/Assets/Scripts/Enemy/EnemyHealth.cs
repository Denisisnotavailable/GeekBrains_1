using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public float _enemyHP = 100f;

    private void OnTriggerEnter(Collider enemy)
    {
        if (enemy.CompareTag("Bullet"))
        {
            GameObject bulletObject = GameObject.FindGameObjectWithTag("Bullet");
            var bulletComponent = bulletObject.GetComponent<bulletMove>();
            float damage = bulletComponent._bulletDamage;

            var enemyHP = _enemyHP - damage;
            _enemyHP = enemyHP;
        }
    }

    private void Update()
    {
        if (_enemyHP <= 0) Destroy(gameObject);
    }
}
