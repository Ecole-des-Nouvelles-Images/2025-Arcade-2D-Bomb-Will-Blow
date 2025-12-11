using System;
using UnityEngine;

public class LeftWallCheck : MonoBehaviour
{
    public GameObject LefWallRaycastStart;
    private PlayerControllerFinal player;
    
    void Awake()
    {
        player = gameObject.GetComponent<PlayerControllerFinal>();
    }

    private void Update()
    {
        LeftWallCheckRaycast();
    }

    void LeftWallCheckRaycast()
    {
        RaycastHit2D hit  = Physics2D.Raycast(LefWallRaycastStart.transform.position, new Vector2(-1,0), 0.1f, LayerMask.GetMask("Wall")); 
        if (hit.collider != null)
        {
            player.IsOnLeftWall = true;
            player.CanJumpToRightWall = true;
        }
        else
        {
            player.IsOnLeftWall = false;
            player.CanJumpToRightWall = true;
        }
    }
}
