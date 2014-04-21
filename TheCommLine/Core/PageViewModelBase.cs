using System;
using System.Linq;

namespace Core
{
    using System.Reflection;
    using System.Web.UI.WebControls;

    using CMS.Core.ViewModels;

    using TheCommLine.Data.Entities;
    using TheCommLine.ViewModels;

    using Content = TheCommLine.ViewModels.Content;

    public class PageViewModelBase : ViewModelBase
    {
        

        [SharedViewModel]
        public NavBar NavBar { get; set; }
        
        [ViewModel]
        public Header Header { get; set; }
        
        [ViewModel]
        public Footer Footer { get; set; }
        
        [SharedViewModel]
        public EditThisPage EditThisPage { get; set; }

        public bool IsLoggedIn { get; set; }

        public EditMode EditMode { get; set; }

        

        //Do not retain a reference to appRepository as we don't want it in memory.
        internal void GetData(AppRepository appRepository, AppViewModel appViewModel, Type pageType = null) {
            if (pageType == null) {
                pageType = this.GetType();
            }
            GetProperties(appRepository, appViewModel, pageType);
            GetSharedProperties(appRepository, appViewModel, pageType);
            GetContent(appRepository, appViewModel, pageType);
            GetThreeColumnContent(appRepository, appViewModel, pageType);
            

        }

        
        public const string SharedKey = "Shared";

        private void GetSharedProperties(AppRepository appRepository, AppViewModel appViewModel, Type pageType)
        {
            var propertyInfos =
                pageType.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(SharedViewModelAttribute))).ToList();
            // write property names
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                ViewModelBase instance = (ViewModelBase)Activator.CreateInstance(propertyInfo.PropertyType);
                instance.ParentType = pageType;
                instance.Key = String.Format("{0}.{1}", SharedKey, propertyInfo.Name);
                if (appViewModel.ViewModels.ContainsKey(instance.Key))
                {
                    instance = appViewModel.GetViewModel(instance.Key);
                }
                else
                {
                    appRepository.GetProperties(instance, SharedKey);
                    appViewModel.ViewModels.Add(instance.Key, instance);
                }
                propertyInfo.SetValue(this, instance);
            }

        }

        private void GetThreeColumnContent(AppRepository appRepository, AppViewModel appViewModel, Type pageType)
        {
            var propertyInfos =
                pageType.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(ThreeColumnContentAttribute))).ToList();
            // write property names
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                ThreeColumnContent instance = (ThreeColumnContent)Activator.CreateInstance(propertyInfo.PropertyType);
                instance.ParentType = pageType;
                instance.Key = String.Format("{0}.{1}", pageType, propertyInfo.Name);
                if (appViewModel.ThreeColumnContentViewModels.ContainsKey(propertyInfo.Name))
                {
                    instance = appViewModel.GetThreeColumnContentViewModel(propertyInfo.Name);
                }
                else
                {
                    appRepository.GetThreeColumnContentEntity(instance, pageType, propertyInfo.Name);
                    appViewModel.ThreeColumnContentViewModels.Add(instance.Key, instance);
                }
                propertyInfo.SetValue(this, instance);
                
            }
        }

        
        

        private void GetProperties(AppRepository appRepository, AppViewModel appViewModel, Type pageType) {
            var propertyInfos =
                pageType.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(ViewModelAttribute))).ToList();
            // write property names
            foreach (PropertyInfo propertyInfo in propertyInfos) {
                ViewModelBase instance = (ViewModelBase)Activator.CreateInstance(propertyInfo.PropertyType);
                instance.ParentType = pageType;
                instance.Key = String.Format("{0}.{1}", pageType, propertyInfo.Name);
                if (appViewModel.ViewModels.ContainsKey(instance.Key)) {
                    instance = appViewModel.GetViewModel(instance.Key);
                }
                else {
                    appRepository.GetProperties(instance, pageType.ToString());
                    appViewModel.ViewModels.Add(instance.Key, instance);
                }
                propertyInfo.SetValue(this, instance);
            }

        }

        private void GetContent(AppRepository appRepository, AppViewModel appViewModel, Type pageType)
        {
            var propertyInfos =
                pageType.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(ContentAttribute))).ToList();
            // write property names
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                Content instance = (Content)Activator.CreateInstance(propertyInfo.PropertyType);
                instance.ParentType = pageType;
                instance.Key = String.Format( "{0}.{1}", pageType, propertyInfo.Name);
                
                if (appViewModel.ViewModels.ContainsKey(instance.Key))
                {
                    instance = appViewModel.GetContentViewModel(propertyInfo.Name);
                }
                else
                {
                    appRepository.GetContentEntity(instance, pageType, propertyInfo.Name);
                    appViewModel.ContentViewModels.Add(instance.Key, instance);
                }
                propertyInfo.SetValue(this, instance);



            }
        }





    }
}
