using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour, IEnemyDeathNotifier, IEnemySpawnNotifier
{
    public event Action<Enemy> DeathNotified;
    public event Action<Enemy> SpawnNotified;

    public int MaxWeight => _maxWeight;

    [SerializeField, Range(1, 150)] private int _maxWeight;

    [SerializeField] private float _spawnCooldown;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private EnemyFactory _enemyFactory;

    private List<Enemy> _spawnedEnemies = new List<Enemy>();

    private Coroutine _spawn;


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

    public void KillRandomEnemy()
    {
        if (_spawnedEnemies.Count == 0)
            return;

        _spawnedEnemies[UnityEngine.Random.Range(0, _spawnedEnemies.Count)].Kill();
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Enemy enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
            enemy.MoveTo(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].position);
            enemy.Died += OnEnemyDied;
            enemy.Spawned += OnEnemySpawned;
            enemy.Spawn();
            _spawnedEnemies.Add(enemy);
            yield return new WaitForSeconds(_spawnCooldown);
        }
    }

    private void OnEnemyDied(Enemy enemy)
    {
        DeathNotified?.Invoke(enemy);
        enemy.Died -= OnEnemyDied;
        _spawnedEnemies.Remove(enemy);
    }

    private void OnEnemySpawned(Enemy enemy)
    {
        SpawnNotified?.Invoke(enemy);
        enemy.Spawned -= OnEnemySpawned;
    }
}
