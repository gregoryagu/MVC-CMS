using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCommLine.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class ListEntity
    {
        public ListEntity() {
            this.Items = new List<ListItemEntity>();
        }
        
        public List<ListItemEntity> Items { get; set; }
        
        [Key]
        public int ListEntityId { get; set; }
        public string ListKey { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
