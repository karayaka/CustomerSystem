using System;
using System.Text.Json;
using CustomerSystem.Application.Services;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace CustomerSystem.Infrastructure.Services
{
	public class CachingService: ICachingService
    {
        private IDatabase _cacheDb;

        public CachingService(IConfiguration _config)
		{
            var redis = ConnectionMultiplexer.Connect(_config["RedisSetting:ConnectionStrings"]);
            _cacheDb = redis.GetDatabase();

		}

        public T GetData<T>(string key)
        {
            try
            {
                var value = _cacheDb.StringGet(key);
                if (!string.IsNullOrEmpty(value))
                    return JsonSerializer.Deserialize<T>(value);
                return default;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public bool RemoveData(string key)
        {
            try
            {
                var exsist = _cacheDb.KeyExists(key);
                if (exsist)
                    return _cacheDb.KeyDelete(key);
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SetDate<T>(string key, T value, DateTimeOffset exDate)
        {
            try
            {
                var exTime = exDate.DateTime.Subtract(DateTime.Now);
                return _cacheDb.StringSet(key, JsonSerializer.Serialize(value), exTime);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

