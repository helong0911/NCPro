using System;

namespace SvHoo.Domain.Helper
{
    public class PageResult
    {
        public string RedirectUrl
        {
            get;
            set;
        }

        public string JsAlertMsg
        {
            get;
            set;
        }

        public string JsShowMsg
        {
            get;
            set;
        }

        public ResultType ResultType
        {
            get;
            set;
        }
    }
}
