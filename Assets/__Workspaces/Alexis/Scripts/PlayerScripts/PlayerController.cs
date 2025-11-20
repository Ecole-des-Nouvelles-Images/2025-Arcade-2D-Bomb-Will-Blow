using System;
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
    
    //Air Movement
    private bool _inAir;
    
    //Power Dash
    private bool _canDash = true;
    public float _dashCd = 0.1f;
    public int _timeToRefillDash = 10;
    private float _dashDuration;
    private float _maxDashDuration = 0.01f;
    
    //Power Shield
    public bool IsShielding;
    private bool ShieldOn;
    public float ShieldTimer;
    
    //Power Jetpack
    public bool IsInJetpack;
    public float JetpackFuel = 5;
    private float _jetpackForce = 5;
    

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Walk
        if (_canWalk && Input.GetKey(KeyCode.LeftArrow) || _canWalk && Input.GetKey(KeyCode.RightArrow))
        {
            DoLocomotion();
        }

        if (Move.x == 0 && Move.y == 0 && _canWalk)
        {
            _rb.linearVelocity = Vector2.zero;
        }
        
        //Jump
        if (_canJumpRightWall && Input.GetButtonDown("Jump"))
        {
            DoJumpRightWall();
        }
        
        if (_canJumpLeftWall && Input.GetButtonDown("Jump"))
        {
            DoJumpLeftWall();
        }

        //Dash
        if (_canDash && !_canWalk && Input.GetMouseButtonDown(1))
        {
            DoDash();
        }
        
        if (!_canDash)
        {
            _dashDuration += Time.deltaTime;
            
            if (_dashCd <= _timeToRefillDash)
            {
                _dashCd += Time.deltaTime;
            }
            
            if (_dashDuration >= _maxDashDuration)
            {
                _rb.linearVelocity = Vector2.zero;
                _dashDuration = 0;
                
            }
            
            if (_dashCd >= _timeToRefillDash)
            {
                _dashCd = 10;
                _canDash = true;
            }
        }

        //Shield
        if (ShieldOn && IsShielding)
        {
            Debug.Log("Shielding");
            ShieldTimer = 0;
            ShieldOn = false;
            IsShielding = false;
        }

        if (!ShieldOn)
        {
            ShieldTimer += Time.deltaTime;
        }

        if (ShieldTimer >= 5)
        {
            ShieldOn = true;
            ShieldTimer = 5;
        }
        
        //Jetpack
        if (IsInJetpack)
        {
            DoJetpackLocomotion();
            JetpackFuel -= Time.deltaTime;
            if (JetpackFuel <= 0)
            {
                IsInJetpack = false;
            }
        }

        if (!IsInJetpack)
        {
            JetpackFuel +=  Time.deltaTime/2;
        }
        
        if (JetpackFuel <= 0)
        {
            JetpackFuel = 0;
        }

        if (JetpackFuel > 5)
        {
            JetpackFuel = 5;
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
            _rb.gravityScale = 0.1f;
            _canWalk = false;
            IsInJetpack = false;
            _canJumpRightWall = true;
        }

        if (collision.gameObject.tag == "LeftWall")
        {
            if (!_canJumpLeftWall)
            {
                _rb.linearVelocity = Vector2.zero;
            }
            _rb.gravityScale = 0.1f;
            _canWalk = false;
            IsInJetpack = false;
            _canJumpLeftWall = true;
        }

        if (collision.gameObject.tag == "Ground")
        {
            _canWalk = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "LeftWall")
        {
            _rb.gravityScale = 1;
            _inAir = true;
        }

        if (other.gameObject.tag == "RightWall")
        {
            _rb.gravityScale = 1;
            _inAir = true;
        }
    }

    void DoLocomotion()
    {
        _rb.linearVelocity = new Vector2(Move.x * MoveSpeed * Time.deltaTime, _rb.linearVelocity.y);
    }

    void DoJumpLeftWall()
    {
        _rb.AddForce(new Vector2(1500, 1500));
        _canJumpLeftWall = false;
    }
    
    void DoJumpRightWall()
    {
        _rb.AddForce(new Vector2(-1500, 1500));
        _canJumpRightWall = false;
    }
    
    void DoDash()
    {
        _rb.AddForce(new Vector2(0, 50000));
        _canDash = false;
        _maxDashDuration = 0.01f;
        _dashDuration = 0;
        _dashCd = 0;
    }

    void DoJetpackLocomotion()
    {
        _rb.linearVelocity = new Vector2(Move.x * MoveSpeed * Time.deltaTime / 2, _jetpackForce);
    }
}
