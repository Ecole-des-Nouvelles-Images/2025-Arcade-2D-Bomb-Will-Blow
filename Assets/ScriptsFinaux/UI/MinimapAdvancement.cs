using System;
using UnityEngine;
using UnityEngine.UI;

public class MinimapAdvancement : MonoBehaviour
{
    [Header("SlidersReferences")]
    [SerializeField] private Slider Player1Slider;
    [SerializeField] private Slider Player2Slider;
    
    [Space(4), Header("Player references")]
    [SerializeField] private GameObject Player1;
    [SerializeField] private GameObject Player2;

    private void Update()
    {
        Player1Slider.value = Player1.transform.position.y;
        Player2Slider.value = Player2.transform.position.y;
    }
}
