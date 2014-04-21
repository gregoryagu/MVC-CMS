using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheCommLine.ViewModels.Advertise
{
    using Core;

    using TheCommLine.ViewModels.Contact;

    public class AdvertisePage :  PageViewModelBase {

        [ViewModel]
        public PageHeader PageHeader { get; set; }

        [Content]
        public Content Content { get; set; }
        
        
    }
}