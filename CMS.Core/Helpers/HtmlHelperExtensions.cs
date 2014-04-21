﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Helpers
{
    using System.Web.Mvc;

    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Button(this HtmlHelper helper,
                                     string innerHtml,
                                     object htmlAttributes)
        {
            return Button(helper, innerHtml,
                          HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)
            );
        }

        public static MvcHtmlString Button(this HtmlHelper helper,
                                           string innerHtml,
                                           IDictionary<string, object> htmlAttributes)
        {
            var builder = new TagBuilder("button");
            builder.InnerHtml = innerHtml;
            builder.MergeAttributes(htmlAttributes);
            return MvcHtmlString.Create(builder.ToString());
        }

    }
}
