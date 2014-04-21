using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Core
{
    public class ViewModelBase
    {
        //Return a Jquery Friendly Name to be used as an id.
        public string Id {
            get { return this.ToString().Substring(this.ToString().LastIndexOf('.')+1); }
        }

        public string ControllerName { get; set; }

        public RequestedAction RequestedAction { get; set; }

        public bool IsAjax { get; set; }

    }
}