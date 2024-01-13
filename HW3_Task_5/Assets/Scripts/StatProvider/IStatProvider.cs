public interface IStatProvider
{
    public T GetStat<T>() where T : Stat;
}