using System;
using System.Web;
using System.Web.SessionState;

namespace SvHoo.UI.Common.Helper
{
    public class HttpContextHelper
    {
        public static HttpRequest Request
        {
            get { return HttpContext.Current.Request; }
        }

        public static HttpResponse Response
        {
            get { return HttpContext.Current.Response; }
        }

        public static HttpSessionState Session
        {
            get { return HttpContext.Current.Session; }
        }

        public static HttpServerUtility Server
        {
            get { return HttpContext.Current.Server; }
        }
    }
}
