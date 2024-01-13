public class HumanRaceProvider : StatProvider
{
    public HumanRaceProvider()
    {
        _stats.Add(typeof(AgilityStat), new AgilityStat(6));
        _stats.Add(typeof(StrengthStat), new StrengthStat(6));
        _stats.Add(typeof(IntellectStat), new IntellectStat(7));
    }
}