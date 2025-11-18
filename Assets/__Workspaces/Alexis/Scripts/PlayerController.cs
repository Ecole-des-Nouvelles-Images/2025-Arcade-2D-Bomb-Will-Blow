using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Vector2 Move;
    
    
    [SerializeField] private float MoveSpeed = 5;
    private Rigidbody2D _rb;
    
    //Basic Movement
    private bool _canJumpRightWall;
    private bool _canJumpLeftWall;
    private bool _canWalk;
    
    //PowerDash
    private bool _canDash = true;
    private float _dashCd = 0.1f;
    private int _timeToRefillDash = 10;
    private float _dashDuration;
    private float _maxDashDuration = 0.01f;
    
    //PowerShield
    public bool _shieldOn;
    
    

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_canWalk && Input.GetKey(KeyCode.LeftArrow) || _canWalk && Input.GetKey(KeyCode.RightArrow))
        {
            DoLocomotion();
        }

        if (Move.x == 0 && Move.y == 0 && _canWalk)
        {
            _rb.linearVelocity = Vector2.zero;
        }
        
        if (_canJumpRightWall && Input.GetButtonDown("Jump"))
        {
            DoJumpRightWall();
        }
        
        if (_canJumpLeftWall && Input.GetButtonDown("Jump"))
        {
            DoJumpLeftWall();
        }

        if (_canDash && !_canWalk && Input.GetMouseButtonDown(1))
        {
            DoDash();
        }
        
        if (!_canDash)
        {
            _dashDuration += Time.deltaTime;
            _dashCd += Time.deltaTime;
            if (_dashDuration >= _maxDashDuration)
            {
                _rb.linearVelocity = Vector2.zero;
                _dashDuration = 0;
                
            }
            
            if (_dashCd >= _timeToRefillDash)
            {
                _dashCd = 0;
                _canDash = true;
            }
        }

        if (_shieldOn)
        {
            Debug.Log("Shielding");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "RightWall")
        {
            if (!_canJumpRightWall)
            {
                _rb.linearVelocity = Vector2.zero;
            }
            _canWalk = false;
            _canJumpRightWall = true;
        }

        if (collision.gameObject.tag == "LeftWall")
        {
            if (!_canJumpLeftWall)
            {
                _rb.linearVelocity = Vector2.zero;
            }
            _canWalk = false;
            _canJumpLeftWall = true;
        }

        if (collision.gameObject.tag == "Ground")
        {
            _canWalk = true;
        }
    }
    
    void DoLocomotion()
    {
        _rb.linearVelocity = new Vector2(Move.x * MoveSpeed * Time.deltaTime, _rb.linearVelocity.y);
    }

    void DoJumpLeftWall()
    {
        Debug.Log("JumpLeftWall");
        _rb.AddForce(new Vector2(1500, 1500));
        _canJumpLeftWall = false;
    }
    
    void DoJumpRightWall()
    {
        Debug.Log("JumpRightWall");
        _rb.AddForce(new Vector2(-1500, 1500));
        _canJumpRightWall = false;
    }
    
    void DoDash()
    {
        _rb.AddForce(new Vector2(0, 100000));
        _canDash = false;
        _maxDashDuration = 0.01f;
        _dashDuration = 0;
        _dashCd = 0;
    }
    
}
