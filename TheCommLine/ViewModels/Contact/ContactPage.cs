namespace TheCommLine.ViewModels.Contact
{
    using Core;

    public class ContactPage :  PageViewModelBase {

        public static string ClassName = "ContactPage";

        [ViewModel]
        public PageHeader PageHeader { get; set; }

        [Content]
        public Content Content { get; set; }

        [ThreeColumnContent]
        public ThreeColumnContent ContactDetails { get; set; }

        
            
        
    }
}