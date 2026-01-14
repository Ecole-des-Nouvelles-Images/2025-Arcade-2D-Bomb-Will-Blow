using System.Collections.Generic;
using UnityEngine;

namespace ScriptsFinaux.Player
{
    public class PlayerDamagedSystem : MonoBehaviour
    {
        [Space(4), Header("Game Object Player")]
        [SerializeField] private GameObject player;
        
        [Space(4), Header("UI Hearts")]
        [SerializeField] private List<GameObject> _HeartContainersP1;
        [SerializeField] private List<GameObject> _HeartContainersP2;
    
        [Space(4), Header("Flash effect on hit references")]
        [SerializeField] private Material _FlashMaterial;
        [SerializeField] private float _FlashDuration;
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        public int HealthCurrent;
        
        private PlayerController _playerController;
        private bool _hitReceived;
        private bool _canTakeDamage = true;
        private bool _hasDied;
        private float _flashTimer;
        private Material _originalMaterial;
        private Vector2 _currentPosition;
        private Transform _playerTransform;
        
        private void Awake()
        {
            _playerController = player.GetComponent<PlayerController>();
            _playerTransform = player.GetComponent<Transform>();
            HealthCurrent = _playerController.PlayerData.HealthMax;
        }

        private void Start()
        {
            _originalMaterial = spriteRenderer.material;
        }

        private void Update()
        {
            if (HealthCurrent == 0)
            {
                OnDeath();
            }

            if (_hitReceived)
            {
                _flashTimer += Time.deltaTime;
                if (_flashTimer >= _FlashDuration)
                {
                    spriteRenderer.material = _originalMaterial;
                    _hitReceived = false;
                    _flashTimer = 0;
                }
            }

            if (_hasDied) {
                Debug.Log("HasDied");
                if (_playerTransform.position.y <= _currentPosition.y - 12) {
                    _playerTransform.position = new Vector3(2.5f, 2, 0);
                    _playerController.PlayerAnimator.SetBool("IsDead", false);
                    _playerController.FreezeCamera = false;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy") && _canTakeDamage)
            {
                TakeDamage();
                _canTakeDamage = false;
            }

            if (collision.gameObject.CompareTag("Bullet") && _canTakeDamage)
            {
                TakeDamage();
                _canTakeDamage = false;
            }
        }
    
        public void OnDeath()
        {
            _playerController.PlayerAnimator.SetBool("IsDead", true);
            _playerController.FreezeCamera = true;
            _currentPosition = transform.position;
            _hasDied  = true;
        }
        
        public void TakeDamage() {
            HealthCurrent--;
            spriteRenderer.material = _FlashMaterial;
            _hitReceived = true;
            if(gameObject.CompareTag("Player1Hurtbox")) HeartsOnUI.Instance.DislayHeathPlayer1(HealthCurrent);
            if(gameObject.CompareTag("Player2Hurtbox")) HeartsOnUI.Instance.DislayHeathPlayer2(HealthCurrent);
        }
    }
}
