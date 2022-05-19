using HolidaySearch.Models;
using HolidaySearch.Models.Response;
using System.Collections.Generic;

namespace HolidaySearch.Repositories.Interfaces
{
	public interface IHotelRepository
	{
		DataResponse<List<Hotel>> LoadHotels(string filePath);
	}
}
