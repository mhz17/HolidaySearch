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
	public class FlightRepository : IFlightRepository
	{

		private readonly ConfigurationService _configurationService;

		public FlightRepository(ConfigurationService configurationService)
		{
			_configurationService = configurationService;
		}

		public async Task<List<Flight>> LoadFlights()
		{
			string path = _configurationService.GetFilePath(FileType.Flights);
			List<Flight> flights = new();

			if (!string.IsNullOrEmpty(path))
			{
				using StreamReader r = new(path);
				string json = await r.ReadToEndAsync();
				flights = JsonConvert.DeserializeObject<List<Flight>>(json);
				return flights;
			}

			return flights;
		}
	}
}
