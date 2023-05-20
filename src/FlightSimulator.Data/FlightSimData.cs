using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Data;
public sealed class FlightSimData
{
    public DateTime DataDateTime { get; internal set; }
    public SimulatorData Simulator { get; internal set; }
    public AircraftData Aircraft { get; internal set; }
    public Airport NearestAirport { get; internal set; }
    public WeatherData Weather { get; internal set; }
    public long WatchDog { get; internal set; }

    internal FlightSimData() { }
}
