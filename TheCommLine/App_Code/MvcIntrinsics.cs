namespace TheCommLine.App_Code {
    using System.Web.WebPages;

    public static class MvcIntrinsics {
        public static System.Web.Mvc.HtmlHelper Html {
            get { return ((System.Web.Mvc.WebViewPage)WebPageContext.Current.Page).Html; }
        }

        public static System.Web.Mvc.AjaxHelper Ajax {
            get { return ((System.Web.Mvc.WebViewPage)WebPageContext.Current.Page).Ajax; }
        }

        public static System.Web.Mvc.UrlHelper Url {
            get { return ((System.Web.Mvc.WebViewPage)WebPageContext.Current.Page).Url; }
        }

    }
}