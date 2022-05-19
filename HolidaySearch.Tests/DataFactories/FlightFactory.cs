using HolidaySearch.Models;
using HolidaySearch.Models.Response;
using System;
using System.Collections.Generic;

namespace HolidaySearch.Tests.DataFactories
{
	public class FlightFactory
	{
		public static Flight Flight => new()
		{
			Id = 1,
			Airline = "Test Airline",
			DepratureDate = DateTime.Now,
			Price = 150,
			From = "AMD",
			To = "LHD"
		};

		public static List<Flight> Flights => new()
		{
			new Flight {
				Id = 1,
				Airline = "Test Airline",
				DepratureDate = DateTime.Now,
				Price = 150,
				From = "AMD",
				To = "LHD"
			},
			new Flight {
				Id = 2,
				Airline = "Test Airline",
				DepratureDate = DateTime.Now,
				Price = 150,
				From = "AMD",
				To = "LHD"	
			}
		};

		public static DataResponse<List<Flight>> ValidDataResponse => new DataResponse<List<Flight>>() { Data = Flights, Success = true };
		public static DataResponse<List<Flight>> InValidDataResponse => new DataResponse<List<Flight>>() { Data = null, Success = false, Error = "Error" };
	}
}
