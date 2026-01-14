using UnityEngine;


public class FadeFake : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    public void Fade() {
        
        for (float i = 1; i <= 255; i++) {
            
            var spriteRendererColor = spriteRenderer.color;
            spriteRendererColor.a = i / 255;
            Debug.Log(i/255);
        }
    }
}
