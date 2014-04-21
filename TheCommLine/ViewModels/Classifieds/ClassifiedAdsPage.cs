using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheCommLine.ViewModels.Classifieds
{
    using System.ComponentModel.DataAnnotations;

    using Core;

    using TheCommLine.ViewModels.Advertise;
    using TheCommLine.ViewModels.Contact;

    public class ClassifiedAdsPage :  PageViewModelBase {

        [ViewModel]
        public PageHeader PageHeader { get; set; }

        [Content]
        public Content Content { get; set; }

        [ViewModel]
        public ClassifiedAd ClassifiedAd { get; set; }
    }
}