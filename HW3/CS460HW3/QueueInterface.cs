using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS460HW3
{
    public interface IQueueInterface<T>
    {

        T Push(T element);
        T Pop();
        T Peek();
        bool IsEmpty();
      
    }
}
