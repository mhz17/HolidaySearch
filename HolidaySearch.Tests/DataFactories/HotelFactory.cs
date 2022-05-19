using HolidaySearch.Models;
using System;
using System.Collections.Generic;

namespace HolidaySearch.Tests.DataFactories
{
	public class HotelFactory
	{
		public static Hotel Hotel => new()
		{
			Id = 1,
			Name = "Test Hotel",
			ArrivalDate = DateTime.Now,
			PricePerNight = 150,
			LocalAirports = new string[] { "AMD" },
			Nights = 7
		};

		public static List<Hotel> Hotels => new List<Hotel>()
		{
			new Hotel {
				Id = 1,
				Name = "Iberostar Grand Portals Nous",
				ArrivalDate = DateTime.Now.AddDays(10),
				PricePerNight = 150,
				LocalAirports = new string[] { "TFS" },
				Nights = 7
			},
			new Hotel {
				Id = 2,
				Name = "Laguna Park 2",
				ArrivalDate = DateTime.Now.AddDays(50),
				PricePerNight = 250,
				LocalAirports = new string[] { "PMI" },
				Nights = 7
			}
		};

	}
}
