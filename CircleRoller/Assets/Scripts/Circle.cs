using UnityEngine;

public class Circle : MonoBehaviour
{
    public GameManager GameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser"))
        {
            GameManager.GameOver();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Laser"))
        {
            GameManager.GameOver();
        }
    }
}
