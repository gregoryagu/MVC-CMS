using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheCommLine.ViewModels
{
    using Core;

    public class Content : ViewModelBase {

        [System.Web.Mvc.AllowHtml]
        
        //There can be only one MapToDb property.
        [MapToDb]
        public string Data { get; set; }
        public string DataDefault = "<span>Content goes here.</span>";

        

    }

   
}