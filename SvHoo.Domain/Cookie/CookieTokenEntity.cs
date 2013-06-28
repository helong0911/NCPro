using System;

namespace SvHoo.Domain.Cookie
{
    public class CookieTokenEntity
    {
        public int SysNo { get; set; }

        public string Token { get; set; }

        public DateTime LoginTime { get; set; }

        public bool IsValid { get; set; }
    }
}
