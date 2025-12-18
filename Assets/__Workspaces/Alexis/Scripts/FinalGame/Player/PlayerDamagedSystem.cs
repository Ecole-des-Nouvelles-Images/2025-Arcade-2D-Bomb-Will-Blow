using System.Collections.Generic;
using UnityEngine;

namespace __Workspaces.Alexis.Scripts.FinalGame.Player
{
    public class PlayerDamagedSystem : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private List<GameObject> _HeartContainersP1;
        [SerializeField] private List<GameObject> _HeartContainersP2;
    
        public int HealthCurrent;
        private PlayerController _playerController;

        private void Awake()
        {
            _playerController = player.GetComponent<PlayerController>();
            HealthCurrent = _playerController.PlayerData.HealthMax;
        }

        private void Update()
        {
            if (HealthCurrent == 0)
            {
                OnDeath();
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
            if(gameObject.CompareTag("Player1Hurtbox")) HeartsOnUI.Instance.DislayHeathPlayer1(HealthCurrent);
            if(gameObject.CompareTag("Player2Hurtbox")) HeartsOnUI.Instance.DislayHeathPlayer2(HealthCurrent);
        }
    }
}
