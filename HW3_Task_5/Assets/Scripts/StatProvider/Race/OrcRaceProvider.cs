public class OrcRaceProvider : StatProvider
{
    public OrcRaceProvider()
    {
        _stats.Add(typeof(AgilityStat), new AgilityStat(5));
        _stats.Add(typeof(StrengthStat), new StrengthStat(2));
        _stats.Add(typeof(IntellectStat), new IntellectStat(2));
    }
}