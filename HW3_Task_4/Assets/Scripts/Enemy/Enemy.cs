using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public event Action<Enemy> Died;
    public event Action<Enemy> Spawned;
    //Какая то общая логика врага: передвижение, жизни и тп.

    public void MoveTo(Vector3 position) => transform.position = position;

    public void Kill()
    {
        Died?.Invoke(this);
        Destroy(gameObject);
    }

    public void Spawn()
    {
        Spawned?.Invoke(this);
        Debug.Log("Spawned");
    }
}
