using System;
using System.Web.UI;

using SvHoo.Framework.Web.Script;
using SvHoo.UI.Common.Views;
using SvHoo.UI.Common.Controllers;
using SvHoo.Domain.Helper;
using SvHoo.Domain.Common;

namespace SvHoo.UI.Common
{
    public abstract class PageBase : Page
    {
        private PageResult pageResult = new PageResult();
        protected PageResult PageResult
        {
            get { return this.pageResult; }
        }

        protected Message MsgResult
        {
            get;
            set;
        }

        protected override void OnLoad(EventArgs e)
        {
            this.BindDataSource();
            base.OnLoad(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            WriteResult();
            base.OnPreRender(e);
        }

        private void WriteResult()
        {
            if (this.pageResult.ResultType == ResultType.AlertRedi)
            {
                ScriptObject.JsAlert(this, this.pageResult.JsAlertMsg, this.pageResult.RedirectUrl);
                return;
            }
            if (!string.IsNullOrEmpty(this.pageResult.RedirectUrl))
            {
                Response.Redirect(this.pageResult.RedirectUrl);
                return;
            }
            if (!string.IsNullOrEmpty(this.pageResult.JsAlertMsg))
            {
                ScriptObject.JsAlert(this, this.pageResult.JsAlertMsg);
                return;
            }
            if (!string.IsNullOrEmpty(this.pageResult.JsShowMsg))
            {
                string msg = string.Format("<script type=\"text/javascript\">{0}jAlert('{1}', '系统消息');_initcontdown({2});{3}</script>", "$(document).ready(function() {", this.pageResult.JsShowMsg, 30, "});");
                ScriptObject.RegisterScript(this, msg);
                return;
            }
        }

        protected virtual void BindDataSource()
        {

        }
    }
}
