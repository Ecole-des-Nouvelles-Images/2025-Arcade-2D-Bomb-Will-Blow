using System;
using UnityEngine;

//public class RotationFan : MonoBehaviour
public class Rotate : MonoBehaviour
{
    public bool rotateX = false;
    public bool rotateY = false;
    public bool rotateZ = true;
    
    public float speed = 50f;
    void Update()
    {
        Vector3 rotation = Vector3.zero;
        if (rotateX)
            {
            rotation += Vector3.right;
            }
        if (rotateY)
            {
            rotation += Vector3.up;
            }
        if (rotateZ)
            {
            rotation += Vector3.forward;
            }
        
        transform.Rotate(rotation * speed * Time.deltaTime);
    }
}