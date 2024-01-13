using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private bool _isOccupied =false;

    public bool IsOccupied => _isOccupied;

    public bool isOccupied() => _isOccupied = true;

    public bool isFree() => _isOccupied = false;
    
}
