using HolidaySearch.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HolidaySearch.Repositories.Interfaces
{
	public interface IHotelRepository
	{
		Task<List<Hotel>> LoadHotels();
	}
}
