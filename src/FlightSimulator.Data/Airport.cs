using FlightSimulator.Data.Units;

namespace FlightSimulator.Data;

public sealed class Airport
{
    /// <summary>
    /// ICAO name of the airport
    /// </summary>
    public string ICAO { get; internal set; }

    /// <summary>
    /// Name of the airport as given in Flight Simulator
    /// </summary>
    public string AirportName { get; internal set; }

    /// <summary>
    /// Latitude/Longtitude of airport
    /// </summary>
    public GeoPosition Position { get; internal set; }

    /// <summary>
    /// Country of airport
    /// </summary>
    public string Country { get; internal set; }

    /// <summary>
    /// State of Airport
    /// </summary>
    public string State { get; internal set; }

    /// <summary>
    /// City of airport
    /// </summary>
    public string City { get; internal set; }

    /// <summary>
    /// Altitude of airport
    /// </summary>
    public Distance Altitude { get; internal set; }

}