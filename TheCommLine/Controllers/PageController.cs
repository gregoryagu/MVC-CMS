using System.Web.Mvc;

namespace TheCommLine.Controllers
{
    using TheCommLine.ViewModels;

    public class PageController : ControllerBase<AppViewModel> {

        
        
        //public ActionResult Contact()
        //{
            
        //    var page = _pageRepostory.GetOrCreatePageByKey("Contact");
            
        //    return View("GenericPage", page);
        //}

        //[ValidateInput(false)]
        //public ActionResult ProcessPageEdit(AppViewModel appViewModel)
        //{
        //    if (appViewModel.CurrentPage.Action == "save")
        //    {
        //        AppViewModel.CurrentPage = appViewModel.CurrentPage;
        //        _pageRepostory.SavePage(AppViewModel.CurrentPage);
                
        //    }

        //    AppViewModel.CurrentPage.ViewMode = EditMode.ReadOnly;

        //    return PartialView("ReadOnlyView");

        //}

        //public ActionResult ShowEditPage()
        //{
        //    return PartialView("EditView");
        //}

       
    }
}