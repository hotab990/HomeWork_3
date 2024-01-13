using UnityEngine;

public abstract class AbstractResourcesFactory : MonoBehaviour
{
    public abstract BaseCoin GetCoin(Transform parent);

    public abstract BaseEnergy GetEnergy(Transform parent);
}
