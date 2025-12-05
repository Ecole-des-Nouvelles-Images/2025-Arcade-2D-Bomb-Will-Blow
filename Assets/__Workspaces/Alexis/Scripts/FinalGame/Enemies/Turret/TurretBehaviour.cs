using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    [Header("BulletReferences")]
    [SerializeField] private GameObject bulletPrefabRightSide;
    [SerializeField] private GameObject bulletPrefabLeftSide;
    
    [Space(4), Header("BulletSpawners")]
    [SerializeField] private GameObject bulletSpawnRightSide;
    [SerializeField] private GameObject bulletSpawnLeftSide;
    
    [Space(4), Header("SideToShoot")]
    [SerializeField] private bool SpawnBulletToTheRightSide;
    [SerializeField] private bool SpawnBulletToTheLeftSide;
    
    private bool _hasShot;
    private float _shootingRate = 1.1f;
    private float _shootingTimer;
    private SpriteRenderer _renderer;

    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        if (SpawnBulletToTheRightSide)
        {
            _renderer.flipX = false;
        }

        if (SpawnBulletToTheLeftSide)
        {
            _renderer.flipX = true;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!_hasShot && SpawnBulletToTheRightSide)
        {
            FireRightSide();
        }
        
        if (!_hasShot && SpawnBulletToTheLeftSide)
        {
            FireLeftSide();
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

    void FireRightSide()
    {
        Instantiate(bulletPrefabRightSide, bulletSpawnRightSide.transform.position, bulletSpawnRightSide.transform.rotation);
        _hasShot = true;
        _shootingTimer = 0;
    }
    
    void FireLeftSide()
    {
        Instantiate(bulletPrefabLeftSide, bulletSpawnLeftSide.transform.position, bulletSpawnLeftSide.transform.rotation);
        _hasShot = true;
        _shootingTimer = 0;
    }
}
