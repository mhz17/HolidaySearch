using HolidaySearch.Constants;
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
				response.Error = Errors.InvalidRequest;
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

			List<HolidaySearchResponse> holidays = Search(searchRequest, flights.Data, hotels.Data);
			HolidaySearchResponse holidayResult = holidays?.Count > 0 ? holidays?.OrderBy(a => a.TotalPrice)?.First(): null;

			if (holidayResult == null)
			{
				response.Success = false;
				response.Error = Errors.NoHolidaysFound;
				return response;
			} else
			{
				response.Success = true;
				response.Data = holidayResult;
				return response;
			}
		}

		private static List<HolidaySearchResponse> Search(HolidaySearchRequest searchRequest, List<Flight> flights, List<Hotel> hotels)
		{
			List<HolidaySearchResponse> response = new();
			var departingFrom = GetDepartureAirports(searchRequest.DepartingFrom);
			List<Flight> matchingFlights = flights.Where(a => (departingFrom == null || departingFrom.Contains(a.From?.ToLower())) && a.To?.ToLower() == searchRequest.TravelingTo?.ToLower() && a.DepratureDate == DateTime.Parse(searchRequest.DepartureDate))?.OrderBy(a => a.Price)?.ToList();
			List<Hotel> matchingHotels = hotels.Where(a => a.LocalAirports.Any(b => b?.ToLower() == searchRequest.TravelingTo?.ToLower()) && a.ArrivalDate == DateTime.Parse(searchRequest.DepartureDate) && a.Nights == int.Parse(searchRequest.Duration))?.OrderBy(a => a.PricePerNight * a.Nights)?.ToList();

			foreach (Flight flight in matchingFlights)
			{
				foreach (Hotel hotel in matchingHotels)
				{
					response.Add(new HolidaySearchResponse()
					{
						Flight = flight,
						Hotel = hotel,
						TotalPrice = flight.Price + (hotel.PricePerNight * hotel.Nights)
					});
				}
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
					"ltn",
					"lgw",
					"lhr",
					"lcy"
				};
			}

			return new() { airport?.ToLower() };
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
