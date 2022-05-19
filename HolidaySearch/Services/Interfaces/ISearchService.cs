using HolidaySearch.Models.Request;
using HolidaySearch.Models.Response;

namespace HolidaySearch.Services.Interfaces
{
	public interface ISearchService
	{
		DataResponse<HolidaySearchResponse> SearchHolidays(HolidaySearchRequest searchRequest);
	}
}
