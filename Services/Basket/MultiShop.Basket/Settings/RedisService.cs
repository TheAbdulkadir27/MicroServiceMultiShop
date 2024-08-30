using StackExchange.Redis;

namespace MultiShop.Basket.Settings
{
    public class RedisService
    {
        private string _host { get; set; }
        private int _port { get; set; }

        private ConnectionMultiplexer _connectionMultiplexer;
        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
        }
        public async void Connect()
        {
            var options = new ConfigurationOptions
            {
                AbortOnConnectFail = false,
                EndPoints = { $"{_host}:{_port}" },
                ConnectTimeout = 10000, // 10 saniye zaman aşımı
                SyncTimeout = 10000    // Senkronizasyon zaman aşımı
            };
            _connectionMultiplexer = await ConnectionMultiplexer.ConnectAsync(options);
        }
        public IDatabase GetDb(int db = 1) => _connectionMultiplexer.GetDatabase(0);
    }
}
