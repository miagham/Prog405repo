using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoPOCO
{
    public class TodoRepository : ICreate, IUpdate
    {
        public TodoItem Create(string title, string description)
        {
            return new TodoItem(title, description);
        }

        public void MarkComplete(TodoItem item)
        {
            item.IsComplete = true;
        }
    }


}
