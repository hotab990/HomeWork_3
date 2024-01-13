using UnityEngine;

public class ResoursesSpawner : MonoBehaviour
{
    [SerializeField] private Transform _coinSpawnPoint;
    [SerializeField] private Transform _energySpawnPoint;

    [SerializeField] private AbstractResourcesFactory _factory;

    public void SwitchFactory(AbstractResourcesFactory factory)
    {
        _factory = factory;
        Debug.Log(factory);
    }

    public void SpawnUI()
    {
        DestroyIcons();
        SpawnIcons();

    }

    public void SpawnCoin() => _factory.GetCoin(_coinSpawnPoint);

    public void SpawnEnergy() => _factory.GetEnergy(_energySpawnPoint);

    private void SpawnIcons()
    {
        SpawnCoin();
        SpawnEnergy();
    }
    private void DestroyIcons()
    {
        foreach (Transform child in _coinSpawnPoint)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in _energySpawnPoint)
        {
            Destroy(child.gameObject);
        }
    }

    
}
