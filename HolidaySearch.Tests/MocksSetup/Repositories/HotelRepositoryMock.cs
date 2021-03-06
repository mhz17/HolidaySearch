using HolidaySearch.Models;
using HolidaySearch.Models.Response;
using HolidaySearch.Repositories.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HolidaySearch.Tests.MocksSetup.Repositories
{
	public class HotelRepositoryMock
	{
		public readonly Mock<IHotelRepository> _hotelRepository;

		public HotelRepositoryMock()
		{
			_hotelRepository = new Mock<IHotelRepository>();
		} 

		public void SetupLoadHotels(string filePath, DataResponse<List<Hotel>> hotels)
		{
			_hotelRepository.Setup(a => a.LoadHotels(filePath)).Returns(hotels);
		}
	}
}
