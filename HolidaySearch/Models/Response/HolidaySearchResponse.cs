namespace HolidaySearch.Models.Response
{
	public class HolidaySearchResponse
	{
		public Hotel Hotel { get; set; }
		public Flight Flight { get; set; }
		public decimal TotalPrice { get; set; }
	}
}
