using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoPOCO
{
    public interface ICreate<T>
    {
        void Add(T item);
    }
}
