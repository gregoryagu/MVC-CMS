namespace TheCommLine.ViewModels.Contact
{
    using Core;

    public class PageHeader : ViewModelBase {
        
        public string PageTitleDefault = "Page Title";
        
        [MapToDb]
        public string PageTitle { get; set; }

        [Content]
        public Content Content { get; set; }

        
    }
}