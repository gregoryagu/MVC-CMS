using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheCommLine.Controllers
{
    using System.Web.Mvc;

    using Core;

    using TheCommLine.ViewModels;

    public class PropertyControllerBase<T> : ControllerBase<AppViewModel> where T : ViewModelBase
    {

        public virtual PartialViewResult ProcessRequest(T viewModel) {
            viewModel.GetKeyFromId();
            if (viewModel.RequestedAction == RequestedAction.Edit.ToString())
            {
                var currentViewModel = AppViewModel.GetViewModel(viewModel.Key);
                if (currentViewModel == null) {
                    Response.StatusCode = 404;
                    return null;
                }
                return EditorFor(currentViewModel);
            }
            if (viewModel.RequestedAction == RequestedAction.Save.ToString()) {
                var currentViewModel = AppViewModel.GetViewModel(viewModel.Key); 
                AppRepository.SaveProperties(viewModel, currentViewModel);
                AppRepository.GetProperties(currentViewModel, currentViewModel.ParentType.ToString());
                return DisplayFor(currentViewModel);
            }
            if (viewModel.RequestedAction == RequestedAction.Cancel.ToString())
            {
                var currentViewModel = AppViewModel.GetViewModel(viewModel.Key); 
                return DisplayFor(currentViewModel);
            }
            if (viewModel.RequestedAction == RequestedAction.None.ToString()) {
                return null;
            }
            throw new Exception(String.Format("Requested Action not supported: {0}", viewModel.RequestedAction));
        }
        
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
    }
}