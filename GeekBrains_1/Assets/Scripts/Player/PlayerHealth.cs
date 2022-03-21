using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float _healthPoint = 100f;
    [SerializeField] public float _shieldPoint = 0f;

    private void OnTriggerEnter(Collider player)
    {
        var HealthPoint = _healthPoint;
        var ShieldPoint = _shieldPoint;

        if (player.CompareTag("HealthUp") && HealthPoint < 100)
        {
            GameObject healthObject = GameObject.FindGameObjectWithTag("HealthUp");
            var hpComponent = healthObject.GetComponent<Healthheart>();
            float HealthUp = hpComponent._hpup;
            HealthPoint += HealthUp;
            if (HealthPoint >= 100)
            {
                HealthPoint = 100;
            }
            else _healthPoint = HealthPoint;
        }

        if (player.CompareTag("ShieldUP"))
        {
            GameObject shieldObject = GameObject.FindGameObjectWithTag("ShieldUP");
            var shieldComponent = shieldObject.GetComponent<ShieldPoint>();
            float shieldUP = shieldComponent._mpUp;

            ShieldPoint += shieldUP;
            if (ShieldPoint >= 100)
            {
                ShieldPoint = 100;
            } else _shieldPoint = ShieldPoint;
        }

        if (player.CompareTag("Mine"))
        {
            GameObject mineObject = GameObject.FindGameObjectWithTag("Mine");
            var mineComponent = mineObject.GetComponent<MinaDetonate>();
            float mineDamage = mineComponent._damage;

            if (ShieldPoint > 0)
            {
                ShieldPoint -= mineDamage;

                if (ShieldPoint < 0)
                {
                    HealthPoint += ShieldPoint;
                }
            }
            else HealthPoint -= mineDamage;
        }

        if (player.CompareTag("EnemyBullet"))
        {
            GameObject enemyBulletObj = GameObject.FindGameObjectWithTag("EnemyBullet");
            var enemyBulletComponent = enemyBulletObj.GetComponent<bullet>();
            var enemyDmg = enemyBulletComponent._enemyBulletDamage;

            if (ShieldPoint > 0)
            {
                ShieldPoint -= enemyDmg;

                if (ShieldPoint < 0)
                {
                    HealthPoint += ShieldPoint;
                }
            }
            else HealthPoint -= enemyDmg;
        }
    }

    private void Update()
    {
        if (_healthPoint <= 0) Destroy(gameObject);
    }
}
