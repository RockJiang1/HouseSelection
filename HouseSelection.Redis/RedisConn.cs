using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Redis
{
    public class RedisConn
    {
        private static Dictionary<int, ConnectionMultiplexer> _connections = new Dictionary<int, ConnectionMultiplexer>();
        private static readonly object _objLock = new object();

        public static ConnectionMultiplexer GetInstance(int? dbIndex = null)
        {
            var index = dbIndex ?? PubConstant.DBIndex.Value;

            ConnectionMultiplexer connection = null;
            lock (_objLock)
            {
                if (_connections.ContainsKey(index) && _connections[index].IsConnected)
                    return _connections[index];

                if (_connections.ContainsKey(index) && !_connections[index].IsConnected)
                    _connections[index].Dispose();

                var configurationOptions = new ConfigurationOptions()
                {
                    Password = PubConstant.RedisPassword,
                    EndPoints = { { PubConstant.RedisIP, Convert.ToInt32(PubConstant.RedisPort) } },
                    DefaultDatabase = index,
                    ConnectRetry = 3,
                    ConnectTimeout = 10000,
                    SyncTimeout = 10000
                };
                connection = ConnectionMultiplexer.Connect(configurationOptions);
                if (_connections.ContainsKey(index))
                    _connections[index] = connection;
                else
                    _connections.Add(index, connection);
                return connection;
            }

        }
    }
}
