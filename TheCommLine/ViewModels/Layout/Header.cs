namespace CMS.Core.ViewModels
{
    using global::Core;

    public class Header : ViewModelBase {
        public string TagLineDefault = "Connecting People and Businesses since 1992";
        
        [MapToDb]
        public string TagLine { get; set; }
    }
}
