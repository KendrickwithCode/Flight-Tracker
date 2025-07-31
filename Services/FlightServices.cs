using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FlightTrackerWPF.Models;
using Microsoft.Extensions.Configuration;

namespace FlightTrackerWPF.Services
{
    public class FlightService
    {
        private readonly HttpClient _httpClient;

        public FlightService()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            string apiKey = config["AeroDataBox:ApiKey"];

            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", apiKey);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", "aerodatabox.p.rapidapi.com");
        }

        public async Task<List<Flight>> GetNearbyFlightsAsync(double latitude, double longitude, int radius)
        {
            var flights = new List<Flight>();

            string url = $"https://aerodatabox.p.rapidapi.com/flights/airborne?lat={latitude}&lon={longitude}&radius={radius}";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return flights;

            var json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);

            if (doc.RootElement.TryGetProperty("aircraft", out var aircraftArray) && aircraftArray.ValueKind == JsonValueKind.Array)
            {
                foreach (var aircraft in aircraftArray.EnumerateArray())
                {
                    flights.Add(new Flight
                    {
                        Callsign = aircraft.GetProperty("reg").GetString(),
                        Origin = aircraft.GetProperty("origin").GetProperty("iata").GetString(),
                        Destination = aircraft.GetProperty("destination").GetProperty("iata").GetString(),
                        Altitude = aircraft.GetProperty("alt").GetDouble(),
                        Speed = aircraft.GetProperty("spd").GetDouble()
                    });
                }
            }

            return flights;
        }
    }
}
