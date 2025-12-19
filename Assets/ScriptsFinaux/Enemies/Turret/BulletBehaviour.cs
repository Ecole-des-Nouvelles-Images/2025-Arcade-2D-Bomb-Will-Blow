using UnityEngine;

namespace ScriptsFinaux.Enemies.Turret
{
    public class BulletBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletExplosionPrefab;
        
        private readonly float _timeBeforeDestroy = 0.8f;
        private float _timerForDestroy;

        private void Update()
        {
            _timerForDestroy += Time.deltaTime;
            if (_timerForDestroy >= _timeBeforeDestroy)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("LeftWall") && !other.CompareTag("RightWall")) return;
            
            if (_bulletExplosionPrefab) {
                Instantiate(_bulletExplosionPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("No bullet explosion prefab assigned");
            }

            Destroy(gameObject);
        }
    }
}