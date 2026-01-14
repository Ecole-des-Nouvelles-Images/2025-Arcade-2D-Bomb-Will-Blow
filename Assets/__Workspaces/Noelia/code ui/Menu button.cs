using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Menubutton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    //public Button PlayButton;
    //public Button SettingsButton;
    //public Button CreditButton;
    //public Button ExitButton;
   
    [SerializeField] private float _size = 2f;
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private AnimationCurve _curve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    // private void Start()
   // {
    //    PlayButton.onClick.AddListener(PlayButtonAnimation);
   // }
  //  void PlayButtonAnimation()
    //{
    //    PlayButton.transform.DOScale(1.2f, 0.2f)
    //        .SetEase(Ease.OutBounce)
    //        .OnComplete(() => PlayButton.transform.DOScale(1f, 0.2f));
   // }
    
    //void SettingsButtonAnimation()
    //{
    //    SettingsButton.transform.DOScale(1.2f, 0.2f)
    //        .SetEase(Ease.OutBounce)
    //        .OnComplete(() => PlayButton.transform.DOScale(1f, 0.2f));
    //}
    
   // void CreditButtonAnimation()
    //{
    //    CreditButton.transform.DOScale(1.2f, 0.2f)
    //        .SetEase(Ease.OutBounce)
    //        .OnComplete(() => PlayButton.transform.DOScale(1f, 0.2f));
    //}
    
   // void ExitButtonAnimation()
    //{
   //     ExitButton.transform.DOScale(1.2f, 0.2f)
   //         .SetEase(Ease.OutBounce)
   //         .OnComplete(() => PlayButton.transform.DOScale(1f, 0.2f));
   // }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(_size, _delay).SetEase(_curve).SetUpdate(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1, _delay);
    }

    public void OnSelect(BaseEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    
    
}
