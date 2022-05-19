using System;

namespace HolidaySearch.Models.Request
{
	public class HolidaySearchRequest
	{
		public string DepartingFrom { get; set; }
		public string TravelingTo { get; set; }
		public string DepartureDate { get; set; }
		public string Duration { get; set; }
	}
}
