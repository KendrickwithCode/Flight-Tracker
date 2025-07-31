namespace FlightTrackerWPF.Models
{
    public class Flight
    {
        public string? Callsign { get; set; }
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public double Altitude { get; set; }
        public double Speed { get; set; }
    }
}