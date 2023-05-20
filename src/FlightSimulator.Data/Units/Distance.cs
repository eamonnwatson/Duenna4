using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Data.Units;
public readonly struct Distance : IComparable<Distance>, IEquatable<Distance>, IComparable
{
    // conversion constants
    private const double METRES_PER_NAUTICAL_MILE = 1852;
    private const double METRES_PER_STATUTE_MILE = 1609.34;
    private const double METRES_PER_KILOMETRE = 1000;
    private const double METRES_PER_FOOT = 0.3048;

    private readonly double distance;

    public double NauticalMiles { get => distance / METRES_PER_NAUTICAL_MILE; }
    public double StatuteMiles { get => distance / METRES_PER_STATUTE_MILE; }
    public double Kilometres { get => distance / METRES_PER_KILOMETRE; }
    public double Feet { get => distance / METRES_PER_FOOT; }
    public double Metres { get => distance; }
    public Distance(double metres) => distance = metres;
    public static Distance FromNauticalMiles(double nauticalMiles) => new(nauticalMiles * METRES_PER_NAUTICAL_MILE);
    public static Distance FromStatuteMiles(double statuteMiles) => new(statuteMiles * METRES_PER_STATUTE_MILE);
    public static Distance FromKilometres(double kilometres) => new(kilometres * METRES_PER_KILOMETRE);
    public static Distance FromFeet(double feet) => new(feet * METRES_PER_FOOT);
    public static Distance operator +(Distance a) => a;
    public static Distance operator -(Distance a) => new(-a.distance);
    public static Distance operator +(Distance left, Distance right) => new(left.distance + right.distance);
    public static Distance operator -(Distance left, Distance right) => new(left.distance - right.distance);
    public static Distance operator *(Distance left, Distance right) => new(left.distance * right.distance);
    public static Distance operator /(Distance left, Distance right)
    {
        if (right.distance == 0)
            throw new DivideByZeroException();

        return new(left.distance / right.distance);
    }
    public static bool operator ==(Distance left, Distance right) => left.Equals(right);
    public static bool operator !=(Distance left, Distance right) => !(left == right);
    public static bool operator <(Distance left, Distance right) => left.CompareTo(right) < 0;
    public static bool operator <=(Distance left, Distance right) => left.CompareTo(right) <= 0;
    public static bool operator >(Distance left, Distance right) => left.CompareTo(right) > 0;
    public static bool operator >=(Distance left, Distance right) => left.CompareTo(right) >= 0;
    public int CompareTo(Distance other) => distance.CompareTo(other.distance);
    public bool Equals(Distance other) => distance.Equals(other.distance);
    public int CompareTo(object? obj) => distance.CompareTo(obj);
    public override bool Equals(object? obj) => obj is Distance obj2 && Equals(obj2);
    public override int GetHashCode() => distance.GetHashCode();

}
