using System.Linq;

namespace Core {
    using System;
    using System.ComponentModel;
    using System.Reflection;

    using TheCommLine.Data;
    using TheCommLine.Data.Entities;

    public class SettingsRepository : RepositoryBase<ApplicationDbContext> {
        public SettingsRepository() {
            this.DbContext = new ApplicationDbContext();
        }

        private void AddItem(ListEntity list, ListItemAttribute listItem)
        {
            var item = new ListItemEntity();
            item.Value = listItem.Value;
            item.Text = listItem.Text;
            list.Items.Add(item);
            this.DbContext.SaveChanges();
        }

        public ListEntity GetList(string key)
        {
           return this.DbContext.ListEntities.Include("Items").FirstOrDefault(i => i.ListKey == key);
        }

        public Property GetSetting(string key, string parentKey) {
            key = GetKey(key, parentKey);
            return this.DbContext.Settings.Where(i => i.Key == key).OrderByDescending(i => i.CreatedOn).FirstOrDefault();
        }

        private string GetKey(string key, string parentKey) {
            return String.Format("{0}.{1}", parentKey, key);
        }

        public Property CreateStringSetting(object entity, string key, string parentKey, Type type, string defaultValue) {
            Property setting = new Property();
            setting.Key = GetKey(key, parentKey);
            setting.StringValue = GetDefaultValue(key, defaultValue);
            setting.CreatedOn = DateTime.UtcNow;
            this.DbContext.Settings.Add(setting);
            this.DbContext.SaveChanges();
            return setting;
        }

        public ListEntity CreateList(object entity, string key, Type type)
        {
            var list = new ListEntity();
            list.ListKey = key;
            list.CreatedOn = DateTime.UtcNow;
            this.DbContext.ListEntities.Add(list);
            this.DbContext.SaveChanges();
            return list;
        }


        private string GetDefaultValue(string key, string defaultValue) {

            if (String.IsNullOrWhiteSpace(defaultValue)) defaultValue = key;

            return defaultValue;
      
        }


        

        //Always create a new setting, so old ones are not lost in case of operator error.
        public Property UpdateStringSetting(string key, string value, string parentKey, Type type) {
            Property setting = new Property();
            setting.Key = GetKey(key, parentKey);
            setting.StringValue = value;
            setting.CreatedOn = DateTime.UtcNow;
            this.DbContext.Settings.Add(setting);
            this.DbContext.SaveChanges();
            return setting;
        }

        

        public void SaveProperties(ViewModelBase newValues, ViewModelBase oldValues) {
            Type thetype = newValues.GetType();
            Type parentType = oldValues.ParentType;

            var propertyInfos =
                thetype.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(MapToDbAttribute))).ToList();
            ;
            // write property names
            foreach (PropertyInfo propertyInfo in propertyInfos) {
                if (propertyInfo.PropertyType == typeof(string)) {

                    var newValue = (string)propertyInfo.GetValue(newValues);
                    var oldValue = (string)propertyInfo.GetValue(oldValues);

                    if (newValue != oldValue) {
                        this.UpdateStringSetting(propertyInfo.Name, newValue, parentType.ToString(), thetype);
                    }

                }
                
            }

        }


        public void GetProperties(ViewModelBase viewModel, string key) {
            Type thetype = viewModel.GetType();

            GetOrCreatePropertiesFromDb(viewModel, key, thetype);
            GetOrCreateList(viewModel, thetype);
        }

        private void GetOrCreateList(ViewModelBase viewModel, Type thetype)
        {
            var propertyInfos =
                thetype.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(MapToListAttribute))).ToList();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                var list = this.GetList(propertyInfo.Name);
                if (list == null)
                {
                    list = this.CreateList(viewModel, propertyInfo.Name, thetype);
                    var listItems = propertyInfo.GetCustomAttributes(typeof(ListItemAttribute));
                    foreach (var attribute in listItems) {
                        var listItem = (ListItemAttribute)attribute;
                        this.AddItem(list, listItem);
                    }
                    
                   
                }

                if (list!=null) { }
                propertyInfo.SetValue(viewModel, list);
            }
        }

       

        private void GetOrCreatePropertiesFromDb(ViewModelBase viewModel, string key, Type thetype) {
            var propertyInfos =
                thetype.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(MapToDbAttribute))).ToList();
            foreach (PropertyInfo propertyInfo in propertyInfos) {
                var setting = this.GetSetting(propertyInfo.Name, key);
                if (setting == null) {
                    string defaultValue = String.Empty;
                    var attribute = propertyInfo.GetCustomAttribute<DisplayNameAttribute>();
                    if (attribute != null) {
                        defaultValue = attribute.DisplayName;
                    }
                    setting = this.CreateStringSetting(viewModel, propertyInfo.Name, key, thetype, defaultValue);
                }

                if (!String.IsNullOrWhiteSpace(setting.StringValue)) {}
                propertyInfo.SetValue(viewModel, setting.StringValue);
            }
        }
    }




}
