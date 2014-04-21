using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheCommLine.Controllers
{
    using Core;

    using TheCommLine.Data.Repository;
    using TheCommLine.ViewModels;

    public class ThreeColumnContentController : ControllerBase<AppViewModel>
    {
        public virtual PartialViewResult ProcessRequest(ThreeColumnContent viewModel)
        {
            viewModel.GetKeyFromId();
            if (viewModel.RequestedAction == RequestedAction.Edit.ToString())
            {
                var currentViewModel = AppViewModel.GetThreeColumnContentViewModel(viewModel.Key);
                return EditorFor(currentViewModel);
            }
            if (viewModel.RequestedAction == RequestedAction.Save.ToString())
            {
                var currentViewModel = AppViewModel.GetThreeColumnContentViewModel(viewModel.Key);
                Repository.SaveProperties(viewModel, currentViewModel);
                return DisplayFor(currentViewModel);
            }
            if (viewModel.RequestedAction == RequestedAction.Cancel.ToString())
            {
                var currentViewModel = AppViewModel.GetThreeColumnContentViewModel(viewModel.Key);
                return DisplayFor(currentViewModel);
            }
            throw new Exception(String.Format("Requested Action not supported: {0}", viewModel.RequestedAction));
        }

        private ContentRepository _repository;

        public ContentRepository Repository
        {
            get
            {
                if (_repository == null)
                {
                    this._repository = new ContentRepository();
                }
                return _repository;
            }
        }
    }
}