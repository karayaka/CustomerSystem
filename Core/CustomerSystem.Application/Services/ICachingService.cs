using System;
namespace CustomerSystem.Application.Services
{
	public interface ICachingService
	{
		T GetData<T>(string key);

		bool SetDate<T>(string key, T value, DateTimeOffset exDate);

		bool RemoveData(string key);
	}
}

