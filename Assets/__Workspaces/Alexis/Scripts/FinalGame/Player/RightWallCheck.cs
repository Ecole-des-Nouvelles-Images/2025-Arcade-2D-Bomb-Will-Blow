using __Workspaces.Alexis.Scripts.FinalGame;
using __Workspaces.Alexis.Scripts.FinalGame.Player;
using UnityEngine;

public class RightWallCheck : MonoBehaviour
{
    public GameObject RightWallRaycastStart;
    private PlayerController player;
    void Awake()
    {
        player = gameObject.GetComponent<PlayerController>();
    }

    void Update()
    {
        RightWallCheckRaycast();
    }
    
    void RightWallCheckRaycast()
    {
        RaycastHit2D hit  = Physics2D.Raycast(RightWallRaycastStart.transform.position, new Vector2(1,0), 0.1f, LayerMask.GetMask("Wall"));
        if (hit.collider != null)
        {
            player.IsOnRightWall = true;
            player.CanJumpToLeftWall = true;
        }
        else
        {
            player.IsOnRightWall = false;
            player.CanJumpToLeftWall = true;
        }
    }
}
