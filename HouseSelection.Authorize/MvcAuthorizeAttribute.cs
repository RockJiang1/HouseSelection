using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace HouseSelection.Authorize
{
    public class MvcAuthorizeAttribute : AuthorizeAttribute
    {
        private AuthorizeMethodEnum method;

        public MvcAuthorizeAttribute() : this(AuthorizeMethodEnum.Post) { }

        public MvcAuthorizeAttribute(AuthorizeMethodEnum method)
        {
            this.method = method;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Request.HttpMethod == HttpMethod.Options.Method)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.Accepted;
                return true;
            }

            var result = false;
            var accessToken = string.Empty;

            // Header中传递Token
            accessToken = httpContext.Request.Headers[AuthorizeHelper.TOKEN_KEY];
            if (!string.IsNullOrWhiteSpace(accessToken) && AuthorizeHelper.IsExistToken(accessToken))
            {
                result = true;
            }

            if (!result && (httpContext.Request.HttpMethod == HttpMethod.Get.Method || method == AuthorizeMethodEnum.Get))
            {
                // 通过地址栏传递
                accessToken = httpContext.Request.QueryString[AuthorizeHelper.TOKEN_KEY];
                if (string.IsNullOrWhiteSpace(accessToken))
                    accessToken = httpContext.Request.Form[AuthorizeHelper.TOKEN_KEY];
                if (!string.IsNullOrWhiteSpace(accessToken) && AuthorizeHelper.IsExistToken(accessToken))
                {
                    result = true;
                }
            }

            if (result)
            {
                result = AuthorizeExtension.Execute(AuthorizeTypeEnum.MVC, AuthorizeHelper.GetToken(accessToken));
            }

            if (!result)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            return result;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
            //base.HandleUnauthorizedRequest(filterContext);
            if (filterContext.HttpContext.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
            {
                filterContext.HttpContext.Response.ContentType = "application/json";
                filterContext.Result = new JsonResult
                {
                    Data = new { Code = 999, ErrMsg = "Authorization has been denied for this request." }, //请求要求身份验证，验证未通过 Unauthorized
                    ContentType = "application/json",
                    ContentEncoding = null,
                    JsonRequestBehavior = JsonRequestBehavior.DenyGet
                };
            }
        }

    }
}
