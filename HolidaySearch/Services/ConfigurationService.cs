using HolidaySearch.Services.Interfaces;
using System;
using System.Configuration;
using System.IO;

namespace HolidaySearch.Services
{
	public class ConfigurationService : IConfigurationService
	{
		public string GetFilePath(string fileType)
		{
			if (!string.IsNullOrEmpty(fileType)) {
				var parentOfStartupPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"../../../"));
				return Path.Combine(parentOfStartupPath, ConfigurationManager.AppSettings[fileType]);
			}
			return null;
		}

	}
}
