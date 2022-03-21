using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private PlayerScript _player;

    #region enemy move
    public float _enemySpeed = 3f;
    #endregion

    #region fire
    public GameObject _bulletPrefab;
    public Transform _spawnPosition;

    private float _reload;
    [SerializeField] public float _valueReload = 0.3f;
    #endregion

    void Start()
    {
        _reload = _valueReload;
        _player = FindObjectOfType<PlayerScript>();
    }
    
    void Update()
    {
        LookToPlayer();

        if (Vector3.Distance(transform.position, _player.transform.position) <= 30 && _reload <= 0)
        {
            _reload = _valueReload;
            Fire();
        }
        else _reload -= Time.deltaTime;
    }

    public void Fire()
    {
            var bulletObj = Instantiate(_bulletPrefab, _spawnPosition.position, _spawnPosition.rotation);
            var _bullet = bulletObj.GetComponent<bullet>();
    }

    public void LookToPlayer()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _player.transform.position);
    }
}
