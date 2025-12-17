using UnityEngine;

public class PlayerControllerFinal : MonoBehaviour
{
    [Space(5), Header("Grounded")]
    //Ground
    public bool IsGrounded;
    
    [Space(4), Header("MoveParameters")]
    //Walk
    public Vector2 Move;
    public bool Walk;
    public bool CanWalk;
    
    [Space(4), Header("Jump")]
    //Jump
    public bool Jump;
    public bool HasJumped;
    public float JumpXDynamic;
    public float JumpY;
    public GameObject RightJumpEffect;
    public GameObject LeftJumpEffect;
    
    [Space(4), Header("Landing Effect")]
    public GameObject LandingEffectRightSide;
    public GameObject LandingEffectLeftSide;
    
    [Space(4), Header("Walls")]
    //Wall
    public bool IsOnLeftWall;
    public bool CanJumpToRightWall;
    public bool IsOnRightWall;
    public bool CanJumpToLeftWall;

    [Space(4), Header("RigidBody")]
    //Rigidbody
    public Rigidbody2D Rb;
    
    [Space(4), Header("JetpackParameters")]
    //Jetpack
    public bool UseJetpack;
    public bool OutOfJetpack;
    public bool IsInJetpack;
    public float JetpackFuel = 5;
    
    [Space(4), Header("DashParameters")]
    //Dash
    public bool UseDash;
    public bool CanDash = true;
    public int DashCd = 500;
    public float DashRefillTime;
    public GameObject DashLeftSide;
    public bool InstantiateLeftDash;
    public GameObject DashRightSide;
    public bool InstantiateRightDash;
    
    [Space(4), Header("ShieldParameters")]
    //Shield
    public bool UseShield;
    public bool CanUseShield = true;
    public GameObject ShieldEffect;
    public GameObject Hurtbox;
    private float _timeWithShieldActive = 0.5f;
    private float _TimeSinceShieldActive;
    private float _timeToReuseShield;
    private int ShieldCd = 500;
    
    
    //FSM
    private BaseState _currentState;
    
    [Space(4), Header("Animator")]
    //Animator
	public Animator PlayerAnimator;
    
    //Flipx
    private float _lastPosition;
    private float _currentPosition;
    
    //SpriteRenderer
    [SerializeField] private GameObject _Visual;
    private SpriteRenderer _spriteRenderer;
    
    [Space(4), Header("Bomb")]
    //Bomb
    public bool CanDeactivateBomb;
    public bool BombDeactivated;
    
    [Space(4), Header("TransformComponent")]
    //Transform
    public Transform PlayerPosition;
    
    [Space(4), Header("Visual")]
    //Visual
    public GameObject PlayerVisual;

    void Awake() 
    {
        PlayerPosition = gameObject.GetComponent<Transform>();
        Rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = _Visual.GetComponent<SpriteRenderer>();
    }
    
    void Start()
    {
        _currentState = new StateIdle(this);
        _currentPosition = gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //Character orientation
        _lastPosition = _currentPosition;
        _currentPosition = Rb.transform.position.x;
        
        if (_lastPosition > _currentPosition && IsGrounded)
        {
            _spriteRenderer.flipX = true;
        }

        if (_lastPosition < _currentPosition && IsGrounded)
        {
            _spriteRenderer.flipX = false;
        }
        
        if (!IsGrounded && _lastPosition > _currentPosition)
        {
            _spriteRenderer.flipX = false;
        }

        if (!IsGrounded && _lastPosition < _currentPosition)
        {
            _spriteRenderer.flipX = true;
        }
        
        if (IsOnLeftWall) _spriteRenderer.flipX = true;
        if (IsOnRightWall) _spriteRenderer.flipX = false;
        
        //Can character walk ?
        if (IsGrounded)
        {
            CanWalk = true;
        }

        //How long the Shield stays active
        if (ShieldEffect.activeSelf)
        {
            _TimeSinceShieldActive += Time.deltaTime;
            if (_TimeSinceShieldActive >= _timeWithShieldActive)
            {
                ShieldEffect.SetActive(false);
                Hurtbox.SetActive(true);
                _TimeSinceShieldActive = 0;
            }
        }
        
        //Shield cooldown
        if (!CanUseShield)
        {
            _timeToReuseShield += Time.deltaTime;
            if (_timeToReuseShield >= ShieldCd)
            {
                CanUseShield = true;
            }
        }
        
        //Instantiation of dash effect
        if (InstantiateLeftDash)
        {
            InstantiateLeftDash = false;
            Instantiate(DashLeftSide, PlayerPosition.position, PlayerPosition.rotation);
        }

        if (InstantiateRightDash)
        {
            InstantiateRightDash = false;
            Instantiate(DashRightSide, PlayerPosition.position, PlayerPosition.rotation);
        }
        
        //Dash cooldown
        if (!CanDash)
        {
            DashRefillTime += Time.deltaTime;
            if (DashRefillTime >= DashCd)
            {
                CanDash = true;
            }
        }
        Debug.Log(DashRefillTime);
        Debug.Log(CanDash);
        
        //Fuel management
        if (!IsInJetpack && JetpackFuel < 5)
        {
            JetpackFuel += Time.deltaTime / 2;
        }
        
        //Jump value y to get max jump angle at 45°
        JumpY = Move.y;
        if (JumpY > Mathf.Abs(Move.x))
        {
            JumpY = 0.7f;
        }

        if (JumpY < 0)
        {
            JumpY = 0;
        }
        
        //Getting Move.X to be a constant for a  jump that is always dynamic
        JumpXDynamic = 1 / Move.x;
        
        //FSM gestion
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
