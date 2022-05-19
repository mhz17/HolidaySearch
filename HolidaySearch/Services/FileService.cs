using HolidaySearch.Constants;
using HolidaySearch.Models;
using HolidaySearch.Models.Response;
using HolidaySearch.Repositories.Interfaces;
using HolidaySearch.Services.Interfaces;
using System.Collections.Generic;

namespace HolidaySearch.Services
{
	public class FileService : IFileService
	{
		public readonly IHotelRepository _hotelRepository;
		public readonly IFlightRepository _flightRepository;
		public readonly IConfigurationService _configurationService;
		public FileService(IHotelRepository hotelRepository, IFlightRepository flightRepository, IConfigurationService configurationService)
		{
			_hotelRepository = hotelRepository;
			_flightRepository = flightRepository;
			_configurationService = configurationService;
		}

		public DataResponse<List<Flight>> LoadFlights()
		{
			DataResponse<List<Flight>> response = new();
			string path = _configurationService.GetFilePath(FileType.Flights);
			if (string.IsNullOrEmpty(path))
			{
				response.Success = false;
				response.Error = "File Path does not exist";
				return response;
			}
			return _flightRepository.LoadFlights(path);
		}

		public DataResponse<List<Hotel>> LoadHotels()
		{
			DataResponse<List<Hotel>> response = new();
			string path = _configurationService.GetFilePath(FileType.Hotels);
			if (string.IsNullOrEmpty(path))
			{
				response.Success = false;
				response.Error = "File Path does not exist";
				return response;
			}
			return _hotelRepository.LoadHotels(path);
		}
	}
}
