using System;
using SvHoo.Domain;
using SvHoo.UI.Common.Views;

namespace SvHoo.UI.Common.Controllers
{
    public abstract class ControllerBase<Q, V>
        where Q : QueryEntityBase
        where V : ViewBase
    {

    }
}
