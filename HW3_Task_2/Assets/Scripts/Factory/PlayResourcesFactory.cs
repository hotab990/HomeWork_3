using UnityEngine;

public class PlayResoursesFactory : AbstractResourcesFactory
{
    [SerializeField] private PlayCoin _playCoin;
    [SerializeField] private PlayEnergy _playEnergy;

    public override BaseCoin GetCoin(Transform parent) => Instantiate(_playCoin, parent);

    public override BaseEnergy GetEnergy(Transform parent) => Instantiate(_playEnergy, parent);
}
