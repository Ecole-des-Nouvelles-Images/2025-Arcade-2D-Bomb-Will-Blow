using UnityEngine;

public class VFXDurationScript : MonoBehaviour
{
    [SerializeField] private GameObject VFX;
    [SerializeField] private float _VFXDuration;
    
    private float _timer;

    void OnEnable()
    {
        _timer = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (_timer <= _VFXDuration)
        {
            _timer += Time.deltaTime;
        }

        if (_timer >= _VFXDuration)
        {
            VFX.SetActive(false);
        }
    }
}
