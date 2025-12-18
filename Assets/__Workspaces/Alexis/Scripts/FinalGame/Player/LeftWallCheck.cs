using System;
using __Workspaces.Alexis.Scripts.FinalGame;
using __Workspaces.Alexis.Scripts.FinalGame.Player;
using UnityEngine;

public class LeftWallCheck : MonoBehaviour
{
    public GameObject LefWallRaycastStart;
    private PlayerController player;
    
    void Awake()
    {
        player = gameObject.GetComponent<PlayerController>();
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
