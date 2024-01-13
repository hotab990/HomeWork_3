using UnityEngine;

public class Weight : MonoBehaviour
{
    private readonly Spawner _spawner;
    private IEnemySpawnNotifier _enemySpawnNotifier;
    private EnemyVisitor _enemyVisitor;

    private readonly int _weightLimit;

    public Weight(Spawner spawner,IEnemySpawnNotifier enemySpawnNotifier, int weightLimit)
    { 
        _spawner = spawner;

        _enemySpawnNotifier = enemySpawnNotifier;
        _enemySpawnNotifier.SpawnNotified += OnEnemySpawned;

        _enemyVisitor = new EnemyVisitor();

        _weightLimit = weightLimit;
    }

    ~Weight() => _enemySpawnNotifier.SpawnNotified -= OnEnemySpawned;

    public int Value => _enemyVisitor.Weight;

    public void OnEnemySpawned(Enemy enemy)
    {
        _enemyVisitor.Visit(enemy);
        Debug.Log($"Вес: {Value}");
        CheckWeight(Value);
    }

    private void CheckWeight(int weight)
    {
        if (weight >= _weightLimit)
        {
            _spawner.StopWork();

            Debug.Log("Максимальный вес достигнут.");
        }
    }

    private class EnemyVisitor : IEnemyVisitor
    {
        public int Weight { get; private set; }

        public void Visit(Orc orc) => Weight += 20;

        public void Visit(Human human) => Weight += 5;

        public void Visit(Elf elf) => Weight += 10;

        public void Visit(Enemy enemy) => Visit((dynamic)enemy);
    }
}
