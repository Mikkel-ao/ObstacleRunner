using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string groundTag = "Foundation";
    public string gameOverSceneName = "";
    public bool isGameOver { get; private set; } = false;

    void OnCollisionEnter(Collision collision) => CheckCollision(collision.gameObject);
    void OnTriggerEnter(Collider other) => CheckCollision(other.gameObject);

    void CheckCollision(GameObject other)
    {
        if (isGameOver) return;

        if (other.CompareTag(groundTag))
        {
            isGameOver = true;
            Debug.Log("Game Over - hit: " + other.name);
            Time.timeScale = 0f;

            if (!string.IsNullOrEmpty(gameOverSceneName))
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene(gameOverSceneName);
            }
        }
    }
}
