using System;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    [Header("BulletReferences")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletSpawn;

    public bool ShootRight;
    public bool ShootLeft;
    
    private Transform _bulletSpawnTransform;
    
    private bool _hasShot;
    private float _shootingRate = 1.1f;
    private float _shootingTimer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _bulletSpawnTransform = bulletSpawn.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_hasShot)
        {
            Fire();
        }

        if (_hasShot)
        {
            _shootingTimer += Time.deltaTime;
            if (_shootingTimer >= _shootingRate)
            {
                _hasShot = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "LeftWall")
        {
            ShootRight = true;
        }

        if (other.gameObject.tag == "RightWall")
        {
            ShootLeft = true;
        }
    }

    void Fire()
    {
        Instantiate(bulletPrefab, _bulletSpawnTransform.position, _bulletSpawnTransform.rotation);
        _hasShot = true;
        _shootingTimer = 0;
    }
}
