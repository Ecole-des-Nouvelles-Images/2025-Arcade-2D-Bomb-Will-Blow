using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;

    private float _timeBeforeDestroy = 0.8f;
    private float _timerForDestroy;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        _rb.AddForce(new Vector2(600,0));
    }

    // Update is called once per frame
    void Update()
    {
        _timerForDestroy += Time.deltaTime;
        if (_timerForDestroy >= _timeBeforeDestroy)
        {
            Destroy(gameObject);
        }
    }
}
