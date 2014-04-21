using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCommLine.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class ListItemEntity
    {
        [Key]
        public int ListItemEntityId { get; set; }
        public int ListEntityId { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }

        public virtual ListEntity ListEntity { get; set; }
    }
}
