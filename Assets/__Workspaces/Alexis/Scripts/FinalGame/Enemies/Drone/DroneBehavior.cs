using UnityEngine;

public class DroneBehavior : MonoBehaviour, IKillable
{
    [Header("Movement Limits")]
    [SerializeField] private GameObject rightSideLimit;
    [SerializeField] private GameObject leftSideLimit;
    
    private Rigidbody2D _rb;
    private bool _movesRight;
    private bool _movesLeft;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _movesRight = false;
        _movesLeft = true;
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x < rightSideLimit.transform.position.x && _movesRight)
        {
            GoToRightSideLimit();
            _movesRight = false;
        }

        if (gameObject.transform.position.x > leftSideLimit.transform.position.x && _movesLeft)
        {
            GoToLeftSideLimit();
            _movesLeft = false;
        }
        
        if (gameObject.transform.position.x >= rightSideLimit.transform.position.x)
        {
            _rb.linearVelocity = new Vector2(0, 0);
            _movesLeft = true;
        }

        if (gameObject.transform.position.x <= leftSideLimit.transform.position.x)
        {
            _rb.linearVelocity = new Vector2(0, 0);
            _movesRight = true;
        }
    }
    
    void GoToRightSideLimit()
    {
        _rb.AddForce(new Vector2(10000 * Time.deltaTime,0));
    }

    void GoToLeftSideLimit()
    {
        _rb.AddForce(new Vector2(-10000 * Time.deltaTime,0));
    }
    
    public void Kill() 
    {
        Destroy(gameObject);
    }
}
