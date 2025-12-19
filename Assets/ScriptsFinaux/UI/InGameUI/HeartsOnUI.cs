using System;
using System.Collections.Generic;
using UnityEngine;

public class HeartsOnUI : MonoBehaviour
{
    public static HeartsOnUI Instance;
    
    [SerializeField] private List<GameObject> _HeartContainersP1;
    [SerializeField] private List<GameObject> _HeartContainersP2;

    private void Awake() {
        Instance = this;
    }

    public void DislayHeathPlayer1(int newHealth) {
        for (int i = 0; i < _HeartContainersP1.Count; i++) {
            if (_HeartContainersP1[i] == null) continue;
            _HeartContainersP1[i].SetActive(newHealth > i);
            
        }
    }
    
    public void DislayHeathPlayer2(int newHealth) {
        for (int i = 0; i < _HeartContainersP2.Count; i++) { 
            if (_HeartContainersP2[i] == null) continue;
                _HeartContainersP2[i].SetActive(newHealth > i);
        }
    }
}
