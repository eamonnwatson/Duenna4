using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Data.Units;
public readonly struct Velocity : IComparable<Velocity>, IEquatable<Velocity>, IComparable
{
    private const double KNOTS_PER_MACH = 666.739;
    private const double KNOTS_PER_METRESPS = 1.94384;
    private const double KNOTS_PER_MPH = 0.868976;
    private const double KNOTS_PER_FPS = 0.592484;
    private const double KNOTS_PER_KPH = 0.539957;
    private const double KNOTS_PER_FPM = 0.00987473;

    private readonly double velocity;
    public double Mach { get => velocity / KNOTS_PER_MACH; }
    public double MPS { get => velocity / KNOTS_PER_METRESPS; }
    public double MPH { get => velocity / KNOTS_PER_MPH; }
    public double FPS { get => velocity / KNOTS_PER_FPS; }
    public double KPH { get => velocity / KNOTS_PER_KPH; }
    public double FPM { get => velocity / KNOTS_PER_FPM; }
    public Velocity(double knots) => velocity = knots;
    public static Velocity FromMach(double mach) => new(mach * KNOTS_PER_MACH);
    public static Velocity FromMPS(double mps) => new(mps * KNOTS_PER_METRESPS);
    public static Velocity FromMPH(double mph) => new(mph * KNOTS_PER_MPH);
    public static Velocity FromFPS(double fps) => new(fps * KNOTS_PER_FPS);
    public static Velocity FromKPH(double kph) => new(kph * KNOTS_PER_KPH);
    public static Velocity FromFPM(double fpm) => new(fpm * KNOTS_PER_FPM);

    public static Velocity operator +(Velocity a) => a;
    public static Velocity operator -(Velocity a) => new(-a.velocity);
    public static Velocity operator +(Velocity left, Velocity right) => new(left.velocity + right.velocity);
    public static Velocity operator -(Velocity left, Velocity right) => new(left.velocity - right.velocity);
    public static Velocity operator *(Velocity left, Velocity right) => new(left.velocity * right.velocity);
    public static Velocity operator /(Velocity left, Velocity right)
    {
        if (right.velocity == 0)
            throw new DivideByZeroException();

        return new(left.velocity / right.velocity);
    }
    public static bool operator ==(Velocity left, Velocity right) => left.Equals(right);
    public static bool operator !=(Velocity left, Velocity right) => !(left == right);
    public static bool operator <(Velocity left, Velocity right) => left.CompareTo(right) < 0;
    public static bool operator <=(Velocity left, Velocity right) => left.CompareTo(right) <= 0;
    public static bool operator >(Velocity left, Velocity right) => left.CompareTo(right) > 0;
    public static bool operator >=(Velocity left, Velocity right) => left.CompareTo(right) >= 0;
    public int CompareTo(Velocity other) => velocity.CompareTo(other.velocity);
    public bool Equals(Velocity other) => velocity.Equals(other.velocity);
    public int CompareTo(object? obj) => velocity.CompareTo(obj);
    public override bool Equals(object? obj) => obj is Velocity obj2 && Equals(obj2);
    public override int GetHashCode() => velocity.GetHashCode();

}
