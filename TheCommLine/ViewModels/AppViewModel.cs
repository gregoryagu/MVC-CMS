namespace TheCommLine.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    using Core;

    using TheCommLine.Data.Entities;
    using TheCommLine.Models;


    public class AppViewModel 
    {

        public ThreeColumnContent GetThreeColumnContentViewModel(string key) {
            ThreeColumnContent vm;
            this._threeColumnContentViewModels.TryGetValue(key, out vm);
            return vm;
        }


        public Content GetContentViewModel(string id)
        {
            Content vm;
            this._contentViewModels.TryGetValue(id, out vm);
            return vm;
        }

        Dictionary<string, ThreeColumnContent> _threeColumnContentViewModels = new Dictionary<string, ThreeColumnContent>();
        public Dictionary<string,ThreeColumnContent> ThreeColumnContentViewModels { get { return _threeColumnContentViewModels; } } 

        Dictionary<string, Content> _contentViewModels = new Dictionary<string, Content>();
        public Dictionary<string, Content> ContentViewModels { get { return _contentViewModels; } } 
        
        Dictionary<string, ViewModelBase> _viewModels = new Dictionary<string, ViewModelBase>();

        public Dictionary<string, ViewModelBase> ViewModels {get { return _viewModels; } }

        Dictionary<string, PageViewModelBase> _pageViewModels = new Dictionary<string, PageViewModelBase>();
        public Dictionary<string, PageViewModelBase> PageViewModels { get { return _pageViewModels; } }

        public PageViewModelBase GetPageViewModel(string id)
        {
            PageViewModelBase vm;
            this._pageViewModels.TryGetValue(id, out vm);
            return vm;
        }

        public ViewModelBase GetViewModel(string id) {
            ViewModelBase vm;
            this._viewModels.TryGetValue(id, out vm);
            return vm;
        }

        public void AddViewModel(ViewModelBase vm) {
            this._viewModels.Add(vm.ToString(), vm);
        }

        public void AddPageViewModel(PageViewModelBase vm) {
            this._pageViewModels.Add(vm.ToString(), vm);
        }


        
    }
}