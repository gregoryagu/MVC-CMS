using System;

namespace TheCommLine.Helpers
{
    using System.IO;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Microsoft.Ajax.Utilities;

    public static class WrapHelper
    {

        public static IDisposable BeginColumn(this HtmlHelper html, int columnSpan, string id = "", string htmlClass = "")
        {
            TextWriter writer = html.ViewContext.Writer;
            var tagBuilder = new TagBuilder("div");

            var classString = String.Format("col-md-{0}", columnSpan);

            if (!String.IsNullOrWhiteSpace(htmlClass))
            {
                classString += " " + htmlClass;
            }
            tagBuilder.MergeAttribute("class", classString);

            if (!String.IsNullOrWhiteSpace(id))
            {
                tagBuilder.MergeAttribute("id", id);
            }

            writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));

            return new TagWrapper(html, tagBuilder);
        }

        //The main thing this does is add a class of editable-row which sets the position as relative so the Save Button ends up in the top right.
        public static IDisposable BeginEditableRow(this HtmlHelper html, string id = "", string htmlClass = "")
        {
            TextWriter writer = html.ViewContext.Writer;
            var tagBuilder = new TagBuilder("div");


            var classString = "editable-row";

            if (!String.IsNullOrWhiteSpace(htmlClass))
            {
                classString += " " + htmlClass;
            }
            tagBuilder.MergeAttribute("class", classString);

            if (!String.IsNullOrWhiteSpace(id))
            {
                tagBuilder.MergeAttribute("id", id);
            }

            writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));

            return new TagWrapper(html, tagBuilder);
        }

        public static IDisposable BeginEditWell(this HtmlHelper html, string id = "", string htmlClass = "")
        {
            TextWriter writer = html.ViewContext.Writer;
            var tagBuilder = new TagBuilder("div");


            var classNames = "";
            if (htmlClass != null)
            {
                classNames = htmlClass;
            }
            
            classNames += " edit-well";
            
            tagBuilder.MergeAttribute("class", classNames);

            if (!String.IsNullOrWhiteSpace(id))
            {
                tagBuilder.MergeAttribute("id", id);
            }

            writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));

            return new TagWrapper(html, tagBuilder);
        }

        public static IDisposable BeginEditableSection(this HtmlHelper html, string id = "", string htmlClass = "")
        {
            TextWriter writer = html.ViewContext.Writer;
            var tagBuilder = new TagBuilder("div");


            var classNames = "";
            if (htmlClass != null) {
                classNames = htmlClass;
            }

            classNames += " marker-edit-well";
            
            tagBuilder.MergeAttribute("class", classNames);

            if (!String.IsNullOrWhiteSpace(id))
            {
                tagBuilder.MergeAttribute("id", id);
            }

            writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));

            return new TagWrapper(html, tagBuilder);
        }

        public static IDisposable BeginRow(this HtmlHelper html, string id = "", string htmlClass = "", object htmlAttributes = null)
        {
            TextWriter writer = html.ViewContext.Writer;
            var tagBuilder = new TagBuilder("div");

            var classNames = "";
            if (htmlClass != null)
            {
                classNames = htmlClass;
            }

            classNames += " row";

            tagBuilder.MergeAttribute("class", classNames);

            if (!String.IsNullOrWhiteSpace(id))
            {
                tagBuilder.MergeAttribute("id", id);
            }

            if (htmlAttributes != null) {
                tagBuilder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            }

            writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));

            return new TagWrapper(html, tagBuilder);
        }


        private class TagWrapper : IDisposable
        {
            private bool disposed;
            private readonly TextWriter writer;

            private readonly TagBuilder tagBuilder;
            public TagWrapper(HtmlHelper html, TagBuilder tagBuilder)
            {
                this.writer = html.ViewContext.Writer;
                this.tagBuilder = tagBuilder;
            }

            public void Dispose()
            {
                if (disposed) return;

                disposed = true;
                writer.WriteLine(tagBuilder.ToString(TagRenderMode.EndTag));
            }
        }

        public static IDisposable BeginTag(this HtmlHelper html, string tag, string id = "", string htmlClass = "")
        {
            TextWriter writer = html.ViewContext.Writer;
            var tagBuilder = new TagBuilder(tag);
            if (!String.IsNullOrWhiteSpace(htmlClass))
            {
                tagBuilder.MergeAttribute("class", htmlClass);
            }

            if (!String.IsNullOrWhiteSpace(id))
            {
                tagBuilder.MergeAttribute("id", id);
            }

            writer.Write(tagBuilder.ToString(TagRenderMode.StartTag ));

            return new TagWrapper(html, tagBuilder);
        }

        public static IDisposable BeginUpdateable(this HtmlHelper html, string id, bool isAjax, string htmlClass = "")
        {
            if (isAjax)
            {
                return null;
            }

            TextWriter writer = html.ViewContext.Writer;
            var tagBuilder = new TagBuilder("div");


            if (!htmlClass.IsNullOrWhiteSpace()) {
                tagBuilder.MergeAttribute("class", htmlClass);
            }
            if (!String.IsNullOrWhiteSpace(id))
            {
                tagBuilder.MergeAttribute("id", id);
            }

            writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));

            return new TagWrapper(html, tagBuilder);
        }



        public static IDisposable BeginRegion(this HtmlHelper html,  string id = null, bool isAjax = false,  string htmlClass = "")
        {
            if (isAjax) {
                return null;
            }

            TextWriter writer = html.ViewContext.Writer;
            var tagBuilder = new TagBuilder("div");

            var classString = "page-region";

            if (!String.IsNullOrWhiteSpace(htmlClass)) {
                classString += " " + htmlClass;
            }
            tagBuilder.MergeAttribute("class", classString);
            
            if (!String.IsNullOrWhiteSpace(id))
            {
                tagBuilder.MergeAttribute("id", id);
            }

            writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));

            return new TagWrapper(html, tagBuilder);
        }

        public static IDisposable BeginContainer(this HtmlHelper html, string id = "", string htmlClass = "")
        {
            TextWriter writer = html.ViewContext.Writer;
            var tagBuilder = new TagBuilder("div");

            var classString = "container";

            if (!String.IsNullOrWhiteSpace(htmlClass))
            {
                classString += " " + htmlClass;
            }
            tagBuilder.MergeAttribute("class", classString);


            if (!String.IsNullOrWhiteSpace(id))
            {
                tagBuilder.MergeAttribute("id", id);
            }

            writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));

            return new TagWrapper(html, tagBuilder);
        }

        public static IDisposable BeginFormGroup(this HtmlHelper html)
        {
            TextWriter writer = html.ViewContext.Writer;
            var tagBuilder = new TagBuilder("div");

            tagBuilder.MergeAttribute("class", "form-group");
            
            writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));

            return new TagWrapper(html, tagBuilder);
        }

    }
}