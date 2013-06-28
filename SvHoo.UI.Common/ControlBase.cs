using System;
using System.Web.UI;

namespace SvHoo.UI.Common
{
    public abstract class ControlBase : UserControl
    {
        protected override void OnLoad(EventArgs e)
        {
            this.BindDataSource();
            base.OnLoad(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            this.WriteData();
            base.OnPreRender(e);
        }

        protected virtual void BindDataSource()
        {

        }

        protected virtual void WriteData()
        { 
            
        }
    }
}
