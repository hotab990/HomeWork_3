public class ElfRaceProvider : StatProvider
{
    public ElfRaceProvider()
    {
        _stats.Add(typeof(AgilityStat), new AgilityStat(10));
        _stats.Add(typeof(StrengthStat), new StrengthStat(4));
        _stats.Add(typeof(IntellectStat), new IntellectStat(5));
    }
}