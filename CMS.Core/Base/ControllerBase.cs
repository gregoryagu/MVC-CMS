using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core
{
    using System.Web.Mvc;

    public class ControllerBase<TAppViewModel, TViewModel> : Controller where TAppViewModel : class, new() where TViewModel : ViewModelBase {


        private AppRepository _appRepository;

        public AppRepository AppRepository
        {
            get
            {
                if (_appRepository == null)
                {
                    this._appRepository = new AppRepository();
                }
                return _appRepository;
            }
        }

        public PartialViewResult ProcessRequest(TViewModel viewModel)
        {
            if (viewModel.RequestedAction == RequestedAction.Edit)
            {
                return EditorFor(viewModel);
            }
            if (viewModel.RequestedAction == RequestedAction.Save)
            {
                AppRepository.SaveProperties(viewModel, AppViewModel.HomePage.MagHeader);
                AppRepository.GetProperties(AppViewModel.HomePage.MagHeader);
                return DisplayFor(AppViewModel.HomePage.MagHeader);
            }
            if (viewModel.RequestedAction == RequestedAction.Cancel)
            {
                return DisplayFor(AppViewModel.HomePage.MagHeader);
            }
            throw new Exception(String.Format("Requested Action not supported: {0}", viewModel.RequestedAction));
        }

        //It is vital to set IsAjax to true for all partial views.
        public PartialViewResult PartialView(string template, ViewModelBase model) {
            model.IsAjax = true;
            return base.PartialView(template, model);
        }

        public PartialViewResult EditorFor(ViewModelBase model) {
            model.IsAjax = true;
            return  PartialView("EditorForModel", model);
        }

        public PartialViewResult DisplayFor(ViewModelBase model)
        {
            model.IsAjax = true;
            return PartialView("DislayForModel", model);
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
