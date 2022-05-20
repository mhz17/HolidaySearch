using HolidaySearch.Services.Interfaces;
using HolidaySearch.Services;
using Microsoft.Extensions.DependencyInjection;
using HolidaySearch.Repositories;
using HolidaySearch.Repositories.Interfaces;
using System;
using HolidaySearch.Models.Request;
using HolidaySearch.Models.Response;
using HolidaySearch.Constants;

namespace HolidaySearch
{
    public class Program
    {

        private static ISearchService _searchService;

        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IFileService, FileService>()
                .AddTransient<ISearchService, SearchService>()
                .AddTransient<IHotelRepository, HotelRepository>()
                .AddTransient<IFlightRepository, FlightRepository>()
                .AddTransient<IConfigurationService, ConfigurationService>()
                .BuildServiceProvider();

            _searchService = serviceProvider.GetService<ISearchService>();

            RunMainTask();
        }

        static void RunMainTask()
		{
            Console.WriteLine("*** Holiday Search ***");
            Console.WriteLine();
            Console.WriteLine("Departing From:");
            string departingFrom = Console.ReadLine();
            Console.WriteLine("Traveling To:");
            string travelingTo = Console.ReadLine();
            Console.WriteLine("Departure Date:");
            string departureDate = Console.ReadLine();
            Console.WriteLine("Duration:");
            string duration = Console.ReadLine();

            HolidaySearchRequest request = new()
            {
                DepartureDate = departureDate,
                Duration = duration,
                DepartingFrom = departingFrom,
                TravelingTo = travelingTo
            };

            Search(request);

        }

        private static void Search(HolidaySearchRequest request)
		{
            DataResponse<HolidaySearchResponse> response = _searchService.SearchHolidays(request);
            if (response != null)
            {
                if (response.Success && response.Data != null && response.Data?.Flight != null && response.Data?.Hotel != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("**********************");
                    Console.WriteLine();
                    Console.WriteLine("*** Holiday Found ***");
                    Console.WriteLine();
                    Console.WriteLine($"Total Price: {response.Data?.TotalPrice}");
                    Console.WriteLine($"Flight Id: {response.Data?.Flight?.Id}");
                    Console.WriteLine($"Departing From: {response.Data?.Flight?.From}");
                    Console.WriteLine($"Travelling To: {response.Data?.Flight?.To}");
                    Console.WriteLine($"Flight Price: {response.Data?.Flight?.Price}");
                    Console.WriteLine($"Hotel Id: {response.Data?.Hotel?.Id}");
                    Console.WriteLine($"Hotel Name: {response.Data?.Hotel?.Name}");
                    Console.WriteLine($"Hotel Price: {response.Data?.Hotel?.PricePerNight * response.Data?.Hotel?.Nights}");
                    Console.WriteLine();
                    Console.WriteLine("**********************");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(response.Error);
                }
            }
            else
            {
                Console.WriteLine("No Holiday Found. Please try again.");
            }
        }
    }
}
