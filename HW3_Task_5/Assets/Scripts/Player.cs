using UnityEngine;

public class Player
{
    private readonly string _name;
    private readonly IStatProvider _statProvider;

    public Player(string name, IStatProvider statProvider)
    {
        _name = name;
        _statProvider = statProvider;
    }

    public void PrintStat()
    {
        var intellectStat = _statProvider.GetStat<IntellectStat>();
        var agilityStat = _statProvider.GetStat<AgilityStat>();
        var strengthStat = _statProvider.GetStat<StrengthStat>();

        Debug.Log($"Player: {_name} " +
            $"Интелект: {intellectStat.Value} " +
            $"Ловкость: {agilityStat.Value} " +
            $"Сила: {strengthStat.Value} ");
    }
}
