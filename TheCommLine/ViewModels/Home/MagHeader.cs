namespace TheCommLine.ViewModels
{
    using Core;

    public class MagHeader : ViewModelBase {

        public string MagDateDefault = "January 2014";
        
        [MapToDb]
        public string MagDate { get; set; }

        public string MagTitleDefault = "The Comm Line Magazine";
        
        [MapToDb]
        public string MagTitle { get; set; }

        public string DownloadTextDefault = "Download";

        [MapToDb]
        public string DownloadText { get; set; }

        [MapToDb]
        public int IssueNumber { get; set; }

        
    }
}