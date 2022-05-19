using HolidaySearch.Models.Request;

namespace HolidaySearch.Tests.DataFactories
{
	public class HolidaySearchRequestFactory
    {
		public static HolidaySearchRequest ValidRequest1 => 
          new() {
            DepartingFrom = "MAN",
            TravelingTo = "AGP",
            DepartureDate = "2023-07-01",
            Duration = "7",
          };

        public static HolidaySearchRequest ValidRequest2 =>
          new()
          {
              DepartingFrom = "Any London Airport",
              TravelingTo = "PMI",
              DepartureDate = "2023/06/15",
              Duration = "10",
          };

        public static HolidaySearchRequest ValidRequest3 =>
          new()
          {
              DepartingFrom = "Any Airport",
              TravelingTo = "LPA",
              DepartureDate = "2022/11/10",
              Duration = "14",
          };

        public static HolidaySearchRequest InvalidRequest =>
          new()
          {
              DepartingFrom = "Any Airport",
              TravelingTo = "LPA",
              DepartureDate = "testing",
              Duration = "abc",
          };
    }
}
