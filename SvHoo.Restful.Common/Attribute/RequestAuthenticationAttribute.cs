using System;
using System.Web.Mvc;

namespace SvHoo.Restful.Common.Attribute
{
    public class RequestAuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string sign = filterContext.HttpContext.Request.Headers["x-svhoo-access"];
            if (!string.IsNullOrEmpty(sign))
            {
                if (sign != "10101100897")
                {
                    ViewResult view = new ViewResult();
                    view.ViewData = new ViewDataDictionary();
                    view.ViewData.Model = new Message() { Data = "Not Auto", Type = MessageType.Error };
                    filterContext.Result = view;
                    return;
                }
            }
            else
            {
                ViewResult view = new ViewResult();
                view.ViewData = new ViewDataDictionary();
                view.ViewData.Model = new Message() { Data = "Access Sign Error", Type = MessageType.Error };
                filterContext.Result = view;
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
