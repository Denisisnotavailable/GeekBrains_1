using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPoint : MonoBehaviour
{
    public float _mpUp = 25f;

    private void OnTriggerEnter(Collider shield)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        var mpPlayer = player.GetComponent<PlayerHealth>();
        float mpCheck = mpPlayer._shieldPoint;


        if (shield.CompareTag("Player") && mpCheck < 100)
        {
            Destroy(gameObject);
        }
    }
}
