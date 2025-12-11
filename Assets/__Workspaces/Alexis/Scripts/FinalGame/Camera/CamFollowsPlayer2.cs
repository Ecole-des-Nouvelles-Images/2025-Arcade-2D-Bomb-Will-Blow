using UnityEngine;

public class CamFollowsPlayer2 : MonoBehaviour
{
    private GameObject _player;

    private bool _playerFound;
    
    void Update()
    {
        //FindPlayer
        if (!_playerFound)
        {
            _player = GameObject.FindWithTag("Player2");
            if (_player != null)
            {
                _playerFound = true;
            }
        }
        
        if (_player.transform.position.y >= -290)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, _player.transform.position.y + 2, gameObject.transform.position.z);
        }

        if (_player.transform.position.y >= -115 && _player.transform.position.x >= 6.5)
        {
            gameObject.transform.position = new Vector3(_player.transform.position.x - 6.5f, _player.transform.position.y + 2, gameObject.transform.position.z);
        }
    }
}
