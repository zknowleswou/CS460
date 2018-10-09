using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    /// <summary>
    /// A custom unchecked exception to represent situations where 
    /// an illegal operation was performed on an empty queue.
    /// </summary>
    [Serializable]
    public class QueueUnderflowException : Exception
    {
        public QueueUnderflowException(string message) : base(message)
        {
        }

        public QueueUnderflowException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
