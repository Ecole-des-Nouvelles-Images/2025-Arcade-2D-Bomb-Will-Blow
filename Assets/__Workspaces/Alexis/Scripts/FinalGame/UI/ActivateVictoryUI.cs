using UnityEngine;

public class ActivateVictoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _victoryUI;
    
    private GameObject _p1;
    private GameObject _p2;
    
    private PlayerControllerFinal  _playerControllerP1;
    private PlayerControllerFinal  _playerControllerP2;
    
    private bool _playerControllerP1Found;
    private bool _playerControllerP2Found;

    // Update is called once per frame
    void Update()
    {
        //FindComponents
        if (!_playerControllerP1Found)
        {
            _p1 = GameObject.FindGameObjectWithTag("Player");
            _playerControllerP1 = _p1.GetComponent<PlayerControllerFinal>();
            if (_playerControllerP1 == _playerControllerP1.GetComponent<PlayerControllerFinal>())
            {
                _playerControllerP1Found = true;
            }
        }

        if (!_playerControllerP2Found)
        {
            _p2 = GameObject.FindGameObjectWithTag("Player2");
            _playerControllerP2 = _p2.GetComponent<PlayerControllerFinal>();
            if (_playerControllerP2 == _playerControllerP2.GetComponent<PlayerControllerFinal>())
            {
                _playerControllerP2Found = true; 
            }
        }
        
        //ActivateVictoryScenes
        if (_playerControllerP1.CanDeactivateBomb && _playerControllerP1.BombDeactivated)
        {
            _victoryUI.SetActive(true);
        }

        if (_playerControllerP2.CanDeactivateBomb && _playerControllerP2.BombDeactivated)
        {
            _victoryUI.SetActive(true);
        }
    }
}
