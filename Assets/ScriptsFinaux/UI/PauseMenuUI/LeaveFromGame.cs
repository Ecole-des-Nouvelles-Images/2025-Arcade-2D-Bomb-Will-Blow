using UnityEngine;

public class LeaveFromGame : MonoBehaviour
{
    [SerializeField] private GameObject _Pause;
    [SerializeField] private GameObject _ConfirmScreen;
    
    public void GoToConfirmScreen() {
        _Pause.SetActive(false);
        _ConfirmScreen.SetActive(true);
    }
}
