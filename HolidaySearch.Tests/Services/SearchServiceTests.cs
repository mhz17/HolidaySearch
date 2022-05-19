using HolidaySearch.Models.Request;
using HolidaySearch.Models.Response;
using HolidaySearch.Services;
using HolidaySearch.Services.Interfaces;
using HolidaySearch.Tests.DataFactories;
using HolidaySearch.Tests.MocksSetup.Repositories;
using NUnit.Framework;
using System.Collections.Generic;

namespace HolidaySearch.Tests.Services
{
	public class SearchServiceTests
	{

		private ISearchService _searchService;
		private FileServiceMock _fileServiceMock;

		[SetUp]
		public void Setup()
		{
			_fileServiceMock = new FileServiceMock();
			_searchService = new SearchService(_fileServiceMock._fileServiceMock.Object);
		}

		[Test]
		public void Search_InValidRequest_Failure()
		{
			DataResponse<HolidaySearchResponse> response = _searchService.SearchHolidays(HolidaySearchRequestFactory.InvalidRequest);
			Assert.Multiple(() =>
			{
				Assert.That(response.Success, Is.False);
				Assert.That(response.Data, Is.Null);
				Assert.That(response.Error, Is.EqualTo("Invalid request"));
			});
		}

		[Test, TestCaseSource(nameof(HolidayRequest))]
		public void Search_ValidRequest_Success(HolidaySearchRequest request, int flightId, int holidayId)
		{
			_fileServiceMock.SetupLoadHotels(HotelFactory.ValidDataResponse);
			_fileServiceMock.SetupLoadFlights(FlightFactory.ValidDataResponse);

			DataResponse<HolidaySearchResponse> response = _searchService.SearchHolidays(request);
			Assert.Multiple(() =>
			{
				Assert.That(response.Success, Is.True);
				Assert.That(response.Data, Is.Not.Null);
				Assert.That(response.Data.Flight.Id, Is.EqualTo(flightId));
				Assert.That(response.Data.Hotel.Id, Is.EqualTo(holidayId));
			});
		}

		private static IEnumerable<TestCaseData> HolidayRequest
		{
			get
			{
				yield return new TestCaseData(HolidaySearchRequestFactory.ValidRequest1, 2, 9);
				yield return new TestCaseData(HolidaySearchRequestFactory.ValidRequest2, 6, 5);
				yield return new TestCaseData(HolidaySearchRequestFactory.ValidRequest3, 7, 6);
			}
		}

	}
}
