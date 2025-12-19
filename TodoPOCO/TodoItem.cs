using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoPOCO
{
    internal class TodoItem
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsComplete { get; set; } = false;

        public TodoItem()
        {

        }

        public TodoItem( string title, string description)
        {
            Title = title;
            Description = description;
            IsComplete = false;
        }
    }
}
