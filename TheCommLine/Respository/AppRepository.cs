using System;
using System.Linq;

namespace Core
{
    using System.Reflection;

    using Microsoft.Ajax.Utilities;

    using TheCommLine.Data.Repository;
    using TheCommLine.ViewModels;

    public class AppRepository {

        

        private ContentRepository _contentRepository;

        public ContentRepository ContentRepository
        {
            get
            {
                if (_contentRepository == null)
                {
                    this._contentRepository = new ContentRepository();
                }
                return _contentRepository;
            }

        }


        private SettingsRepository _settingsRepository;

        public SettingsRepository SettingsRepository {
            get {
                if (_contentRepository == null) {
                    this._settingsRepository = new SettingsRepository();
                }
                return _settingsRepository;
            }

        }
        


        public void SaveProperties(ViewModelBase viewModel, ViewModelBase currentViewModel) {
            this.SettingsRepository.SaveProperties(viewModel, currentViewModel);
        }

        public void GetProperties(ViewModelBase currentViewModel, string key)
        {
            this.SettingsRepository.GetProperties(currentViewModel, key);
        }

        internal void GetContentEntity(Content instance, Type type, string name) {
            this.ContentRepository.GetContentEntity(instance, type, name);
        }

        internal void GetThreeColumnContentEntity(ThreeColumnContent instance, Type type, string name)
        {
            this.ContentRepository.GetThreeColumnContentEntity(instance, type, name);
        }
    }
}
