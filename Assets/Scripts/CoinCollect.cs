using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public int coins = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gem"))
        {
            Debug.Log("Triggered with: " + other.name);
            coins ++;
            Destroy(other.gameObject);
        }        
    }
    
}
