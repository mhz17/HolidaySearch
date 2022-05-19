using HolidaySearch.Services.Interfaces;
using HolidaySearch.Services;
using Microsoft.Extensions.DependencyInjection;
using HolidaySearch.Repositories;
using HolidaySearch.Repositories.Interfaces;
using System;

namespace HolidaySearch
{
    public class Program
    {

        private static IFileService _fileService;
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

            _fileService = serviceProvider.GetService<IFileService>();
            _searchService = serviceProvider.GetService<ISearchService>();

            RunMainTask();
        }

        static void RunMainTask()
		{
            Console.WriteLine("Holiday Search");
		}
    }
}
