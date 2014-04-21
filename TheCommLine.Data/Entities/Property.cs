using System;

namespace TheCommLine.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Property
    {
        [Key]
        public int Id { get; set; }
        public string Key { get; set; }
        public string StringValue { get; set; }
        public int IntValue { get; set; }
        public DateTime? DateValue { get; set; }
        public bool BoolValue { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
