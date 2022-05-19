using HolidaySearch.Models;
using HolidaySearch.Models.Response;
using System;
using System.Collections.Generic;

namespace HolidaySearch.Tests.DataFactories
{
	public class FlightFactory
	{
		public static List<Flight> Flights => new()
		{
          new Flight {
            Id = 1,
            Airline = "First Class Air",
            From = "MAN",
            To = "TFS",
            Price = 470,
            DepratureDate = DateTime.Parse("2023-07-01")
          },
          new Flight {
            Id = 2,
            Airline = "Oceanic Airlines",
            From = "MAN",
            To = "AGP",
            Price = 245,
            DepratureDate = DateTime.Parse("2023-07-01")
          },
          new Flight {
            Id = 3,
            Airline = "Trans American Airlines",
            From = "MAN",
            To = "PMI",
            Price = 170,
            DepratureDate = DateTime.Parse("2023-06-15")
          },
          new Flight {
            Id = 4,
            Airline = "Trans American Airlines",
            From = "LTN",
            To = "PMI",
            Price = 153,
            DepratureDate = DateTime.Parse("2023-06-15")

          },
          new Flight {
            Id = 5,
            Airline = "Fresh Airways",
            From = "MAN",
            To = "PMI",
            Price = 130,
            DepratureDate = DateTime.Parse("2023-06-15")
          },
          new Flight {
            Id = 6,
            Airline = "Fresh Airways",
            From = "LGW",
            To = "PMI",
            Price = 75,
            DepratureDate = DateTime.Parse("2023-06-15")
          },
          new Flight {
            Id = 7,
            Airline = "Trans American Airlines",
            From = "MAN",
            To = "LPA",
            Price = 125,
            DepratureDate = DateTime.Parse("2022-11-10")
          },
          new Flight {
            Id = 8,
            Airline = "Fresh Airways",
            From = "MAN",
            To = "LPA",
            Price = 175,
            DepratureDate = DateTime.Parse("2023-11-10")
          },
          new Flight {
            Id = 9,
            Airline = "Fresh Airways",
            From = "MAN",
            To = "AGP",
            Price = 140,
            DepratureDate = DateTime.Parse("2023-04-11")
          },
          new Flight {
            Id = 10,
            Airline = "First Class Air",
            From = "LGW",
            To = "AGP",
            Price = 225,
            DepratureDate = DateTime.Parse("2023-07-01")
          },
          new Flight {
            Id = 11,
            Airline = "First Class Air",
            From = "LGW",
            To = "AGP",
            Price = 155,
            DepratureDate = DateTime.Parse("2023-07-01")
          },
          new Flight {
            Id = 12,
            Airline = "Trans American Airlines",
            From = "MAN",
            To = "AGP",
            Price = 202,
            DepratureDate = DateTime.Parse("2023-10-25")
          }
        };

		public static DataResponse<List<Flight>> ValidDataResponse => new DataResponse<List<Flight>>() { Data = Flights, Success = true };
		public static DataResponse<List<Flight>> InValidDataResponse => new DataResponse<List<Flight>>() { Data = null, Success = false, Error = "Error" };
	}
}
