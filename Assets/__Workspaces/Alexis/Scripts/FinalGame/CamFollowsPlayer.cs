using UnityEngine;

public class CamFollowsPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, player.transform.position.y + 10, gameObject.transform.position.z);
    }
}
