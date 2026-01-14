using ScriptsFinaux.Player;
using UnityEngine;

namespace ScriptsFinaux.Camera
{
    public class PlayerCameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private float _minDelta = -9f;   // seuil bas relatif à la caméra
        [SerializeField] private float _maxDelta = -3f;   // seuil haut relatif à la caméra
        [SerializeField] private PlayerController _playerController;

        private float _baseY;

        private void Start()
        {
            _baseY = transform.position.y; // position initiale de la caméra
        }

        private void LateUpdate()
        {
            if (!_player) return;
            if (_playerController.FreezeCamera) return;
            
            Vector3 pos = transform.position;
            float deltaY = _player.position.y - pos.y;

            if (deltaY > _maxDelta)
            {
                pos.y += deltaY - _maxDelta;
            }
            else if (deltaY < _minDelta)
            {
                pos.y += deltaY - _minDelta;
            }

            // On ne descend jamais en dessous de la position de base
            pos.y = Mathf.Max(pos.y, _baseY);

            transform.position = pos;
        }
    }
}