using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinaDetonate : MonoBehaviour
{
    public float _damage = 50f;

    private void OnTriggerEnter(Collider mine)
        {
        if (mine.CompareTag("Player"))
            {
                Destroy(gameObject, 0.3f);
            }
        }
    
}
