using HolidaySearch.Constants;
using HolidaySearch.Models;
using HolidaySearch.Models.Response;
using HolidaySearch.Services;
using HolidaySearch.Services.Interfaces;
using HolidaySearch.Tests.DataFactories;
using HolidaySearch.Tests.MocksSetup.Repositories;
using NUnit.Framework;
using System.Collections.Generic;

namespace HolidaySearch.Tests.Services
{
	public class FileServiceTests
	{
		private const string Path = "C://Test//test.json";
		private IFileService _fileService;
		private ConfigurationServiceMock _configurationServiceMock;
		private HotelRepositoryMock _hotelRepositoryMock;
		private FlightRepositoryMock _flightRepositoryMock;

		[SetUp]
		public void Setup()
		{
			_configurationServiceMock = new ConfigurationServiceMock();
			_hotelRepositoryMock = new HotelRepositoryMock();
			_flightRepositoryMock = new FlightRepositoryMock();
			_fileService = new FileService(_hotelRepositoryMock._hotelRepository.Object, _flightRepositoryMock._flightRepository.Object, _configurationServiceMock._configurationService.Object);
		}

		[Test]
		public void LoadFlights_ValidFile_Success()
		{
			_configurationServiceMock.SetupGetFilePath(FileType.Flights, Path);
			_flightRepositoryMock.SetupLoadFlights(Path, FlightFactory.ValidDataResponse);

			DataResponse<List<Flight>> response = _fileService.LoadFlights();
			Assert.Multiple(() =>
			{
				Assert.That(response.Success, Is.True);
				Assert.That(response.Data, Is.Not.Null);
			});
			Assert.That(response.Data, Has.Count.EqualTo(FlightFactory.ValidDataResponse.Data.Count));
		}

		[Test]
		public void LoadFlights_EmptyFile_Failure()
		{
			_configurationServiceMock.SetupGetFilePath(FileType.Flights, null);

			DataResponse<List<Flight>> response = _fileService.LoadFlights();
			Assert.Multiple(() =>
			{
				Assert.That(response.Success, Is.False);
				Assert.That(response.Data, Is.Null);
			});
		}

		[Test]
		public void LoadFlights_LoadingError_Failure()
		{
			_configurationServiceMock.SetupGetFilePath(FileType.Flights, Path);
			_flightRepositoryMock.SetupLoadFlights(Path, FlightFactory.InValidDataResponse);

			DataResponse<List<Flight>> response = _fileService.LoadFlights();
			Assert.Multiple(() =>
			{
				Assert.That(response.Success, Is.False);
				Assert.That(response.Data, Is.Null);
			});
		}

		[Test]
		public void LoadHotels_ValidFile_Success()
		{
			_configurationServiceMock.SetupGetFilePath(FileType.Hotels, Path);
			_hotelRepositoryMock.SetupLoadHotels(Path, HotelFactory.ValidDataResponse);

			DataResponse<List<Hotel>> response = _fileService.LoadHotels();
			Assert.Multiple(() =>
			{
				Assert.That(response.Success, Is.True);
				Assert.That(response.Data, Is.Not.Null);
			});
			Assert.That(response.Data, Has.Count.EqualTo(HotelFactory.ValidDataResponse.Data.Count));
		}

		[Test]
		public void LoadHotels_EmptyFile_Failure()
		{
			_configurationServiceMock.SetupGetFilePath(FileType.Hotels, null);

			DataResponse<List<Hotel>> response = _fileService.LoadHotels();
			Assert.Multiple(() =>
			{
				Assert.That(response.Success, Is.False);
				Assert.That(response.Data, Is.Null);
			});
		}

		[Test]
		public void LoadHotels_LoadingError_Failure()
		{
			_configurationServiceMock.SetupGetFilePath(FileType.Hotels, Path);
			_hotelRepositoryMock.SetupLoadHotels(Path, HotelFactory.InValidDataResponse);

			DataResponse<List<Hotel>> response = _fileService.LoadHotels();
			Assert.Multiple(() =>
			{
				Assert.That(response.Success, Is.False);
				Assert.That(response.Data, Is.Null);
			});
		}
	}
}
