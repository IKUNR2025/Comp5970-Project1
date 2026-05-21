using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float fallSpeed = 5f;
    private bool scored = false;

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver())
        {
            return;
        }

        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        if (!scored && transform.position.y < -5f)
        {
            scored = true;
            GameManager.Instance.AddScore();
        }

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    public void SetFallSpeed(float speed)
    {
        fallSpeed = speed;
    }
}