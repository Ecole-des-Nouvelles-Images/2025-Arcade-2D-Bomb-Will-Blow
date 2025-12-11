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
    public bool IsInJetpack;
    public float JetpackFuel = 5;
    
    [Space(4), Header("DashParameters")]
    //Dash
    public bool UseDash;
    public bool CanDash = true;
    public int DashCd;
    public float DashRefillTime;
    
    [Space(4), Header("ShieldParameters")]
    //Shield
    public bool UseShield;
    public GameObject ShieldEffect;
    public GameObject Hurtbox;
    private float _timeWithShieldActive = 0.5f;
    private float _TimeSinceShieldActive;
    
    
    //FSM
    private BaseState _currentState;
    
    [Space(4), Header("Animator")]
    //Animator
	public Animator PlayerAnimator;
    
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

    void Awake() 
    {
        PlayerPosition = gameObject.GetComponent<Transform>();
        Rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = _Visual.GetComponent<SpriteRenderer>();
    }
    
    void Start()
    {
        _currentState = new StateIdle(this);
        Debug.Log(JetpackFuel);
    }

    // Update is called once per frame
    void Update()
    {
        //Character orientation
        if (Rb.linearVelocityX < 0)
        {
            _spriteRenderer.flipX = true;
        }

        if (Rb.linearVelocity.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
        
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
        
        //Fuel management
        if (!IsInJetpack && JetpackFuel < 5)
        {
            JetpackFuel += Time.deltaTime / 2;
        }
        
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
