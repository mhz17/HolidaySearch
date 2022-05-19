using HolidaySearch.Constants;
using HolidaySearch.Models;
using HolidaySearch.Repositories.Interfaces;
using HolidaySearch.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace HolidaySearch.Repositories
{
	public class HotelRepository : IHotelRepository
	{
		private readonly ConfigurationService _configurationService;

		public HotelRepository(ConfigurationService configurationService)
		{
			_configurationService = configurationService;
		}

		public async Task<List<Hotel>> LoadHotels()
		{
			string path = _configurationService.GetFilePath(FileType.Hotels);
			List<Hotel> hotels = new();

			if (!string.IsNullOrEmpty(path))
			{
				using StreamReader r = new(path);
				string json = await r.ReadToEndAsync();
				hotels = JsonConvert.DeserializeObject<List<Hotel>>(json);
				return hotels;
			}

			return hotels;
		}
	}
}
