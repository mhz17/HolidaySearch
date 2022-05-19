using HolidaySearch.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HolidaySearch.Repositories.Interfaces
{
	public interface IFlightRepository
	{
		Task<List<Flight>> LoadFlights();
	}
}
