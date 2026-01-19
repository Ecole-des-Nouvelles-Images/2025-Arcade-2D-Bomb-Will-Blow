using UnityEngine;

public class RatMovement : MonoBehaviour
{
    [SerializeField] private bool _movesToLeft;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (_movesToLeft) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-50, 0), ForceMode2D.Impulse);
        }
        
        if (!_movesToLeft) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(50, 0), ForceMode2D.Impulse);
        }
    }
}
