namespace Core
{
    using System;

    public class ViewModelBase
    {
        //The Id is set by the Model Binder when processing requests. It will have dashes in it instead of periods due to JQuery.
        public string Id { get; set; }
        
        public string Controller
        {
            get
            {
                return this.ToString().Substring(this.ToString().LastIndexOf('.') + 1);
            }
           
        }


        public readonly string ActionName = "ProcessRequest";

        public string RequestedAction { get; set; }

        public bool IsAjax { get; set; }

        public Type ParentType { get; set; }

        public string Key { get; set; }

        public string HtmlId {
            get {
                if(Key!=null)
                    return Key.Replace('.', '-');
                else {
                    return String.Empty;
                }
            }
        }

        public void GetKeyFromId() {
            if(this.Id != null)
                this.Key = Id.Replace('-', '.');
        }
    }
}