using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core
{
    public enum EditMode
    {
        ReadOnly = 0,
        Edit = 1
    }

    public enum RequestedAction
    {
        None = 0,
        Edit = 1,
        Save = 2,
        Cancel = 3
    }
}
