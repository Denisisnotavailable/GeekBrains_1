using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthheart : MonoBehaviour
{
    public float _hpup = 30f;

    private void OnTriggerEnter(Collider health)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        var hpPlayer = player.GetComponent<PlayerHealth>();
        float hpCheck = hpPlayer._healthPoint;


        if (health.CompareTag("Player") && hpCheck < 100)
        {
            Destroy(gameObject);
        }
    }
}
