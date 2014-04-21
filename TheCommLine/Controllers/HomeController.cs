using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheCommLine.Controllers
{
    using Core;

    using TheCommLine.ViewModels;
    using TheCommLine.ViewModels.Advertise;
    using TheCommLine.ViewModels.Classifieds;
    using TheCommLine.ViewModels.Contact;

    public class HomeController : ControllerBase<AppViewModel> {

        private AppRepository _appRepository;

        public AppRepository AppRepository {
            get {
                if (_appRepository == null) {
                    this._appRepository = new AppRepository();
                }
                return _appRepository;
            }
        }
        
        public ActionResult IndexS() {
            
            PageViewModelBase vm = new HomePage();
            vm = AppViewModel.GetPageViewModel(vm.ToString());
            if (vm == null) {
                vm = new HomePage();
                vm.GetData(this.AppRepository, this.AppViewModel);
                vm.IsLoggedIn = true;
                AppViewModel.AddPageViewModel(vm);
            }

            return View("PageViewModelBase", vm);
        }

        public ActionResult Contact() 
        {
            PageViewModelBase vm = new ContactPage();
            vm = AppViewModel.GetPageViewModel(vm.ToString());
            if(vm==null)
            {
                vm = new ContactPage();
                vm.GetData(this.AppRepository, this.AppViewModel);
                vm.IsLoggedIn = true;
                AppViewModel.AddPageViewModel(vm);
            }
            
            return View("PageViewModelBase", vm);
            
        }


        public ActionResult Advertise()
        {
            PageViewModelBase vm = new AdvertisePage();
            vm = AppViewModel.GetPageViewModel(vm.ToString());
            if (vm == null)
            {
                vm = new AdvertisePage();
                vm.GetData(this.AppRepository, this.AppViewModel);
                vm.IsLoggedIn = true;
                AppViewModel.AddPageViewModel(vm);
            }

            return View("PageViewModelBase", vm);
        }

        public ActionResult Index()
        {
            PageViewModelBase vm = new ClassifiedAdsPage();
            vm = AppViewModel.GetPageViewModel(vm.ToString());
            if (vm == null)
            {
                vm = new ClassifiedAdsPage();
                vm.GetData(this.AppRepository, this.AppViewModel);
                vm.IsLoggedIn = true;
                AppViewModel.AddPageViewModel(vm);
            }

            return View("PageViewModelBase", vm);
        }

    }
}