using System;
using SvHoo.Domain;
using SvHoo.UI.Common.Views;

namespace SvHoo.UI.Common.Controllers
{
    public abstract class WebControllerBase<Q, V> : ControllerBase<Q, V>
        where Q : QueryEntityBase
        where V : ViewBase
    {
        public V Start()
        {
            Q q = this.GetQueryEntity();
            q = InitEntity(q);
            return this.LoadData(q);
        }

        protected Q InitEntity(Q q)
        {
            return q;
        }

        protected abstract Q GetQueryEntity();
        protected abstract V LoadData(Q q);
    }
}
