 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform _rotatePoint;
    private bool _isOpened = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F) && !_isOpened)
        {
            _rotatePoint.rotation = Quaternion.AngleAxis(180, Vector3.up);
            _isOpened = true;
        } else if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F) && _isOpened)
        {
            _rotatePoint.rotation = Quaternion.AngleAxis(90, Vector3.up);
            _isOpened = false;
        }
    }
}
