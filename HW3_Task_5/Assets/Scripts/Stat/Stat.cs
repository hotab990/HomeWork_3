using System;

public abstract class Stat
{
    private int _value;

    protected Stat(int value)
    {
        Value = value;
    }

    public int Value
    {
        get => _value;
        private set => _value = Math.Clamp(value, 1, 100);
    }

    public Stat Increase(Stat a, int b)
    {
        a.Value += b;
        return a;
    }

    public Stat Decrease(Stat a, int b)
    {
        a.Value -= b;
        return a;
    }

    public Stat Multiply(Stat a, int b)
    {

        a.Value *= b;
        return a;
    }

    public Stat Divide(Stat a, int b)
    {
        a.Value /= b;
        return a;
    }
}
