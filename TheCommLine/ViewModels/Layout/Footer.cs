namespace CMS.Core.ViewModels
{
    using global::Core;

    public class Footer : ViewModelBase {
        public string CompanyNameDefault = "Creative Communications & Designs, Inc";
        
        [MapToDb]
        public string CompanyName { get; set; }

        public string PoweredByDefault = "Web Design: Greg Gum";
        
        [MapToDb]
        public string PoweredBy { get; set; }
    }
}
