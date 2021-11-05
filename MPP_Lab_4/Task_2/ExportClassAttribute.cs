using System;

namespace Task_2
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ExportClassAttribute : Attribute
    {
        public ExportClassAttribute()
        {
            Category = "No initialization";
        }
        public ExportClassAttribute(string category)
        {
            Category = category;
        }
        public string Category { get; set; }
    }
}
