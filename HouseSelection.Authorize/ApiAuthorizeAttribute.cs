using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace HouseSelection.Authorize
{
    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        private AuthorizeMethodEnum method;

        public ApiAuthorizeAttribute() : this(AuthorizeMethodEnum.Post) { }

        public ApiAuthorizeAttribute(AuthorizeMethodEnum method)
        {
            this.method = method;
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (actionContext.Request.Method == HttpMethod.Options)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Accepted);
                return true;
            }

            var result = false;
            var accessToken = string.Empty;

            // Header中传递Token
            var ts = actionContext.Request.Headers.Where(c => c.Key.ToLower() == AuthorizeHelper.TOKEN_KEY).FirstOrDefault().Value;
            if (ts != null)
            {
                accessToken = ts.First<string>();
                result = AuthorizeHelper.IsExistToken(accessToken);
            }

            if (!result && (actionContext.Request.Method == HttpMethod.Get || method == AuthorizeMethodEnum.Get))
            {
                // 通过地址栏传递
                accessToken = actionContext.Request.GetQueryNameValuePairs().Where(x => x.Key == AuthorizeHelper.TOKEN_KEY).FirstOrDefault().Value;
                if (accessToken != null && AuthorizeHelper.IsExistToken(accessToken))
                {
                    result = true;
                }
            }

            if (result)
            {
                result = AuthorizeExtension.Execute(AuthorizeTypeEnum.API, AuthorizeHelper.GetToken(accessToken));
            }

            return result;
        }
    }
}
