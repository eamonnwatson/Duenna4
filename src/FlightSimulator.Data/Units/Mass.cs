using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Data.Units;
public readonly struct Mass : IComparable<Mass>, IEquatable<Mass>, IComparable
{
    private const double KILOGRAMS_PER_POUND = 0.453592;
    private readonly double mass;
    public double Pounds { get => mass / KILOGRAMS_PER_POUND; }
    public double Kilograms { get => mass; }
    public Mass(double kilograms) => mass = kilograms;
    public static Mass FromPounds(double pounds) => new(pounds * KILOGRAMS_PER_POUND);
    public static Mass operator +(Mass a) => a;
    public static Mass operator -(Mass a) => new(-a.mass);
    public static Mass operator +(Mass left, Mass right) => new(left.mass + right.mass);
    public static Mass operator -(Mass left, Mass right) => new(left.mass - right.mass);
    public static Mass operator *(Mass left, Mass right) => new(left.mass * right.mass);
    public static Mass operator /(Mass left, Mass right)
    {
        if (right.mass == 0)
            throw new DivideByZeroException();

        return new(left.mass / right.mass);
    }
    public static bool operator ==(Mass left, Mass right) => left.Equals(right);
    public static bool operator !=(Mass left, Mass right) => !(left == right);
    public static bool operator <(Mass left, Mass right) => left.CompareTo(right) < 0;
    public static bool operator <=(Mass left, Mass right) => left.CompareTo(right) <= 0;
    public static bool operator >(Mass left, Mass right) => left.CompareTo(right) > 0;
    public static bool operator >=(Mass left, Mass right) => left.CompareTo(right) >= 0;
    public int CompareTo(Mass other) => mass.CompareTo(other.mass);
    public bool Equals(Mass other) => mass.Equals(other.mass);
    public int CompareTo(object? obj) => mass.CompareTo(obj);
    public override bool Equals(object? obj) => obj is Mass obj2 && Equals(obj2);
    public override int GetHashCode() => mass.GetHashCode();


}
