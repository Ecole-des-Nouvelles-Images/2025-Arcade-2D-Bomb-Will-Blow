using System;
using UnityEngine;
using UnityEngine.UI;

public class MinimapAdvancement : MonoBehaviour
{
    [Header("SlidersReferences")]
    [SerializeField] private Image Player1Slider;
    [SerializeField] private Image Player2Slider;
    
    [Space(4), Header("Player references")]
    [SerializeField] private GameObject Player1;
    [SerializeField] private GameObject Player2;

    private void Update()
    {
        Player1Slider.fillAmount = Player1.transform.position.y / 185;
        Player2Slider.fillAmount = Player2.transform.position.y / 185;
    }
}
