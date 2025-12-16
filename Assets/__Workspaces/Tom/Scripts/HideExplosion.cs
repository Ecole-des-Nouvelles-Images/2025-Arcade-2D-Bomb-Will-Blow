using UnityEngine;

public class ExplosionFX : MonoBehaviour
{
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void DisableChild(GameObject child)
    {
        child.SetActive(false);
    }
}

