using UnityEngine;

public class Score
{
    private IEnemyDeathNotifier _enemyDeathNotifier;
    private EnemyVisitor _enemyVisitor;

    public Score(IEnemyDeathNotifier enemyDeathNotifier)
    {
        _enemyDeathNotifier = enemyDeathNotifier;
        _enemyDeathNotifier.DeathNotified += OnEnemyKilled;

        _enemyVisitor = new EnemyVisitor();
    }

    ~Score() => _enemyDeathNotifier.DeathNotified -= OnEnemyKilled;

    public int Value => _enemyVisitor.Score;

    public void OnEnemyKilled(Enemy enemy)
    {
        _enemyVisitor.Visit(enemy);
        Debug.Log($"Счет: {Value}");
    }

    private class EnemyVisitor : IEnemyVisitor
    {
        public int Score { get; private set; }

        public void Visit(Orc orc) => Score += 20;

        public void Visit(Human human) => Score += 5;

        public void Visit(Elf elf) => Score += 10;

        public void Visit(Enemy enemy) => Visit((dynamic)enemy);
    }
}