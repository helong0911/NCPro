using System;
using SvHoo.UI.Common.Helper;

namespace SvHoo.Web.UI.Resource
{
    public class QueryValues
    {
        const string __ID = "id";
        public static string ID
        {
            get { return HttpContextHelper.Request.QueryString[__ID]; }
        }
    }
}
