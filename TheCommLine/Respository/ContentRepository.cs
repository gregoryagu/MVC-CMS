using System;
using System.Linq;

namespace TheCommLine.Data.Repository
{
    using System.Reflection;

    using Core;
    using TheCommLine.Data.Entities;
    using TheCommLine.ViewModels;

    public class ContentRepository : RepositoryBase<ApplicationDbContext>
    {


        internal void SaveProperties(ThreeColumnContent viewModel, ThreeColumnContent currentViewModel)
        {
            this.SaveProperties(viewModel.Column1, currentViewModel.Column1);
            this.SaveProperties(viewModel.Column2, currentViewModel.Column2);
            this.SaveProperties(viewModel.Column3, currentViewModel.Column3);
        }

        public void GetThreeColumnContentEntity(ThreeColumnContent viewModel, Type parentType, string name) {
            Type thetype = viewModel.GetType();

            //PropertyInfo[] propertyInfos;
            var propertyInfos =
                thetype.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(MapToDbAttribute))).ToList();
            foreach (PropertyInfo propertyInfo in propertyInfos) {
                var keyBase = String.Format("{0}.{1}", name, propertyInfo.Name);
                //var key = GetKey(keyBase, parentType);
                var contentEntity = this.GetContentEntity(keyBase, parentType);
                if (contentEntity == null)
                {
                    contentEntity = this.CreateContentEntity(
                        viewModel,
                        keyBase,
                        parentType,
                        thetype);
                }

                var columnViewModel = new Column();
                
                if (!String.IsNullOrWhiteSpace(contentEntity.Data)) {
                    columnViewModel.Data = contentEntity.Data;
                    columnViewModel.Key = GetKey(keyBase, parentType);
                }
                propertyInfo.SetValue(viewModel, columnViewModel);

            }
        }

        public void SaveProperties( Content newValues, Content oldValues) {

            if (newValues.Data != oldValues.Data) {
                this.SaveContent(oldValues.Key, newValues.Data);
                //Also update the current values so that we don't have to hit the DB again.
                oldValues.Data = newValues.Data;
            }
        }

        public void GetContentEntity(Content viewModel, Type parentType, string name)
        {
            Type thetype = viewModel.GetType();

            //PropertyInfo[] propertyInfos;
            var propertyInfos =
                thetype.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(MapToDbAttribute))).ToList();
            //There should be only one Property in this loop.
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                var content = this.GetContentEntity(name, parentType);
                if (content == null)
                {
                    content = this.CreateContentEntity(
                        viewModel,
                        name,
                        parentType,
                        thetype);
                }

                if (!String.IsNullOrWhiteSpace( content.Data)) { }
                propertyInfo.SetValue(viewModel, content.Data);
                viewModel.Key = content.Key;

            }
        }


        public ContentRepository() {
            this.DbContext = new ApplicationDbContext();
        }
        
        public ContentEntity GetContentEntity(string key, Type parentType) {
            key = GetKey(key, parentType);
            return this.DbContext.Contents.Where(i=> i.Key == key).OrderByDescending(i=> i.CreatedOn).FirstOrDefault();
        }

        private string GetKey(string key, Type parentType) {
            return String.Format("{0}.{1}", parentType, key);
        }

        public  ContentEntity CreateContentEntity(object entity, string key, Type parentType, Type type)
        {
            var content = new ContentEntity();
            content.Key = GetKey(key, parentType);
            content.Data = GetDefaultValue(entity, key, type);
            content.CreatedOn = DateTime.UtcNow;
            this.DbContext.Contents.Add(content);
            this.DbContext.SaveChanges();
            return content;
        }

        //Always create a new setting, so old ones are not lost in case of operator error.
        public ContentEntity SaveContent(string key, string value)
        {
            var content = new ContentEntity();
            content.Key = key;
            content.Data = value;
            content.CreatedOn = DateTime.UtcNow;
            this.DbContext.Contents.Add(content);
            this.DbContext.SaveChanges();
            return content;
        }

        private string GetDefaultValue(object entity, string key, Type type)
        {

            string defaultValue = key;

            //Look for a default field.
            var fieldName = key + "Default";

            FieldInfo fieldInfo = type.GetField(fieldName);

            if (fieldInfo != null)
            {
                defaultValue = (string)fieldInfo.GetValue(entity);
            }

            return defaultValue;

        }





        
    }
}
