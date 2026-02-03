using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
   public int NumberOfCoins { get; private set; }
   
   
   public void CoinCollected()
   {
       NumberOfCoins++;
   }
}
