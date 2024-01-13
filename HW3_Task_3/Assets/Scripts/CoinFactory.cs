using System;
using UnityEngine;

public class CoinFactory : MonoBehaviour
{

    public Coin Get(Coin coin)
    {
        Coin instance = Instantiate(coin);
       
        return instance;
    }
}