using HolidaySearch.Models;
using HolidaySearch.Models.Response;
using System.Collections.Generic;

namespace HolidaySearch.Services.Interfaces
{
	public interface IFileService
	{
		public DataResponse<List<Flight>> LoadFlights();
		public DataResponse<List<Hotel>> LoadHotels();
	}
}
