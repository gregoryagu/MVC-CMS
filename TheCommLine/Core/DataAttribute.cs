using System;

namespace Core
{
    using System.Collections.Generic;

    [System.AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public sealed class ListItemAttribute : System.Attribute {
        public ListItemAttribute(string value, string text) {
            this.Value = value;
            this.Text = text;
        }
        public string Value { get; set; }
        public string Text { get; set; }
    }


    [System.AttributeUsage(AttributeTargets.Property)]
    public sealed class MapToDbAttribute : System.Attribute{}

    [System.AttributeUsage(AttributeTargets.Property)]
    public sealed class ViewModelAttribute : System.Attribute { }

    [System.AttributeUsage(AttributeTargets.Property)]
    public sealed class SharedViewModelAttribute : System.Attribute { }

    [System.AttributeUsage(AttributeTargets.Property)]
    public sealed class ContentAttribute : System.Attribute { }

    [System.AttributeUsage(AttributeTargets.Property)]
    public sealed class ThreeColumnContentAttribute : System.Attribute { }

    [System.AttributeUsage(AttributeTargets.Property)]
    public sealed class MapToListAttribute : System.Attribute { }

}