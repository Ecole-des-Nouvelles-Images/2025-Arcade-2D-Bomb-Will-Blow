using System;
using UnityEngine;

namespace Proto
{
    public class CrawlerBehaviour : MonoBehaviour
    {
        [Header("Movement Limits")]
        [SerializeField] private GameObject _upperLimit;
        [SerializeField] private GameObject _lowerLimit;

        [Space(4), Header("Direction")] 
        [SerializeField] private bool OnLeftWall;
        [SerializeField] private bool OnRightWall;
        
        private Rigidbody2D _rb;
        private SpriteRenderer _spriteRenderer;
        private bool _movesUp;
        private bool _movesDown;
    
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _movesUp = false;
            _movesDown = true;
            if (OnLeftWall)
            {
                _spriteRenderer.flipX = true;
            }

            if (OnRightWall)
            {
                _spriteRenderer.flipX = false;
            }
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
}

