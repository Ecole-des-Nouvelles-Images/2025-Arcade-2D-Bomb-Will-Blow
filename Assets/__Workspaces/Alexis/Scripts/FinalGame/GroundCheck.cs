using System;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private PlayerControllerFinal player;
    void Awake()
    {
        player = gameObject.GetComponent<PlayerControllerFinal>();
    }

    private void Update()
    {
        GroundcheckRaycast();
    }

    private void GroundcheckRaycast()
    { 
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.3f, LayerMask.GetMask("Ground")); 
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
