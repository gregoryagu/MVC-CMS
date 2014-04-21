namespace TheCommLine.ViewModels
{
    using Core;

    public class Subscribe : ViewModelBase {
        
        public string SubscribeTextDefault = "Subscribe to get future issues by email";
        
        [MapToDb]
        public string SubscribeText { get; set; }

        public string SubscribeButtonDefault = "Subscribe Now!";

        [MapToDb]
        public string SubscribeButton { get; set; }

        public string EmailAddress { get; set; }
    }
}