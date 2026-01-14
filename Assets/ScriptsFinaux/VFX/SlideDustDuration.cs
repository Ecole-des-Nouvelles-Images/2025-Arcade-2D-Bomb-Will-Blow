using UnityEngine;

public class SlideDustDuration : MonoBehaviour
{
    [SerializeField] private float _maxDuration;
    private float _slideDustDuration;
    
    // Update is called once per frame
    void Update()
    {
        _slideDustDuration += Time.deltaTime;
        if (_slideDustDuration >= _maxDuration)
        {
            Destroy(gameObject);
        }
    }
}