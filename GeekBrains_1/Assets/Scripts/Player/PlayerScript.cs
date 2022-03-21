using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject _player;
    public GameObject _gun;
    public GameObject spawnPosition;
    Rigidbody rb;

    public readonly string ForOpenDoorPress = "F";

    #region move
    private Vector3 _direction;
    public float _speed = 7f;
    #endregion

    #region mouseMove
    private float rotationX;
    private float rotationY;

    float rotationXCurrent;
    float rotationYCurrent;

    float currentVelocityX;
    float currentVelocityY;

    public float smoothTime = 0.1f;
    public float _sensetivity = 4f;

    public Camera _playerCamera;
    public Camera _gunCamera;
    
    #endregion

    #region Jump

    public float _jumpForce = 30f;
    private readonly Vector3 jumpDirection = Vector3.up;

    public bool _isGrounded = true;

    #endregion

    #region Fire
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
        MouseMove();
        Fire();

        if (Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    private void Move()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        var speed = _direction * _speed * Time.deltaTime;
        transform.Translate(speed);
    }

    private void MouseMove()
    {
        rotationX += Input.GetAxis("Mouse X") * _sensetivity;
        rotationY += Input.GetAxis("Mouse Y") * _sensetivity;

        rotationY = Mathf.Clamp(rotationY, -90, 90);

        rotationXCurrent = Mathf.SmoothDamp(rotationXCurrent, rotationX, ref currentVelocityX, smoothTime);
        rotationYCurrent = Mathf.SmoothDamp(rotationYCurrent, rotationY, ref currentVelocityY, smoothTime);

        _playerCamera.transform.rotation = Quaternion.Euler(-rotationY, rotationX, 0f);
        _gunCamera.transform.rotation = Quaternion.Euler(-rotationY, rotationX, 0f);

        _player.gameObject.transform.rotation = Quaternion.Euler(0, rotationX, 0f);
        _gun.gameObject.transform.rotation = Quaternion.Euler(-rotationY, rotationX, 0f);

        spawnPosition.gameObject.transform.rotation = Quaternion.Euler(-rotationY, rotationX, 0f);


    }

    private void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var bulletObj = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            _ = bulletObj.GetComponent<bulletMove>();
        }
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            rb.AddForce(jumpDirection * _jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        var ground = other.gameObject.GetComponentInParent<Ground>();
        if (ground)
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        var ground = other.gameObject.GetComponentInParent<Ground>();
        if (ground)
        {
            _isGrounded = false;
        }
    }
}
