using UnityEngine;

public class VisitorBootstrap : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private Score _score;
    private Weight _weight;

    private void Awake()
    {
        _score = new Score(_spawner);
        _weight = new Weight(_spawner,_spawner, _spawner.MaxWeight);
        _spawner.StartWork();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            _spawner.KillRandomEnemy();
    }
}
