using UnityEngine;

public class TrainMoves : MonoBehaviour {
    [SerializeField] private bool _movesToLeft = true;
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player" && _movesToLeft) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500, 0), ForceMode2D.Impulse);
        }

        if (collision.tag == "Player" && !_movesToLeft) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(500, 0), ForceMode2D.Impulse);
        }

        if (collision.tag == "Player2" && _movesToLeft) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500, 0), ForceMode2D.Impulse);
        }

        if (collision.tag == "Player2" && !_movesToLeft){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(500, 0), ForceMode2D.Impulse);
        }
    }
}
