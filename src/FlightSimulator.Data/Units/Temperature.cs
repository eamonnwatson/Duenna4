using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Data.Units;
public readonly struct Temperature : IComparable<Temperature>, IEquatable<Temperature>, IComparable
{
    public double Centigrade { get => temperature; }
    public double Fahrenheit { get => temperature * 9 / 5 + 32; }
    private readonly double temperature;
    public Temperature(double centigrade)
    {
        if (centigrade < -273.15) 
            throw new ArgumentOutOfRangeException(nameof(centigrade), string.Format("{0} is less than absolute zero.", centigrade));

        temperature = centigrade;
    }
    public static Temperature FromFahrenheit(double fahrenheit) => new ((fahrenheit - 32) * 5 / 9);
    public static Temperature operator +(Temperature a) => a;
    public static Temperature operator -(Temperature a) => new(-a.temperature);
    public static Temperature operator +(Temperature left, Temperature right) => new(left.temperature + right.temperature);
    public static Temperature operator -(Temperature left, Temperature right) => new(left.temperature - right.temperature);
    public static Temperature operator *(Temperature left, Temperature right) => new(left.temperature * right.temperature);
    public static Temperature operator /(Temperature left, Temperature right)
    {
        if (right.temperature == 0)
            throw new DivideByZeroException();

        return new(left.temperature / right.temperature);
    }
    public static bool operator ==(Temperature left, Temperature right) => left.Equals(right);
    public static bool operator !=(Temperature left, Temperature right) => !(left == right);
    public static bool operator <(Temperature left, Temperature right) => left.CompareTo(right) < 0;
    public static bool operator <=(Temperature left, Temperature right) => left.CompareTo(right) <= 0;
    public static bool operator >(Temperature left, Temperature right) => left.CompareTo(right) > 0;
    public static bool operator >=(Temperature left, Temperature right) => left.CompareTo(right) >= 0;
    public int CompareTo(Temperature other) => temperature.CompareTo(other.temperature);
    public bool Equals(Temperature other) => temperature.Equals(other.temperature);
    public int CompareTo(object? obj) => temperature.CompareTo(obj);
    public override bool Equals(object? obj) => obj is Temperature obj2 && Equals(obj2);
    public override int GetHashCode() => temperature.GetHashCode();

}
