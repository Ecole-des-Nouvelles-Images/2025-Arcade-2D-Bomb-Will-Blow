using UnityEngine;
using System.Collections;

using UnityEngine;
using System.Collections;

public class ApparitionPerso : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Apparition());
    }

    IEnumerator Apparition()
    {
        // Désactive l'Animator
        animator.enabled = false;

        // Temps d'attente (durée de l'effet)
        yield return new WaitForSeconds(0.2f);

        // Réactive l'Animator
        animator.enabled = true;
    }
}