using HolidaySearch.Models;
using HolidaySearch.Models.Response;
using System;
using System.Collections.Generic;

namespace HolidaySearch.Tests.DataFactories
{
	public class HotelFactory
	{
		public static List<Hotel> Hotels => new()
		{
              new Hotel
              {
                  Id = 1,
                  Name = "Iberostar Grand Portals Nous",
                  ArrivalDate = DateTime.Parse("2022-11-05"),
                  PricePerNight = 100,
                  LocalAirports = new string[] { "TFS" },
                  Nights = 7
              },
              new Hotel
              {
                  Id = 2,
                  Name = "Laguna Park 2",
                  ArrivalDate = DateTime.Parse("2022-11-05"),
                  PricePerNight = 50,
                  LocalAirports = new string[] { "TFS" },
                  Nights = 7
              },
              new Hotel
              {
                  Id = 3,
                  Name = "Sol Katmandu Park & Resort",
                  ArrivalDate = DateTime.Parse("2023-06-15"),
                  PricePerNight = 59,
                  LocalAirports = new string[] { "PMI" },
                  Nights = 14
              },
              new Hotel
              {
                  Id = 4,
                  Name = "Sol Katmandu Park & Resort",
                  ArrivalDate = DateTime.Parse("2023-06-15"),
                  PricePerNight = 59,
                  LocalAirports = new string[] { "PMI" },
                  Nights = 14
              },
              new Hotel
              {
                  Id = 5,
                  Name = "Sol Katmandu Park & Resort",
                  ArrivalDate = DateTime.Parse("2023-06-15"),
                  PricePerNight = 60,
                  LocalAirports = new string[] { "PMI" },
                  Nights = 10
              },
              new Hotel
              {
                  Id = 6,
                  Name = "Club Maspalomas Suites and Spa",
                  ArrivalDate = DateTime.Parse("2022-11-10"),
                  PricePerNight = 75,
                  LocalAirports = new string[] { "LPA" },
                  Nights = 14
              },
              new Hotel
              {
                  Id = 7,
                  Name = "Club Maspalomas Suites and Spa",
                  ArrivalDate = DateTime.Parse("2022-09-10"),
                  PricePerNight = 76,
                  LocalAirports = new string[] { "LPA" },
                  Nights = 14
              },
              new Hotel
              {
                  Id = 8,
                  Name = "Boutique Hotel Cordial La Peregrina",
                  ArrivalDate = DateTime.Parse("2022-10-10"),
                  PricePerNight = 45,
                  LocalAirports = new string[] { "LPA" },
                  Nights = 7
              },
              new Hotel
              {
                  Id = 9,
                  Name = "Nh Malaga",
                  ArrivalDate = DateTime.Parse("2023-07-01"),
                  PricePerNight = 83,
                  LocalAirports = new string[] { "AGP" },
                  Nights = 7
              },
              new Hotel
              {
                  Id = 10,
                  Name = "Barcelo Malaga",
                  ArrivalDate = DateTime.Parse("2023-07-05"),
                  PricePerNight = 45,
                  LocalAirports = new string[] { "AGP" },
                  Nights = 10
              },
              new Hotel
              {
                  Id = 11,
                  Name = "Parador De Malaga Gibralfaro",
                  ArrivalDate = DateTime.Parse("2023-10-16"),
                  PricePerNight = 100,
                  LocalAirports = new string[] { "AGP" },
                  Nights = 7
              },
              new Hotel
              {
                  Id = 12,
                  Name = "MS Maestranza Hotel",
                  ArrivalDate = DateTime.Parse("2023-07-01"),
                  PricePerNight = 45,
                  LocalAirports = new string[] { "AGP" },
                  Nights = 14
              },
              new Hotel
              {
                  Id = 13,
                  Name = "Jumeirah Port Soller",
                  ArrivalDate = DateTime.Parse("2023-06-15"),
                  PricePerNight = 295,
                  LocalAirports = new string[] { "PMI" },
                  Nights = 10
              }
        };

		public static DataResponse<List<Hotel>> ValidDataResponse => new DataResponse<List<Hotel>>() { Data = Hotels, Success = true };
		public static DataResponse<List<Hotel>> InValidDataResponse => new DataResponse<List<Hotel>>() { Data = null, Success = false, Error = "Error" };
	}
}
