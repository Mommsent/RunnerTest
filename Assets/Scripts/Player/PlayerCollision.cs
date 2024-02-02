using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Obstacle")
        {
            gameManager.EndGame();
        }
    }
}
