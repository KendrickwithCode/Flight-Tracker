using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FlightTrackerWPF.Models;

namespace FlightTrackerWPF.Services
{
    public class FlightService
    {
        private readonly HttpClient _httpClient;

        public FlightService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Flight>> GetNearbyFlightsAsync(double latitude, double longitude, int radiusKm)
        {
            var flights = new List<Flight>();
            double radiusDeg = radiusKm / 111.0; // approx conversion km -> degrees

            double minLat = latitude - radiusDeg;
            double maxLat = latitude + radiusDeg;
            double minLon = longitude - radiusDeg;
            double maxLon = longitude + radiusDeg;

            string url = $"https://opensky-network.org/api/states/all?lamin={minLat}&lomin={minLon}&lamax={maxLat}&lomax={maxLon}";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode) return flights;

            var json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);

            if (doc.RootElement.TryGetProperty("states", out var states) && states.ValueKind == JsonValueKind.Array)
            {
                foreach (var state in states.EnumerateArray())
                {
                    flights.Add(new Flight
                    {
                        Callsign = state[1].GetString()?.Trim(),
                        Origin = state[2].GetString(),
                        Destination = "Unknown", // OpenSky doesn't provide destination :(
                        Altitude = state[13].ValueKind == JsonValueKind.Number ? state[13].GetDouble() * 3.281 : 0, // meters -> feet
                        Speed = state[9].ValueKind == JsonValueKind.Number ? state[9].GetDouble() * 1.94384 : 0 // m/s -> knots
                    });
                }
            }

            return flights;
        }
    }
}