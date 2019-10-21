using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS460HW3
{
    public class QueueUnderflowException : Exception
    {
  public QueueUnderflowException()
    {
    }

    public QueueUnderflowException(String message) 
            : base(message)
    {
    }
}

}
