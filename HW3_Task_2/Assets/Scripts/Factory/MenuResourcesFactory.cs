using UnityEngine;

public class MenuResoursesFactory : AbstractResourcesFactory
{
    [SerializeField] private MenuCoin _menuCoin;
    [SerializeField] private MenuEnergy _menuEnergy;

    public override BaseCoin GetCoin(Transform parent) => Instantiate(_menuCoin, parent);

    public override BaseEnergy GetEnergy(Transform parent) => Instantiate(_menuEnergy, parent);
}
