using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private PlayerControllerFinal player;
    void Awake()
    {
        player = gameObject.GetComponent<PlayerControllerFinal>();
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            player.IsGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            player.IsGrounded = false;
        }
    }
}
