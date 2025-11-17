using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Vector2 Move;
    
    [SerializeField] private float MoveSpeed = 5;
    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            DoLocomotion();
            //_rb.velocity = new Vector2(Move.x * MoveSpeed, _rb.velocity.y);
        }
    }

    void DoLocomotion()
    {
        _rb.linearVelocity = new Vector2(Move.x * MoveSpeed * Time.deltaTime, _rb.linearVelocity.y);
    }
    
}
