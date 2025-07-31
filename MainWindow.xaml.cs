using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using FlightTrackerWPF.Models;
using FlightTrackerWPF.Services;

namespace FlightTrackerWPF
{
    public partial class MainWindow : Window
    {
        private readonly FlightService _flightService;

        public MainWindow()
        {
            InitializeComponent();
            _flightService = new FlightService();
        }

        private async void FetchFlights_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double latitude = double.Parse(LatitudeInput.Text);
                double longitude = double.Parse(LongitudeInput.Text);
                int radius = int.Parse(RadiusInput.Text);

                FlightsGrid.ItemsSource = null;
                FlightsGrid.ItemsSource = await _flightService.GetNearbyFlightsAsync(latitude, longitude, radius);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}