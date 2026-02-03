using System;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if (playerInventory != null)
        {
            playerInventory.CoinCollected();    
            gameObject.SetActive(false);
        }
    }
}
