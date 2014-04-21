using System;

namespace Core
{
    using System.Web.Mvc;

    public class ControllerBase<TAppViewModel> : Controller where TAppViewModel : class, new()  {

        public PartialViewResult EditorFor(ViewModelBase model) {
            model.IsAjax = true;
            return  PartialView("EditorForModel", model);
        }

        public PartialViewResult DisplayFor(ViewModelBase model)
        {
            model.IsAjax = true;
            return PartialView("DisplayForModel", model);
        }

        private TAppViewModel _appViewModel;

        public TAppViewModel AppViewModel
        {

            get {

                if (_appViewModel == null) {

                    var appViewModel = this.Session["AppViewModel"];

                    if (appViewModel == null) {
                        throw new Exception("AppViewModel was not properly initialized in Session_Start.");
                    }

                    _appViewModel = (TAppViewModel)appViewModel;
                    
                }
                
                return _appViewModel;
            }
        }
    }
}
