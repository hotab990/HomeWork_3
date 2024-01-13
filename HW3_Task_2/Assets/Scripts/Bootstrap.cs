using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private ResoursesSpawner _spawner;

    [SerializeField] private AbstractResourcesFactory _menuFactory;
    [SerializeField] private AbstractResourcesFactory _playFactory;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _spawner.SwitchFactory(_menuFactory);
            _spawner.SpawnUI();
            Debug.Log(_spawner);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _spawner.SwitchFactory(_playFactory);
            _spawner.SpawnUI();
            Debug.Log(_spawner);
        }
    }
}
