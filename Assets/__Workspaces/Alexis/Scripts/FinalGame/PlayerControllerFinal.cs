using UnityEngine;

public class PlayerControllerFinal : MonoBehaviour
{
    //Ground
    public bool IsGrounded;
    
    //Walk
    public Vector2 Move;
    public bool Walk;
    public bool CanWalk;
    
    //Jump
    public bool Jump;
    
    //Wall
    public bool IsOnLeftWall;
    public bool CanJumpToRightWall;
    public bool IsOnRightWall;
    public bool CanJumpToLeftWall;

    //Rigidbody
    public Rigidbody2D Rb;
    
    //Jetpack
    public bool UseJetpack;
    public bool IsInJetpack;
    public float JetpackFuel = 5;
    
    //Dash
    public bool UseDash;
    public bool CanDash = true;
    public int DashCd;
    public float DashRefillTime;
    
    //Shield
    public bool UseShield;
    public GameObject ShieldEffect;
    //Faire un script dans le gameobject Shield qui gère sa durée.
    
    //FSM
    private BaseState _currentState;

    void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        _currentState = new StateIdle(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded)
        {
            CanWalk = true;
        }
        
        _currentState.OnUpdate();
        
        BaseState nextBaseState = _currentState.NextState(); 
        if (nextBaseState != null)
        { 
            _currentState.OnExit(); 
            _currentState = nextBaseState; 
            _currentState.OnEnter();
        }
    }
}
