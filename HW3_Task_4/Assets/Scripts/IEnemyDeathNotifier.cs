using System;

public interface IEnemyDeathNotifier
{
    event Action<Enemy> DeathNotified;
}