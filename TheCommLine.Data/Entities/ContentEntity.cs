using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCommLine.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class ContentEntity
    {
        [Key]
        public int Id { get; set; }
        public string Key { get; set; }
        public string Data { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
