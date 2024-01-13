using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private CoinSpawner _spawner;

    private void Awake()
    {
        _spawner.StartWork();
    }

    
}