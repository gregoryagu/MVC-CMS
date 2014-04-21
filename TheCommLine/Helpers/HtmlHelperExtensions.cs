namespace TheCommLine.Helpers
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    public static class HtmlHelperExtensions
    {

        

        public static MvcHtmlString FormTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> helper,
                                                                    Expression<Func<TModel, TValue>> expression)
        {
            return helper.TextBoxFor(expression, new { @class = "form-control" });
        }

        public static MvcHtmlString FormTextAreaFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, int numOfRows)
        {
            return helper.TextAreaFor(expression, new { @class = "form-control", rows=numOfRows });
        }


        public static FluentTagBuilder Tag(this HtmlHelper helper, string tag)
        {
            return new FluentTagBuilder(tag);
        }

        public static MvcHtmlString WrapInEditRegion(this HtmlHelper helper, string content) {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.MergeAttribute("class", "row marker-edit-well");
            tagBuilder.InnerHtml = content;
            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));
        }

        //@Html.Tag("button").Type("submit").Class("btn btn-default btn-success").Content(Model.EditThisPageText).HtmlAttributes(new { value = "Edit", Name = "RequestedAction", OnClick = "showEditMode()" })
    
        public static FluentTagBuilder EditButton(this HtmlHelper helper, string requestedAction = null) {
            var builder = new FluentTagBuilder("button");
            builder.Type("submit");
            builder.Class("btn btn-default");
            if (String.IsNullOrWhiteSpace(requestedAction)) {
                builder.HtmlAttributes(new { Name = "RequestedAction", Value = "Edit" });
            }
            else {
                builder.HtmlAttributes(new { Name = "RequestedAction", Value = requestedAction });
            }
            return builder;
        }

        public static FluentTagBuilder CancelButton(this HtmlHelper helper)
        {
            var builder = new FluentTagBuilder("button");
            builder.Type("submit");
            builder.Class("btn btn-default");
            builder.HtmlAttributes(new { Name = "RequestedAction", Value = "Cancel" });
            return builder;
        }
    }
}