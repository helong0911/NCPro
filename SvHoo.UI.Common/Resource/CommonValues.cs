using System;
using SvHoo.Framework.Web.Tools;
using SvHoo.UI.Common.Helper;

namespace SvHoo.UI.Common.Resource
{
    public class CommonValues
    {
        public static string GetSecurityCode(int size, int width, int height)
        {
            string str = string.Empty;
            byte[] map = SecurityCode.GetValiCode(size, width, height, out str);
            HttpContextHelper.Response.OutputStream.Write(map, 0, map.Length);
            HttpContextHelper.Response.Flush();
            return str;
        }
    }
}
