using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.DataStructures
{
    internal class QueueUsingCircularArray
    {
        //단순화를 위해 object 데이타 타입 사용
        private object[] a;
        private int front;
        private int rear;

        public int Capacity
        {
            get { return a.Length; }
        }

        //디폴트 큐 크기는  16이지만 지정가능하게.
        public QueueUsingCircularArray(int queueSize = 16)
        {
            a = new object[queueSize];
            front = -1;
            rear = -1;
        }

        public void Enquene(object data)
        {
            //큐가 가득 차 있는지 체크
            if ((rear + 1) % a.Length == front)
            {
                //에러처리또는 배열 확장.
                int newsize = Capacity * 2;
                var temp = new object[newsize];
                for(int i=0;i<a.Length;++i)
                {
                    temp[i] = a[i];
                }
                a = temp;
                a[++rear] = data;
            }
            else
            {
                //비어있는 경우
                if (front == -1)
                    front++;
                //데이터 추가
                rear = (rear + 1) % a.Length;
                a[rear] = data;
            }
        }

        public object Dequeue()
        {
            //큐가 비어있는지 체크
            if (front == -1 && rear == -1)
            {
                throw new ApplicationException("Empty");
            }
            else
            {
                //데이타 읽기
                object data = a[front];

                //마지막 요소를 읽는 경우
                if (front == rear)
                {
                    //특수값 -1 로 설정
                    front = -1;
                    rear = -1;
                }
                else
                {
                    //front 이동
                    front = (front + 1) % a.Length;
                }

                return data;
            }
        }

    }
}
