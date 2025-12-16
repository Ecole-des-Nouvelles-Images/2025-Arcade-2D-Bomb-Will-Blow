using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsOnUI : MonoBehaviour
{
    [SerializeField] private List<Sprite> _HeartSprites;
    
    [SerializeField] private List<Image> _HeartContainers;
    
    private PlayerDamagedSystem _playerDamagedSystem;

    // Update is called once per frame
    void Update()
    {
        if (_playerDamagedSystem._playerDamaged)
        {
            ReplaceHeartsOnDamage();
        }

        if (_playerDamagedSystem._playerHealed)
        {
            ReplaceHeartsOnHeal();
        }
    }

    private void ReplaceHeartsOnDamage()
    {
        switch (_playerDamagedSystem.Health)
        {
            case 4 : 
                _HeartContainers[3].sprite =  _HeartSprites[1];
                _playerDamagedSystem._playerDamaged = false;
                break;
            case 3 :
                _HeartContainers[2].sprite = _HeartSprites[1];
                _playerDamagedSystem._playerDamaged = false;
                break;
            case 2 :
                _HeartContainers[1].sprite = _HeartSprites[1];
                _playerDamagedSystem._playerDamaged = false;
                break;
            case 1 :
                _HeartContainers[0].sprite = _HeartSprites[1];
                _playerDamagedSystem._playerDamaged = false;
                break;
            default:
                _playerDamagedSystem._playerDamaged = false;
                break;
        }
    }

    private void ReplaceHeartsOnHeal()
    {
        switch (_playerDamagedSystem.Health)
        {
            case 4 : 
                _HeartContainers[3].sprite =  _HeartSprites[0];
                _playerDamagedSystem._playerHealed = false;
                break;
            case 3 :
                _HeartContainers[2].sprite = _HeartSprites[0];
                _playerDamagedSystem._playerHealed = false;
                break;
            case 2 :
                _HeartContainers[1].sprite = _HeartSprites[0];
                _playerDamagedSystem._playerHealed = false;
                break;
            case 1 :
                _HeartContainers[0].sprite = _HeartSprites[0];
                _playerDamagedSystem._playerHealed = false;
                break;
            default:
                _playerDamagedSystem._playerHealed = false;
                break;
        }
    }
}
