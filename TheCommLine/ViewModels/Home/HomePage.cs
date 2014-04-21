namespace TheCommLine.ViewModels
{
    using Core;

    public class HomePage : PageViewModelBase {
       
        [ViewModel]
        public MagHeader MagHeader { get; set; }
        
        public MagViewer MagViewer { get; set; }
        
        [ViewModel]
        public Subscribe Subscribe { get; set; }


        
    }
}