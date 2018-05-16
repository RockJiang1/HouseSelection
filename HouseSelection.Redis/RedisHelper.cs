using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace HouseSelection.Redis
{
    public class RedisHelper
    {
        private static IDatabase cache;

        public RedisHelper(int? intRedisDB = null)
        {
            cache = RedisConn.GetInstance(intRedisDB).GetDatabase();
        }

        /// <summary>
        /// JSON FORMAT 和 Rest 里面的保持一致
        /// </summary>
        protected static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            DateFormatHandling = DateFormatHandling.IsoDateFormat,
            DateParseHandling = DateParseHandling.DateTime,
            DateTimeZoneHandling = DateTimeZoneHandling.Local
        };

        /// <summary>
        /// 添加string类型数据到redis
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public bool StringSet(string key, string value)
        {
            return cache.StringSet(key, value);
        }

        /// <summary>
        /// 添加string类型数据到redis
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="seconds">过期时间（秒）</param>
        /// <returns></returns>
        public bool StringSet(string key, string value, int seconds)
        {
            var result = cache.StringSet(key, value);
            if (result)
            {
                var timeSpan = new TimeSpan(0, 0, seconds);
                SetExpire(key, timeSpan);
            }
            return result;
        }

        /// <summary>
        /// 从redis中获取string类型数据
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public string StringGet(string key)
        {
            return cache.StringGet(key);
        }

        /// <summary>
        /// 从redis中获取Int类型数据
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public int IntGet(string key)
        {
            try
            {
                return Convert.ToInt32(StringGet(key));
            }
            catch (Exception)
            {
                return (-9999);
            }
        }

        /// <summary>
        /// 根据key获取指定类型数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            //return Deserialize<T>(cache.StringGet(key));
            var value = cache.StringGet(key);
            if (value.IsNull)
                return default(T);
            return JsonConvert.DeserializeObject<T>(value);
        }

        /// <summary>
        /// 根据key获取object类型数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Get(string key)
        {
            //return Deserialize<object>(cache.StringGet(key));
            var value = cache.StringGet(key);
            if (value.IsNull)
                return default(object);
            return JsonConvert.DeserializeObject<object>(cache.StringGet(key));
        }

        /// <summary>
        /// 存储对象转换成JSON存到redis
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public bool Set(string key, object value)
        {
            //cache.StringSet(key, Serialize(value));
            return cache.StringSet(key, JsonConvert.SerializeObject(value, JsonSerializerSettings));
        }

        /// <summary>
        /// 存储对象转换成JSON存到redis
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="min">过期时间（秒）</param>
        /// <returns></returns>
        public bool Set(string key, object value, int seconds)
        {
            //cache.StringSet(key, Serialize(value));
            var result = cache.StringSet(key, JsonConvert.SerializeObject(value, JsonSerializerSettings));
            if (result)
            {
                var timeSpan = new TimeSpan(0, 0, seconds);
                SetExpire(key, timeSpan);
            }
            return result;
        }

        /// <summary>
        /// 存储对象转换成JSON存到redis
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="t">值</param>
        /// <returns></returns>
        public bool Set<T>(string key, T t)
        {
            return cache.StringSet(key, JsonConvert.SerializeObject(t, JsonSerializerSettings));
        }

        /// <summary>
        /// 存储对象转换成JSON存到redis
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">键</param>
        /// <param name="t">值</param>
        /// <param name="min">过期时间（秒）</param>
        /// <returns></returns>
        public bool Set<T>(string key, T t, int seconds)
        {
            var result = cache.StringSet(key, JsonConvert.SerializeObject(t, JsonSerializerSettings));
            if (result)
            {
                var timeSpan = new TimeSpan(0, 0, seconds);
                SetExpire(key, timeSpan);
            }
            return result;
        }

        /// <summary>
        /// 存储对象转换成JSON存到redis
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="hashField">Hash键</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public bool Set(string key, string hashField, object value)
        {
            return cache.HashSet(key, hashField, JsonConvert.SerializeObject(value, JsonSerializerSettings));
        }

        /// <summary>
        /// 存储对象转换成JSON存到redis
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="hashField">Hash键</param>
        /// <param name="value">值</param>
        /// <param name="min">过期时间（秒）</param>
        /// <returns></returns>
        public bool Set(string key, string hashField, object value, int seconds)
        {
            var result = cache.HashSet(key, hashField, JsonConvert.SerializeObject(value, JsonSerializerSettings));
            if (result)
            {
                var timeSpan = new TimeSpan(0, 0, seconds);
                SetExpire(key, timeSpan);
            }
            return result;
        }

        /// <summary>
        /// 获取Hash中的某 Hash 值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="hashField"></param>
        /// <returns></returns>
        public T Get<T>(string key, string hashField)
        {
            var value = cache.HashGet(key, hashField);
            if (value.IsNull)
                return default(T);
            return JsonConvert.DeserializeObject<T>(value);
        }

        public bool Remove(string key)
        {
            if (cache.KeyExists(key))
            {
                return cache.KeyDelete(key);
            }
            return false;
        }

        /// <summary>
        /// 移除Hash中的某 Hash 值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashField"></param>
        /// <returns></returns>
        public bool Remove(string key, string hashField)
        {
            if (cache.HashExists(key, hashField))
            {
                return cache.HashDelete(key, hashField);
            }
            return false;
        }

        /// <summary>
        /// 设置缓存到期时间
        /// </summary>
        void SetExpire(string key, TimeSpan timeSpan)
        {
            cache.KeyExpire(key, timeSpan);
        }

        static byte[] Serialize(object o)
        {
            if (o == null)
            {
                return null;
            }

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, o);
                byte[] objectDataAsStream = memoryStream.ToArray();
                return objectDataAsStream;
            }
        }

        static T Deserialize<T>(byte[] stream)
        {
            if (stream == null)
            {
                return default(T);
            }

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream(stream))
            {
                T result = (T)binaryFormatter.Deserialize(memoryStream);
                return result;
            }
        }


        #region  当作消息代理中间件使用 一般使用更专业的消息队列来处理这种业务场景
        /// <summary>
        /// 当作消息代理中间件使用
        /// 消息组建中,重要的概念便是生产者,消费者,消息中间件。
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static long Publish(string channel, string message)
        {
            ISubscriber sub = RedisConn.GetInstance().GetSubscriber();
            return sub.Publish(channel, message);
        }

        /// <summary>
        /// 在消费者端得到该消息并输出
        /// </summary>
        /// <param name="channelFrom"></param>
        /// <returns></returns>
        public static void Subscribe(string channelFrom)
        {
            ISubscriber sub = RedisConn.GetInstance().GetSubscriber();
            sub.Subscribe(channelFrom, (channel, message) =>
            {
                Console.WriteLine((string)message);
            });
        }

        /// <summary>
        /// 取消订阅
        /// </summary>
        /// <param name="channelFrom"></param>
        /// <returns></returns>
        public static void Unsubscribe(string channelFrom)
        {
            ISubscriber sub = RedisConn.GetInstance().GetSubscriber();
            sub.Unsubscribe(channelFrom);
        }


        #endregion


    }
}
