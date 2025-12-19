using System;
using ScriptsFinaux;
using ScriptsFinaux.Player;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private PlayerController player;
    void Awake()
    {
        player = gameObject.GetComponent<PlayerController>();
    }

    private void Update()
    {
        GroundcheckRaycast();
    }

    private void GroundcheckRaycast()
    { 
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.05f, LayerMask.GetMask("Ground")); 
        if( hit.collider != null) 
        { 
            player.IsGrounded = true;
        }
        else 
        { 
            player.IsGrounded = false;
        }
    }
}
