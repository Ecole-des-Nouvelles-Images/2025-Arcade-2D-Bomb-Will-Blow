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
        
    }

    // Update is called once per frame
    void Update()
    {
        RightWallCheckRaycast();
        LeftWallCheckRaycast();
        
        if (ShootLeft)
        {
            bulletSpawn.transform.position = new Vector3(- bulletSpawn.transform.position.x,  bulletSpawn.transform.position.y, bulletSpawn.transform.position.z);
        }
        
        _bulletSpawnTransform = bulletSpawn.transform;
        
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

    void Fire()
    {
        Instantiate(bulletPrefab, _bulletSpawnTransform.position, _bulletSpawnTransform.rotation);
        _hasShot = true;
        _shootingTimer = 0;
    }
    
    void RightWallCheckRaycast()
    {
        RaycastHit2D hit  = Physics2D.Raycast(gameObject.transform.position, new Vector2(1,0), 0.6f, LayerMask.GetMask("Wall"));
        if (hit.collider != null)
        {
            ShootLeft = true;
        }
        else
        {
            ShootLeft = false;
        }
    }
    
    void LeftWallCheckRaycast()
    {
        RaycastHit2D hit  = Physics2D.Raycast(gameObject.transform.position, new Vector2(-1,0), 0.6f, LayerMask.GetMask("Wall"));
        if (hit.collider != null)
        {
            ShootRight = true;
        }
        else
        {
            ShootRight = false;
        }
    }
}
