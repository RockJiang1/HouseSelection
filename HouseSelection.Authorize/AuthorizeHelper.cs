using System;
using System.Linq;
using System.Net.Http;
using HouseSelection.Redis;

namespace HouseSelection.Authorize
{
    public class AuthorizeHelper
    {
        private static RedisHelper redisHelper = new RedisHelper(PubConstant.DBIndex);
        private const string REDIS_KEY_TOKEN_ACCESSTOKEN = "Token:AccessToken";
        private const string REDIS_KEY_TOKEN_REFRESHTOKEN = "Token:RefreshToken";
        //private const string REDIS_KEY_TOKEN_USER = "Token:User";
        public const string TOKEN_KEY = "access_token";

        /// <summary>
        /// 新增令牌
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static TokenEntity AddToken(int requestUserId, string requestAccount, int expiry)
        {
            var token = new TokenEntity();

            token.AccessToken = GenerateTokenCode();
            token.RefreshToken = GenerateTokenCode();
            token.RequestAccount = requestAccount;
            token.RequestUserId = requestUserId;
            token.Expiry = expiry;
            token.CreateTime = DateTime.Now;
            token.ExpiryDate = DateTime.Now.AddSeconds(expiry);

            // 删除旧的Token
            //var currentToken = redisHelper.Get<TokenEntity>(string.Format("{0}:{1}", REDIS_KEY_TOKEN_USER, token.RequestUserId.ToString()));
            //if (currentToken != null)
            //{
            //    redisHelper.Remove(string.Format("{0}:{1}", REDIS_KEY_TOKEN_ACCESSTOKEN, currentToken.AccessToken));
            //}

            // 添加新的Token
            redisHelper.Set(string.Format("{0}:{1}", REDIS_KEY_TOKEN_ACCESSTOKEN, token.AccessToken), token, expiry);
            //redisHelper.Set(string.Format("{0}:{1}", REDIS_KEY_TOKEN_USER, token.RequestUserId.ToString()), token, expiry);
            redisHelper.Set(string.Format("{0}:{1}", REDIS_KEY_TOKEN_REFRESHTOKEN, token.RefreshToken), token.AccessToken, expiry * 12);
            return token;
        }

        /// <summary>
        /// 令牌是否存在
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool IsExistToken(string token)
        {
            return GetToken(token) != null;
        }

        /// <summary>
        /// 获取令牌
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static TokenEntity GetToken(string token)
        {
            return redisHelper.Get<TokenEntity>(string.Format("{0}:{1}", REDIS_KEY_TOKEN_ACCESSTOKEN, token));
        }

        public static TokenEntity GetTokenByRefreshToken(string token)
        {
            string currentToken = redisHelper.Get<string>(string.Format("{0}:{1}", REDIS_KEY_TOKEN_REFRESHTOKEN, token));
            return redisHelper.Get<TokenEntity>(string.Format("{0}:{1}", REDIS_KEY_TOKEN_ACCESSTOKEN, currentToken));
        }

        /// <summary>
        /// 移除令牌
        /// </summary>
        /// <param name="userId"></param>
        public static void RemoveToken(string RefreshToken)
        {
            string currentToken = redisHelper.Get<string>(string.Format("{0}:{1}", REDIS_KEY_TOKEN_REFRESHTOKEN, RefreshToken));
            if (currentToken != null)
            {
                redisHelper.Remove(string.Format("{0}:{1}", REDIS_KEY_TOKEN_ACCESSTOKEN, currentToken));
                redisHelper.Remove(string.Format("{0}:{1}", REDIS_KEY_TOKEN_REFRESHTOKEN, RefreshToken));
            }
        }

        /// <summary>
        /// 生成令牌
        /// </summary>
        /// <returns></returns>
        private static string GenerateTokenCode()
        {
            var str = string.Format("{0}{1}{2}", Guid.NewGuid().ToString("N"), DateTime.Now.Ticks, Guid.NewGuid().ToString("N"));
            return str;
        }


        private static string GetTokenByRequest(HttpRequestMessage request)
        {
            var token = request.GetQueryNameValuePairs().Where(x => x.Key == TOKEN_KEY).FirstOrDefault().Value;
            if (token == null)
                token = request.Headers.Where(c => c.Key.ToLower() == TOKEN_KEY).FirstOrDefault().Value.First<string>();

            return token;
        }

        public static string GetRequestAccount(HttpRequestMessage request)
        {
            var token = GetTokenByRequest(request);

            if (token == null)
                return string.Empty;

            var t = GetToken(token);
            if (t == null)
                return string.Empty;

            return t.RequestAccount;
        }


    }
}
