public class WizardClassProvider : StatProviderDecorator
{
    private readonly int _modifier;

    public WizardClassProvider(IStatProvider statProvider, int modifier) : base(statProvider)
    {
        _modifier = modifier;
    }

    public override T GetStat<T>()
    {
        return typeof(T) switch
        {
            { } t when t == typeof(IntellectStat) => (T)(_statProvider.GetStat<T>().Multiply(_statProvider.GetStat<T>(), _modifier)),
            _ => _statProvider.GetStat<T>()
        };
    }
}