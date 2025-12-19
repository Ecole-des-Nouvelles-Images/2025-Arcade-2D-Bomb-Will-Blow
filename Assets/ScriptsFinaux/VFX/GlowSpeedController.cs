using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GlowDesync : MonoBehaviour
{
    [Header("Variation de vitesse")]
    public float minSpeed = 0.9f;
    public float maxSpeed = 1.1f;

    [Header("Décalage initial de l'animation")]
    public float minOffset = 0f;   
    public float maxOffset = 1f;   

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        
        animator.speed = Random.Range(minSpeed, maxSpeed);

       
        animator.Play(0, 0, Random.Range(minOffset, maxOffset));
    }
}