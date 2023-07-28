using StackExchange.Redis;

namespace FreeCourse.services.basket.Services
{
    public class RedisService
    {
        private readonly string _host;
        private readonly int _port;
        private ConnectionMultiplexer _redisConnection;
        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;            
        }

        public IDatabase GetDb(int db = 1)
        {
            return _redisConnection.GetDatabase(db);
        }

        public void Connect()
        {
            var configString = $"{_host}:{_port}";
            _redisConnection = ConnectionMultiplexer.Connect(configString);
        }
    }
}
