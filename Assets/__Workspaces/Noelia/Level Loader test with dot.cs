using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement; // this is DOTween

public class Fader : MonoBehaviour
{
    [SerializeField] private float delayBeforeFadingIn;
    
    [SerializeField] private float fadeDurationSeconds;
    
    [SerializeField] private float _alphaCanva = 1;
    
    public Ease fadeEase = Ease.Linear;
    
    [SerializeField] private AnimationCurve _curve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    
    [SerializeField] private string _namescene;
    
    [SerializeField] private float _alphacanvastart = 0;
    

   
    CanvasGroup canvasGroup;
   
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        // start the canvas invisible
        canvasGroup.alpha = _alphacanvastart;
    }
   
    private void Start()
    {
        canvasGroup.DOFade(_alphaCanva, fadeDurationSeconds).SetDelay(delayBeforeFadingIn).SetEase(_curve).OnComplete(DoTransition);
    }

    private void DoTransition()
    {
        SceneManager.LoadScene(_namescene);
    }
    
}