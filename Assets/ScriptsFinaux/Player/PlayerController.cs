using UnityEngine;

namespace ScriptsFinaux.Player
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerData PlayerData;
        
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
        public float JetpackCurrent;
    
        [Space(4), Header("DashParameters")]
        //Dash
        public bool UseDash;
        
        public float DashTimer;
        public GameObject DashLeftSide;
        public bool InstantiateLeftDash;
        public GameObject DashRightSide;
        public bool InstantiateRightDash;
        public bool CanDash => DashTimer >= PlayerData.DashCd;
    
        [Space(4), Header("ShieldParameters")]
        //Shield
        public bool UseShield;
        public GameObject ShieldEffect;
        public GameObject Hurtbox;
        private int ShieldCd = 500;
        public float ShieldTimer; 
        public bool CanShield => ShieldTimer >= PlayerData.ShieldCd;
        
        //FSM
        private BaseState _currentState;
    
        [Space(4), Header("Animator")]
        //Animator
        public Animator PlayerAnimator;
    
        //Flipx
        private float _lastPosition;
        private float _currentPosition;
    
        private SpriteRenderer _spriteRenderer;
    
        [Space(4), Header("Bomb")]
        //Bomb
        public bool CanDeactivateBomb;
        public bool BombDeactivated;
    
        [Space(4), Header("Visual")]
        //Visual
        public GameObject PlayerVisual;

        void Awake() 
        {
            Rb = GetComponent<Rigidbody2D>();
            _spriteRenderer = PlayerVisual.GetComponent<SpriteRenderer>();
        }
    
        void Start()
        {
            _currentState = new StateIdle(this);
            _currentPosition = gameObject.transform.position.x;
            JetpackCurrent = PlayerData.JetpackMax;
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
        
            //Shield cooldown
            ShieldTimer += Time.deltaTime;
            
            //Dash cooldown
            DashTimer += Time.deltaTime;
        
            //Fuel management
            if (!IsInJetpack && JetpackCurrent < PlayerData.JetpackMax)
            {
                JetpackCurrent += Time.deltaTime / 2;
            }
        
            //Jump value y to get max jump angle at 45°
            JumpY = Move.y;
            if (JumpY > Mathf.Abs(Move.x))
            {
                JumpY = 0.7f;
            }

            if (JumpY < -0.3f)
            {
                JumpY = -0.3f;
            }
        
            //Getting Move.X to be a constant for a  jump that is always dynamic
            JumpXDynamic = 1 / Move.x;

            if (_currentState != null)
            {
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
    }
}
