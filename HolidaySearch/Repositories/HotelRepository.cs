using HolidaySearch.Models;
using HolidaySearch.Models.Response;
using HolidaySearch.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace HolidaySearch.Repositories
{
	public class HotelRepository : IHotelRepository
	{
		public DataResponse<List<Hotel>> LoadHotels(string filePath)
		{
			DataResponse<List<Hotel>> response = new();
			try
			{
				using StreamReader reader = new(filePath);
				string json = reader.ReadToEnd();
				List<Hotel> hotels = JsonConvert.DeserializeObject<List<Hotel>>(json);
				response.Success = true;
				response.Data = hotels;
				return response;

			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Error = $"Error Loading file. {ex.Message}";
				return response;
			}
		}
	}
}
