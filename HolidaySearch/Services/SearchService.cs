using HolidaySearch.Models;
using HolidaySearch.Models.Request;
using HolidaySearch.Models.Response;
using HolidaySearch.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HolidaySearch.Services
{
	public class SearchService : ISearchService
	{
		private readonly IFileService _fileService;
		public SearchService(IFileService fileService)
		{
			_fileService = fileService;
		}

		public DataResponse<HolidaySearchResponse> SearchHolidays(HolidaySearchRequest searchRequest)
		{
			DataResponse<HolidaySearchResponse> response = new();
			if (searchRequest == null || !RequestValid(searchRequest))
			{
				response.Success = false;
				response.Error = "Invalid request";
				return response;
			}

			DataResponse<List<Flight>> flights = _fileService.LoadFlights();
			if (!flights.Success && flights.Data?.Count > 0)
			{
				response.Success = false;
				response.Error = flights.Error;
				return response;
			}

			DataResponse<List<Hotel>> hotels = _fileService.LoadHotels();
			if (!hotels.Success && hotels.Data?.Count > 0)
			{
				response.Success = false;
				response.Error = hotels.Error;
				return response;
			}

			HolidaySearchResponse holidayResult = Search(searchRequest, flights.Data, hotels.Data);
			if (holidayResult == null)
			{
				response.Success = false;
				response.Error = "No Holidays found";
				return response;
			} else
			{
				response.Success = true;
				response.Data = holidayResult;
				return response;
			}
		}

		private static HolidaySearchResponse Search(HolidaySearchRequest searchRequest, List<Flight> flights, List<Hotel> hotels)
		{
			HolidaySearchResponse response = new();
			var departingFrom = GetDepartureAirports(searchRequest.DepartingFrom);
			List<Flight> matchingFlights = flights.Where(a => (departingFrom == null || departingFrom.Contains(a.From)) && a.To == searchRequest.TravelingTo && a.DepratureDate == DateTime.Parse(searchRequest.DepartureDate))?.OrderBy(a => a.Price)?.ToList();
			List<Hotel> matchingHotels = hotels.Where(a => a.LocalAirports.Any(b => b == searchRequest.TravelingTo) && a.ArrivalDate == DateTime.Parse(searchRequest.DepartureDate) && a.Nights == int.Parse(searchRequest.Duration))?.OrderBy(a => a.PricePerNight)?.ToList();

			if (matchingFlights.Any() && matchingHotels.Any())
			{
				response.TotalPrice = matchingFlights.First().Price + matchingHotels.First().PricePerNight;
				response.Flight = matchingFlights.First();
				response.Hotel = matchingHotels.First();
			}

			return response;
		}

		private static List<string> GetDepartureAirports(string airport)
		{
			if (airport.ToLower().Equals("any airport"))
			{
				return null;
			} else if (airport.ToLower().Equals("any london airport"))
			{
				return new()
				{
					"LTN",
					"LGW",
					"LHR",
					"LCY"
				};
			}

			return new() { airport };
		}

		private static bool RequestValid(HolidaySearchRequest searchRequest)
		{
			int.TryParse(searchRequest.Duration, out int duration);
			DateTime.TryParse(searchRequest.DepartureDate, out DateTime depDate);

			return !string.IsNullOrEmpty(searchRequest.DepartingFrom) &&
				!string.IsNullOrEmpty(searchRequest.DepartureDate) &&
				!string.IsNullOrEmpty(searchRequest.TravelingTo) &&
				!string.IsNullOrEmpty(searchRequest.Duration) &&
				duration > 0 && depDate != DateTime.MinValue;
		}
	}
}
