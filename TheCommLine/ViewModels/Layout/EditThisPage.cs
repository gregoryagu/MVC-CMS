namespace CMS.Core.ViewModels
{
    using global::Core;

    public class EditThisPage : ViewModelBase {
        public string EditThisPageTextDefault = "Edit this page";
        
        [MapToDb]
        public string EditThisPageText { get; set; }

        [MapToDb]
        public string CancelButtonText { get; set; }

        public string CancelButtonTextDefault = "Cancel";
    }
}
