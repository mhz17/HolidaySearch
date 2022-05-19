using HolidaySearch.Models;
using HolidaySearch.Repositories.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HolidaySearch.Tests.MocksSetup.Repositories
{
	public class FlightRepositoryMock
	{
		public readonly Mock<IFlightRepository> _flightRepository;

		public FlightRepositoryMock()
		{
			_flightRepository = new Mock<IFlightRepository>();
		} 

		public void SetupLoadFlights(Task<List<Flight>> flights)
		{
			_flightRepository.Setup(a => a.LoadFlights()).Returns(flights);
		}
	}
}
