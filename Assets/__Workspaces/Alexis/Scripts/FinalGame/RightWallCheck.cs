using UnityEngine;

public class RightWallCheck : MonoBehaviour
{
    private PlayerControllerFinal player;
    void Awake()
    {
        player = gameObject.GetComponent<PlayerControllerFinal>();
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "RightWall")
        {
            player.IsOnRightWall = true;
            player.CanJumpToLeftWall = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "RightWall")
        {
            player.IsOnRightWall = false;
        }
    }
    
}
