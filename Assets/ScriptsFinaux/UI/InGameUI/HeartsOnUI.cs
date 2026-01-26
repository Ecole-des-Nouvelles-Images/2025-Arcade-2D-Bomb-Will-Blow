using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsOnUI : MonoBehaviour
{
    public static HeartsOnUI Instance;
    
    //Hearts
    [SerializeField] private List<GameObject> _HeartContainersP1;
    [SerializeField] private List<GameObject> _HeartContainersP2;

    [Space(4)]
    //Portraits
    [SerializeField] private List<Sprite> _PortraitsP1;
    [SerializeField] private List<Sprite> _PortraitsP2;
    
    [Space(4)]
    //Portraits holder GameObjects
    [SerializeField] private GameObject _PortraitHolderP1;
    [SerializeField] private GameObject _PortraitHolderP2;
    
    [Space(4)]
    //Portraits holder
    private Image PortraitsP1;
    private Image PortraitsP2;
    
    private void Awake() {
        Instance = this;
        PortraitsP1 = _PortraitHolderP1.GetComponent<Image>();
        PortraitsP2 = _PortraitHolderP2.GetComponent<Image>();
    }

    public void DislayHeathPlayer1(int newHealth) {
        for (int i = 0; i < _HeartContainersP1.Count; i++) {
            if (_HeartContainersP1[i] == null) continue;
            _HeartContainersP1[i].SetActive(newHealth > i);
            //PortraitsP1.sprite = _PortraitsP1[i];
        }
        
        // Changement du portrait
        if (newHealth > 0 && newHealth <= _PortraitsP1.Count) {
            PortraitsP1.sprite = _PortraitsP1[newHealth - 1];
        }
    }
    
    public void DislayHeathPlayer2(int newHealth) {
        for (int i = 0; i < _HeartContainersP2.Count; i++) { 
            if (_HeartContainersP2[i] == null) continue;
            _HeartContainersP2[i].SetActive(newHealth > i); 
            //PortraitsP2.sprite = _PortraitsP2[i];
        }
        
        // Changement du portrait
        if (newHealth > 0 && newHealth <= _PortraitsP2.Count) {
            PortraitsP2.sprite = _PortraitsP2[newHealth - 1];
        }
    }
}
