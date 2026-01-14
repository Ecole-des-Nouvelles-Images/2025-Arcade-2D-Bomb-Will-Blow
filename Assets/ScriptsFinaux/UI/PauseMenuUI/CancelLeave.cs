using UnityEngine;

public class CancelLeave : MonoBehaviour
{
    [SerializeField] private GameObject _Pause;
    [SerializeField] private GameObject _ConfirmScreen;
    
    public void BackToPause() {
        _ConfirmScreen.SetActive(false);
        _Pause.SetActive(true);
    }
}
