using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Menubutton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
   
    [SerializeField] private float _size = 2f;
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private AnimationCurve _curve = AnimationCurve.EaseInOut(0, 0, 1, 1);

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
        transform.DOScale(_size, _delay).SetEase(_curve).SetUpdate(true);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        transform.DOScale(1, _delay);
    }
    
}
