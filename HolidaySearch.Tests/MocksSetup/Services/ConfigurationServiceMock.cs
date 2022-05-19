using HolidaySearch.Services.Interfaces;
using Moq;

namespace HolidaySearch.Tests.MocksSetup.Repositories
{
	public class ConfigurationServiceMock
	{
		public readonly Mock<IConfigurationService> _configurationService;

		public ConfigurationServiceMock()
		{
			_configurationService = new Mock<IConfigurationService>();
		} 

		public void SetupGetFilePath(string fileType, string path)
		{
			_configurationService.Setup(a => a.GetFilePath(fileType)).Returns(path);
		}
	}
}
