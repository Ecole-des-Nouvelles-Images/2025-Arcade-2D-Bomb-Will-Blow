using System;
using UnityEngine;

public class GravityAugmented : MonoBehaviour
{
    [SerializeField] private float gravityAugmentation;

    private float OldGravity;
    private void OnTriggerEnter2D(Collider2D other)
    {
        OldGravity = other.gameObject.GetComponent<Rigidbody2D>().gravityScale;
        other.gameObject.GetComponent<Rigidbody2D>().gravityScale = gravityAugmentation;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.GetComponent<Rigidbody2D>().gravityScale = OldGravity;
    }
}
