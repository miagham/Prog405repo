using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoPOCO
{
    internal class TodoRepository
    {
        private List<TodoItem> _items = new List<TodoItem>();

        public void Add(TodoItem item)
        {
            // TODO:  Add the item to the list
        }

        public TodoItem? Get(int id)
        {
            // TODO: Find and return the item with this ID
            return null;
        }

        public List<TodoItem> GetAll()
        {
            // TODO:  Return every item in the list
            return new List<TodoItem>();
        }

        public void Update(TodoItem item)
        {
            // TODO: Update the matching item in the list
        }

        public void Delete(int id)
        {
            // TODO: Remove the item with this ID
        }
    }
    
}
