using System;
using UnityEngine;

public class CrawlerBehaviour : MonoBehaviour
{
    [Header("Movement Limits")]
    [SerializeField] private GameObject _upperLimit;
    [SerializeField] private GameObject _lowerLimit;
    
    private Rigidbody2D _rb;
    private bool _movesUp;
    private bool _movesDown;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _movesUp = false;
        _movesDown = true;
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < _upperLimit.transform.position.y && _movesUp)
        {
            GoToUpperLimit();
            _movesUp = false;
        }

        if (gameObject.transform.position.y > _lowerLimit.transform.position.y && _movesDown)
        {
            GoToLowerLimit();
            _movesDown = false;
        }
        
        if (gameObject.transform.position.y >= _upperLimit.transform.position.y)
        {
            _rb.linearVelocity = new Vector2(0, 0);
            _movesDown = true;
        }

        if (gameObject.transform.position.y <= _lowerLimit.transform.position.y)
        {
            _rb.linearVelocity = new Vector2(0, 0);
            _movesUp = true;
        }
    }
    
    void GoToUpperLimit()
    {
        _rb.AddForce(new Vector2(0,100));
    }

    void GoToLowerLimit()
    {
        _rb.AddForce(new Vector2(0,-100));
    }
}
