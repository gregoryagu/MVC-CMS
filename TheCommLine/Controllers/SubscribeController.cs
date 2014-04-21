using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheCommLine.Controllers
{
    using System.Web.Mvc;

    using TheCommLine.ViewModels;

    public class SubscribeController : PropertyControllerBase<Subscribe> {

        public override PartialViewResult ProcessRequest(Subscribe viewModel)
        {
            viewModel.GetKeyFromId();
            //Process subscription.
            if (viewModel.RequestedAction == "Subscribe") {
                var currentViewModel = AppViewModel.GetViewModel(viewModel.Key);
                return DisplayFor(currentViewModel);
            }
            
            return  base.ProcessRequest(viewModel);
            
        }
        

    }
}