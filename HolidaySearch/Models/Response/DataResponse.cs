namespace HolidaySearch.Models.Response
{
	public class DataResponse<T>
	{
		public bool Success { get; set; }
		public string Error { get; set; }
		public T Data { get; set; }
	}
}
