using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrap : MonoBehaviour
{
    private void OnTriggerEnter(Collider trap)
    {
        if (trap.CompareTag("Player"))
        {
            Destroy(gameObject, 0.2f);
        }
    }
}
