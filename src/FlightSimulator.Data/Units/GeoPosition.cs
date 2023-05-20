using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Data.Units;
public readonly struct GeoPosition : IComparable<GeoPosition>, IEquatable<GeoPosition>, IComparable
{
    public readonly double latitude;
    public readonly double longitude;
    public GeoPosition(double latitude, double longitude)
    {
        if (latitude < -90 || latitude > 90)
            throw new ArgumentOutOfRangeException(nameof(latitude), "Latitude should be between -90 and 90");

        if (longitude < -180 || longitude > 180)
            throw new ArgumentOutOfRangeException(nameof(longitude), "Longitude should be between -180 and 180");

        this.latitude = latitude;
        this.longitude = longitude;
    }

    public GeoPosition(int latdegrees, double latminutes, int longdegrees, double longminutes) : 
        this(latdegrees + (latminutes / 60.0), longdegrees + (longminutes / 60.0)) { }

    public GeoPosition(int latdegrees, int latminutes, double latseconds, int longdegrees, int longminutes, double longseconds) :
        this(latdegrees + (latminutes / 60.0) + (latseconds / 3600.0),
             longdegrees + (longminutes / 60.0) + (longseconds / 3600.0)) { }

    public static bool operator ==(GeoPosition left, GeoPosition right) => left.Equals(right);
    public static bool operator !=(GeoPosition left, GeoPosition right) => !(left == right);
    public static bool operator <(GeoPosition left, GeoPosition right) => left.CompareTo(right) < 0;
    public static bool operator <=(GeoPosition left, GeoPosition right) => left.CompareTo(right) <= 0;
    public static bool operator >(GeoPosition left, GeoPosition right) => left.CompareTo(right) > 0;
    public static bool operator >=(GeoPosition left, GeoPosition right) => left.CompareTo(right) >= 0;
    public int CompareTo(GeoPosition other) => (latitude, longitude).CompareTo((other.latitude, other.longitude));
    public bool Equals(GeoPosition other) => (latitude, longitude).Equals((other.latitude, other.longitude));
    public int CompareTo(object? obj)
    {
        if (obj == null)
            return 1;

        if (obj is GeoPosition gp)
        {
            int result;
            result = latitude.CompareTo(gp.latitude);
            if (result == 0)
                result = longitude.CompareTo(gp.longitude);

            return result;
        }

        throw new ArgumentException("Object must be a GeoPosition", nameof(obj));
    }
    public override bool Equals(object? obj) => obj is GeoPosition obj2 && Equals(obj2);
    public override int GetHashCode() => (longitude, latitude).GetHashCode();

}
