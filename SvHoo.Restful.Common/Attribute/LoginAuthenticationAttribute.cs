using System;
using System.Web.Mvc;
using SvHoo.Framework.Security;

namespace SvHoo.Restful.Common.Attribute
{
    public class LoginAuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string sign = filterContext.HttpContext.Request.Headers["x-svhoo-login"];
            if (!string.IsNullOrEmpty(sign))
            {
                sign = Cryptography.Decrypt(sign, Cryptography.EncryptKey, Cryptography.EncryptIV, EncryptMode.DES);
                string[] list = sign.Split('\n');
                int sysNo = 0;
                DateTime loginTime = DateTime.Now;
                if (list.Length < 3
                    || int.TryParse(list[1], out sysNo) == false
                    || DateTime.TryParse(list[2], out loginTime) == false)
                {
                    ViewResult view = new ViewResult();
                    view.ViewData = new ViewDataDictionary();
                    view.ViewData.Model = new Message() { Data = "Not Login", Type = MessageType.Error };
                    filterContext.Result = view;
                    return;
                }
                ServiceContext.CustomerID = sysNo;
                ServiceContext.CustomerName = list[0];
                ServiceContext.CustomerLoginTime = loginTime;
            }
            else
            {
                ViewResult view = new ViewResult();
                view.ViewData = new ViewDataDictionary();
                view.ViewData.Model = new Message() { Data = "Login Sign Error", Type = MessageType.Error };
                filterContext.Result = view;
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
