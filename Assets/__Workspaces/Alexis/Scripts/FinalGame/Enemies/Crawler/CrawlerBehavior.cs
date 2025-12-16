using UnityEngine;

public class CrawlerBehaviour : MonoBehaviour , IKillable
    {
        [Header("Movement Limits")]
        [SerializeField] private GameObject _upperLimit;
        [SerializeField] private GameObject _lowerLimit;

        [Space(4), Header("Direction")] 
        [SerializeField] private bool OnLeftWall;
        
        [Space(4), Header("Death Effect Prefab")]
        [SerializeField] private GameObject _deathEffectLeftSide;

        [SerializeField] private GameObject _deathEffectRightSide;
        
        private Rigidbody2D _rb;
        private Transform _transform;
        private bool _movesUp;
        private bool _movesDown;
    
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _transform = GetComponent<Transform>();
            _movesUp = false;
            _movesDown = true;
            if (OnLeftWall)
            {
                _transform.Rotate(new Vector3(0,0,- 180));
            }
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
            _rb.AddForce(new Vector2(0,10000 * Time.deltaTime));
        }

        void GoToLowerLimit()
        {
            _rb.AddForce(new Vector2(0,-10000  * Time.deltaTime));
        }

        public void Kill() 
        {
            Debug.Log("Kill");
            if (OnLeftWall)
            {
                _deathEffectLeftSide.SetActive(true);
            }
            else
            {
                _deathEffectRightSide.SetActive(true);
            }
            gameObject.SetActive(false);
        }
    }