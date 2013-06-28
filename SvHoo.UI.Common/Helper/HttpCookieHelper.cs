using System;
using System.Web;
using SvHoo.Framework.Web.Utils;
using SvHoo.Domain.Cookie;
using SvHoo.Framework.Security;

namespace SvHoo.UI.Common.Helper
{
    public class HttpCookieHelper
    {
        public static HttpCookie GetCookie(string cookieName)
        {
            return CookieUtils.GetRequestCookie(cookieName);
        }

        public static void SetCookie(string cookieName, string value)
        {
            CookieUtils.SetCookieByName(cookieName, value);
        }

        public static void SetCookie(string cookieName, string key, string value)
        {
            CookieUtils.SetCookieByName(cookieName, key, value);
        }

        public static string GetValue(string cookieName)
        {
            return CookieUtils.GetCookieValue(cookieName);
        }

        public static void SetTokenCookie(string cookieName, int sysNo = 0)
        {
            if (sysNo > 0)
            {
                DateTime time = DateTime.Now;
                SetCookie(cookieName, "u", (sysNo * 13).ToString());
                SetCookie(cookieName, "t", Cryptography.MD5Encrypt(sysNo + time.ToString("yyyy-mm-dd-hh")).Substring(8, 10));
                SetCookie(cookieName, "d", time.ToString());
            }
            else
            {
                SetCookie(cookieName, "u", "");
                SetCookie(cookieName, "t", "");
                SetCookie(cookieName, "d", "");
            }
        }

        public static CookieTokenEntity GetTokenCookie(string cookieName, bool valiTime = false)
        {
            CookieTokenEntity cte = new CookieTokenEntity();

            HttpCookie cookie = GetCookie(cookieName);
            if (!string.IsNullOrEmpty(cookie.Value))
            {
                int sysno;
                DateTime date;
                cte.Token = cookie["t"];
                if (DateTime.TryParse(cookie["d"], out date))
                {
                    cte.LoginTime = date;
                }
                if (int.TryParse(cookie["u"], out sysno))
                {
                    cte.SysNo = sysno / 13;
                }
                if (valiTime
                    && cte.LoginTime.AddHours(5) < DateTime.Now)
                {
                    cte.IsValid = false;
                }
                else
                {
                    cte.IsValid = cte.Token.CompareTo(Cryptography.MD5Encrypt(cte.SysNo + cte.LoginTime.ToString("yyyy-mm-dd-hh")).Substring(8, 10)) == 0;
                }
            }
            return cte;
        }
    }
}
