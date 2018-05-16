using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Authorize
{
    public class AuthorizeExtension
    {
        private static List<IAuthorizeProvider> _apiProviders = new List<IAuthorizeProvider>();
        private static List<IAuthorizeProvider> _mvcProviders = new List<IAuthorizeProvider>();
        private static object _apiLock = new object();
        private static object _mvcLock = new object();

        /// <summary>
        /// 附加扩展验证
        /// </summary>
        /// <param name="provider"></param>
        public static void AttachProvider(AuthorizeTypeEnum type, IAuthorizeProvider provider)
        {
            switch (type)
            {
                case AuthorizeTypeEnum.API:
                    lock (_apiLock)
                    {
                        _apiProviders.Add(provider);
                    }
                    break;
                case AuthorizeTypeEnum.MVC:
                    lock (_mvcLock)
                    {
                        _mvcProviders.Add(provider);
                    }
                    break;
            }
        }

        public static bool Execute(AuthorizeTypeEnum type, TokenEntity token)
        {
            List<IAuthorizeProvider> tempProviders = null;
            switch (type)
            {
                case AuthorizeTypeEnum.API:
                    lock (_apiLock)
                    {
                        tempProviders = _apiProviders;
                    }
                    break;
                case AuthorizeTypeEnum.MVC:
                    lock (_mvcLock)
                    {
                        tempProviders = _mvcProviders;
                    }
                    break;
            }

            if (tempProviders == null)
                return true;

            foreach (var p in tempProviders)
            {
                if (!p.Execute(token))
                    return false;
            }

            return true;
        }
    }
}
