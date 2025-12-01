using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _turret;
    
    private Rigidbody2D _rb;
    private TurretBehaviour _wayToShoot;

    private float _timeBeforeDestroy = 0.8f;
    private float _timerForDestroy;

    private void Awake()
    {
        _wayToShoot =  _turret.GetComponent<TurretBehaviour>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_wayToShoot.ShootLeft)
        {
            _rb.AddForce(new Vector2(- 600,0));
        }

        if (_wayToShoot.ShootRight)
        {
            _rb.AddForce(new Vector2(600,0));
        }
        _timerForDestroy += Time.deltaTime;
        if (_timerForDestroy >= _timeBeforeDestroy)
        {
            Destroy(gameObject);
        }
    }
}
