using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.DataStructures
{
    internal class QueueUsingCircularArray2
    {
        private object[] a;
        private int front = 0;
        private int rear = 0;

        public QueueUsingCircularArray2(int queueSize = 16)
        {
            a = new object[queueSize];
        }

        public void Enquene(object data)
        {
            if((rear + 1) % a.Length == front) //Full
            {
                throw new ApplicationException("Full");
            }

            a[rear] = data;
            rear = (rear + 1) % a.Length;
        }


        public object Dequeue()
        {
            if(front == rear) //Empty
            {
                throw new ApplicationException("Empty");
            }

            object data = a[front];
            front = (front + 1) % a.Length;
            return data;
        }

    }
}
