using System.Collections.Generic;
using UnityEngine;

namespace __Workspaces.Alexis.Scripts.FinalGame.Player
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
        private float _flashTimer;
        private Material originalMaterial;
        
        private void Awake()
        {
            _playerController = player.GetComponent<PlayerController>();
            HealthCurrent = _playerController.PlayerData.HealthMax;
        }

        private void Start()
        {
            originalMaterial = spriteRenderer.material;
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
                    spriteRenderer.material = originalMaterial;
                    _hitReceived = false;
                    _flashTimer = 0;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                TakeDamage();
            }

            if (collision.gameObject.CompareTag("Bullet"))
            {
                TakeDamage();
            }
        }
    
        private void OnDeath()
        {
            Destroy(player);
        }

        private void TakeDamage() {
            HealthCurrent--;
            spriteRenderer.material = _FlashMaterial;
            _hitReceived = true;
            if(gameObject.CompareTag("Player1Hurtbox")) HeartsOnUI.Instance.DislayHeathPlayer1(HealthCurrent);
            if(gameObject.CompareTag("Player2Hurtbox")) HeartsOnUI.Instance.DislayHeathPlayer2(HealthCurrent);
        }
    }
}
