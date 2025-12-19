using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoPOCO
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsComplete { get; set; } = false;

        public TodoItem() { }

        public TodoItem(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public TodoItem(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }

}
