using System.Web;

namespace TheCommLine.Helpers
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class FluentTagBuilder : IHtmlString, IFluentInterface
    {
        private readonly TagBuilder _tagBuilder;

        public FluentTagBuilder HtmlAttributes(object htmlAttributes) {
            _tagBuilder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            return this;
        }



        public FluentTagBuilder(string tag)
        {
            _tagBuilder = new TagBuilder(tag);
        }

        public FluentTagBuilder Content(string content)
        {
            _tagBuilder.InnerHtml = content;
            return this;
        }

        public string ToHtmlString()
        {
            return _tagBuilder.ToString(TagRenderMode.Normal);
        }

        public FluentTagBuilder Class(string htmlClass)
        {
            _tagBuilder.AddCssClass(htmlClass);
            return this;
        }

        public FluentTagBuilder Style(string style)
        {
            _tagBuilder.MergeAttribute("style", style);
            return this;
        }

        public FluentTagBuilder Type(string type)
        {
            _tagBuilder.MergeAttribute("type", type);
            return this;
        }
    }
}