using UnityEngine;

public class EndTrigger : MonoBehaviour {

    public GameManager gameManager;

    void OnTriggerEnter (Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (gameManager != null)
            gameManager.EndGame();
    }
    
    void Awake()
    {
        if (gameManager == null)
            gameManager = FindObjectOfType<GameManager>();
    }

}