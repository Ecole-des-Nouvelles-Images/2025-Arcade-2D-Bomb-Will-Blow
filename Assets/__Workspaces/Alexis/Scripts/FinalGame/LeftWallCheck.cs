using UnityEngine;

public class LeftWallCheck : MonoBehaviour
{
    private PlayerControllerFinal player;
    void Awake()
    {
        player = gameObject.GetComponent<PlayerControllerFinal>();
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "LeftWall")
        {
            player.IsOnLeftWall = true;
            player.CanJumpToRightWall = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "LeftWall")
        {
            player.IsOnLeftWall = false;
            player.CanJumpToRightWall = false;
        }
    }
    
}
