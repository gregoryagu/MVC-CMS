using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCommLine.ViewModels.Classifieds
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Core;

    using TheCommLine.Data.Entities;

    public class ClassifiedAd : ViewModelBase
    {


        [MapToDb]
        [DisplayName("Name")]
        public String NameLabel { get; set; }

        [EmailAddress]
        [MapToDb]
        [DisplayName("Email Address")]
        public string EmailAddressLabel { get; set; }
        

        [MapToDb]
        [DisplayName("Phone Number")]
        public string PhoneNumberLabel { get; set; }
        
        [MapToDb]
        [DisplayName("Number of Issues")]
        public string NumberOfIssuesLabel { get; set; }


        [MapToDb]
        [DisplayName("Total Amount")]
        public String TotalAmountLabel { get; set; }

        [MapToDb]
        [DisplayName("Number of Issues")]
        public String AdLengthLabel { get; set; }

        [MapToDb]
        [DisplayName("Category")]
        public string CategoryLabel { get; set; }

        [MapToDb]
        [DisplayName("Ad Text")]
        public string AdTextLabel { get; set; }

        ClassifiedAdEntity _classifiedAdEntity = new ClassifiedAdEntity();
        public ClassifiedAdEntity ClassifiedAdEntity { get { return this._classifiedAdEntity; } }


        [MapToList]
        [ListItem("EmploymentOpportunities", "Employment Opportunities")]
        [ListItem("BusinessOpportunities","Business Opportunities")]
        [ListItem("ForSale", "For Sale")]
        [ListItem("Wanted", "Wanted")]
        [ListItem("RealEstateForSale", "Real Estate For Sale")]
        [ListItem("Rentals", "Rentals: Home/Office/Apt")]
        [ListItem("Personals", "Personals")]
        public ListEntity AdCategories { get; set; }

        public int SelectedAdCategoryId { get; set; } 

    }
}
