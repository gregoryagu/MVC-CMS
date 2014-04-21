using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCommLine.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class ClassifiedAdEntity
    {
        public String Name { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public int NumberOfIssues { get; set; }

        public decimal TotalAmount { get; set; }

        public int AdLength { get; set; }

        public int Category { get; set; }

        public string AdText { get; set; }
    }
}
