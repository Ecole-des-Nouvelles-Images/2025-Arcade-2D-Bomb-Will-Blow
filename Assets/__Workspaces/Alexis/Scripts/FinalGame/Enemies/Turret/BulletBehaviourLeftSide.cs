using UnityEngine;

public class BulletBehaviourLeftSide : MonoBehaviour
{
    [SerializeField] private GameObject _turret;
    
    private Rigidbody2D _rb;

    private float _timeBeforeDestroy = 0.8f;
    private float _timerForDestroy;

    private void Awake()
    {
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _rb.AddForce(new Vector2(- 600,0));
        _timerForDestroy += Time.deltaTime;
        if (_timerForDestroy >= _timeBeforeDestroy)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
