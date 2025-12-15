using UnityEngine;

public class CamFollowsPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    void Update()
    {
        if (player.transform.position.y >= 10)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, player.transform.position.y + 2, gameObject.transform.position.z);
        }

        if (player.transform.position.y >= 184 && player.transform.position.x <= -6.5)
        {
            gameObject.transform.position = new Vector3(player.transform.position.x + 6.5f, player.transform.position.y + 2, gameObject.transform.position.z);
        }
    }
}
