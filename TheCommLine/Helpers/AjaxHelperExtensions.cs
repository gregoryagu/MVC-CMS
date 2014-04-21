using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheCommLine.Helpers
{
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;

    using Core;

    public static class AjaxHelperExtensions
    {
        //A wrapper which uses the standard values.
        public static MvcForm BeginForm(this AjaxHelper helper, ViewModelBase model) {
            return helper.BeginForm(
                model.ActionName,
                model.Controller,
                new AjaxOptions() { UpdateTargetId = model.HtmlId, InsertionMode = InsertionMode.Replace });
        }
        public static MvcForm BeginForm(this AjaxHelper helper, ViewModelBase model, object htmlAttributes)
        {
            return helper.BeginForm(
                model.ActionName,
                model.Controller,
                null,
                new AjaxOptions() { UpdateTargetId = model.HtmlId, InsertionMode = InsertionMode.Replace },
                htmlAttributes);
        }
    }
}