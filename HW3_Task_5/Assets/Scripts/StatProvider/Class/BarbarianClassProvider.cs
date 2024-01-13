public class BarbarianClassProvider : StatProviderDecorator
{
    private readonly int _modifier;

    public BarbarianClassProvider(IStatProvider statProvider, int modifier) : base(statProvider)
    {
        _modifier = modifier;
    }

    public override T GetStat<T>()
    {
        return typeof(T) switch
        {
            { } t when t == typeof(StrengthStat) => (T)(_statProvider.GetStat<T>().Multiply(_statProvider.GetStat<T>(), _modifier)),
            _ => _statProvider.GetStat<T>()
        };
    }
}