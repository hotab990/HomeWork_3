public class GeniousProvider : StatProviderDecorator
{
    private readonly int _modifier;

    public GeniousProvider(IStatProvider statProvider, int modifier) : base(statProvider)
    {
        _modifier = modifier;
    }

    public override T GetStat<T>()
    {
        return typeof(T) switch
        {
            { } t when t == typeof(StrengthStat) => (T)(_statProvider.GetStat<T>().Divide(_statProvider.GetStat<T>(), _modifier)),
            { } t when t == typeof(IntellectStat) => (T)(_statProvider.GetStat<T>().Multiply(_statProvider.GetStat<T>(), _modifier)),
            _ => _statProvider.GetStat<T>()
        };
    }
}