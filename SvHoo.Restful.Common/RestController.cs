using System;
using System.Web.Mvc;
using SvHoo.Restful.Common.Attribute;

namespace SvHoo.Restful.Common
{
    [RestfulEnabled]
    //[RequestAuthentication] // 普通请求验证
    public class RestController : Controller
    {

    }
}
