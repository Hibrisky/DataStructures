using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.DataStructures
{
    internal class QueueUsingCircularArray3
    {
        private object[] a;
        private int front = 0;
        private int rear = 0;

        public int Count { get; private set; } = 0;

        public QueueUsingCircularArray3(int queueSize = 16)
        {
            a = new object[queueSize];
        }

        public void Enquen(object data)
        {
            if(Count == a.Length)//Full
            {
                throw new ApplicationException();
            }

            a[rear] = data;
            rear = (rear + 1) % a.Length;
            Count++;
        }

        public object Dequene()
        {
            if(Count == 0)//Empty
            {
                throw new ApplicationException("Empty");
            }

            object data = a[front];
            front = (front + 1) % a.Length;
            Count++;
            return data;
        }

    }
}
