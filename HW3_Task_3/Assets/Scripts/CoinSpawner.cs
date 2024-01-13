using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private float _spawnCooldown;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private CoinFactory _coinFactory;
    [SerializeField] private Coin _coinPrefab;

    private Coroutine _spawn;
    private Transform _currentSpawnPoint;
    public void StartWork()
    {
        StopWork();
        
        _spawn = StartCoroutine(Spawn());
    }

    public void StopWork()
    {
        if (_spawn != null)
            StopCoroutine(_spawn);
    }

    private IEnumerator Spawn()
    {
        while(CanSpawn())
        {
            
            _currentSpawnPoint = _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)];

            if (_currentSpawnPoint.GetComponent<SpawnPoint>().IsOccupied != true)
            {
                Coin coin = _coinFactory.Get(_coinPrefab);
                coin.MoveTo(_currentSpawnPoint.position);
                _currentSpawnPoint.GetComponent<SpawnPoint>().isOccupied();
                yield return new WaitForSeconds(_spawnCooldown);
            }
            
        }
    }

    public bool CanSpawn()
    {
        int counter = _spawnPoints.Count;
        for(int i = 0; i < _spawnPoints.Count; i++)
        {
            if (_spawnPoints[i].GetComponent<SpawnPoint>().IsOccupied == true)
            {
                counter -= 1;
            }
            

        }
        if (counter <= 0)
            return false;
        else
            return true;
    }

}