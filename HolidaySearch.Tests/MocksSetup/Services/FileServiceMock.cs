using HolidaySearch.Models;
using HolidaySearch.Models.Response;
using HolidaySearch.Services.Interfaces;
using Moq;
using System.Collections.Generic;

namespace HolidaySearch.Tests.MocksSetup.Repositories
{
	public class FileServiceMock
	{
		public readonly Mock<IFileService> _fileServiceMock;

		public FileServiceMock()
		{
			_fileServiceMock = new Mock<IFileService>();
		} 

		public void SetupLoadFlights(DataResponse<List<Flight>> flights)
		{
			_fileServiceMock.Setup(a => a.LoadFlights()).Returns(flights);
		}

		public void SetupLoadHotels(DataResponse<List<Hotel>> hotels)
		{
			_fileServiceMock.Setup(a => a.LoadHotels()).Returns(hotels);
		}
	}
}
