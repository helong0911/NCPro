using System;
using System.Text;
using System.Web.Mvc;

namespace SvHoo.Restful.Common.Attribute
{
    public class RestfulEnabledAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            JsonResult json = new JsonResult();
            json.ContentEncoding = Encoding.UTF8;
            //json.ContentType = "text/json;charset=UTF-8";
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            ViewResult view = filterContext.Result as ViewResult;
            if (view != null)
            {
                json.Data = view.ViewData.Model;
            }
            else
            {
                json.Data = new Message() { Type = MessageType.Error, Data = "Output" };
            }
            filterContext.Result = json;
        }
    }
}
