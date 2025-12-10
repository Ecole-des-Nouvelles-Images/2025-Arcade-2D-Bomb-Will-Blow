using UnityEngine;

public class ExplosionFX : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void DisableChild(GameObject child)
    {
        child.SetActive(false);
    }
}

