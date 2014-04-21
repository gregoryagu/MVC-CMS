namespace CMS.Core.ViewModels
{
    using global::Core;

    public class NavBar : ViewModelBase {
        public string HomePageDefault = "Home";
        
        [MapToDb]
        public string HomePage { get; set; }

        public string AdvertisePageDefault = "Advertise";
        
        [MapToDb]
        public string AdvertisePage { get; set; }

        public string ClassifiedAdsPageDefault = "Place Classified Ad";

        [MapToDb]
        public string ClassifiedAdsPage { get; set; }

        public string ContactPageDefault = "Contact";
        
        [MapToDb]
        public string ContactPage { get; set; }
    }
}
