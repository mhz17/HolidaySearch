using HolidaySearch.Models;
using HolidaySearch.Models.Response;
using HolidaySearch.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace HolidaySearch.Repositories
{
	public class FlightRepository : IFlightRepository
	{
		public DataResponse<List<Flight>> LoadFlights(string filePath)
		{
			DataResponse<List<Flight>> response = new();
			try
			{
				using StreamReader reader = new(filePath);
				string json = reader.ReadToEnd();
				List<Flight> flights = JsonConvert.DeserializeObject<List<Flight>>(json);
				response.Success = true;
				response.Data = flights;
				return response;

			} catch(Exception ex)
			{
				response.Success = false;
				response.Error = $"Error Loading file. {ex.Message}";
				return response;
			}
		}
	}
}
