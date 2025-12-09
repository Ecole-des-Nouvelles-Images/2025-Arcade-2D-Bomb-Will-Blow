using UnityEngine;

public class CamFollowsPlayer2 : MonoBehaviour
{
    private GameObject player;

    private bool _foundPlayer;
    
    void Update()
    {
        if (!_foundPlayer)
        {
            player = GameObject.FindGameObjectWithTag("Player2");
        }
        
        if (player.transform.position.y >= -290)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, player.transform.position.y + 2, gameObject.transform.position.z);
        }

        if (player.transform.position.y >= -115 && player.transform.position.x >= 6.5)
        {
            gameObject.transform.position = new Vector3(player.transform.position.x - 6.5f, player.transform.position.y + 2, gameObject.transform.position.z);
        }
    }
}
