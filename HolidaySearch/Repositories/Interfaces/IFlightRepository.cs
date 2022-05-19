using HolidaySearch.Models;
using HolidaySearch.Models.Response;
using System.Collections.Generic;

namespace HolidaySearch.Repositories.Interfaces
{
	public interface IFlightRepository
	{
		DataResponse<List<Flight>> LoadFlights(string filePath);
	}
}
