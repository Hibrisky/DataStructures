using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //SinglyLinkedList();
            DoublyLinkedList();
        }
        #region SinglyLinkedList
        static void SinglyLinkedList()
        {
            //정수형 단일 연결 리스트 생성.
            var list = new SingleLinkedList.SinglyLinkedList<int>();

            //리스트에 0 ~ 4 추가.
            for (int i = 0; i < 5; i++)
            {
                list.Add(new SingleLinkedList.SinglyLinkedNode<int>(i));
            }

            //index가 2인 요소 삭제.
            var node = list.GetNode(2);
            list.Remove(node);

            //index가 1인 요소 가져오기
            node = list.GetNode(1);
            //index가 1인 요소 뒤에 100 삽입.
            list.AddAfter(node, new SingleLinkedList.SinglyLinkedNode<int>(100));

            //리스트 카운트 체크
            int count = list.Count();

            //전체 리스트 출력
            //결과: 0 1 100 3 4
            for (int i = 0; i < count; i++)
            {
                var n = list.GetNode(i);
                Console.WriteLine(n.Data);
            }
        }
        #endregion

        #region DoublyLinkedList
        static void DoublyLinkedList()
        {
            //정수형 이중 연결 리스트 생성.
            var list = new DoubleLinkedList.DoublylinkedList<int>();

            //리스트에 0~4 추가.
            for(int i=0;i<5;i++)
            {
                list.Add(new DoubleLinkedList.DoublyLinkedListNode<int>(i));
            }

            //Index가 2인요소 삭제
            var node = list.GetNode(2);
            list.Remove(node);

            //index가 1인 요소 가져오기
            node = list.GetNode(1);
            //index가 1인 요소 뒤에 100 삽입.
            list.AddAfter(node, new DoubleLinkedList.DoublyLinkedListNode<int>(100));

            //리스트 카운트 체크
            int count = list.Count();

            //전체 리스트 출력
            //결과 : 0 1 100 3 4
            for(int i=0;i<count;i++)
            {
                var n = list.GetNode(i);
                Console.WriteLine(n.Data);
            }

            //리스트 역 출력
            //결과 : 4 3 100 1 0
            Console.WriteLine("역으로 출력.");
            node = list.GetNode(count-1);
            for(int i = 0;i<count;i++)
            {
                Console.WriteLine(node.Data);
                node = node.Prev;
            }


        }
        #endregion

        #region ArrayTest
        //가변 배열 테스트
        static void JaggedArrayTest()
        {
            //가변 배열.
            int[][] A = new int[3][];

            A[0] = new int[2];
            A[1] = new int[6] { 1, 2, 3, 4, 5, 6 };
            A[2] = new int[3] { 9, 8, 7 };

            for (int i = 0; i < A.Length; ++i)
            {
                for (int j = 0; j < A[i].Length; ++j)
                {
                    Console.Write(A[i][j]);
                }
                Console.WriteLine();
            }
        }

        //동적 배열 테스트
        static void DynamicArrayTest()
        {
            DynamicArray dynamicArray = new DynamicArray(10);//기본 사이즈는 16으로 설정되어있음.
            
            for(int i=0;i< 20; ++i)
            {
                dynamicArray.Add(i * 2);
            }

            Console.WriteLine(string.Format("{0} 번째 인덱스에 들어있는 값 : ", 15) + dynamicArray.Get(15));

            dynamicArray.Remove(15);
            dynamicArray.RemoveAll();

        }

        //환영 배열 사용 테스트.
        static void CircularArrayTest()
        {
            char[] A = "abcdefgh".ToCharArray();
            int startindex = 4;

            for(int i = 0;i<A.Length;++i)//단순한 환영 배열.
            {
                int index = (startindex + i) % A.Length;
                Console.Write(A[index] + " ");
            }

            Console.WriteLine();

            List<int> temp = new List<int>();
            for(int i=0;i< 30; ++i)
            {
                temp.Add(i);
                Console.WriteLine("list<int> capacity : " + temp.Capacity);
            }

            Dictionary<int,int> dic_temp = new Dictionary<int,int>();
            for(int i=0;i<30;++i)
            {
                dic_temp.Add(i, i);
                //Console.WriteLine("dic_temp<int> capacity : " + dic_temp.);
            }
        }
        #endregion
    }


    //동적 배열.
    public class DynamicArray
    {
        private object[] arr = new object[0];
        private const int GROWTH_FACTOR = 2;
        private const int INITIAL_CAPACITY = 16;

        public int Count { get; private set; }
        public int Capacity//배열의 용량.(Size)
        {
            get { return arr.Length; }
        }

        public DynamicArray(int capacity = 16)//생성시 초기화. 
        {
            arr = new object[capacity];
            Count = 0;
        }

        public void Add(object element)
        {
           //배열이 찼을때 확장
           if(Count >= Capacity)
            {
                int newSize = Capacity * GROWTH_FACTOR;
                var temp = new object[newSize];
                for(int i=0;i<arr.Length;++i) 
                {
                    temp[i] = arr[i];//기존 배열을 임시 배열로 복사
                }
                arr = temp;//임시 배열 해제와 초기화.
            }
            arr[Count++] = element;
        }

        public object Get(int index)
        {
            if(index > Capacity - 1)//찾으려는 index가 배열의 크기보다 클 경우.
                throw new ApplicationException("Element not found");

            if (arr[index] == null)
                throw new ApplicationException("Element not found");



            return arr[index];
        }

        public void Remove(int index)
        {
            if (index > Capacity - 1)//찾으려는 index가 배열의 크기보다 클 경우.
                throw new ApplicationException("Element not found");

            arr[index] = null;
        }

        public void RemoveAll()
        {
            arr = new object[INITIAL_CAPACITY];
            Count = 0;
        }
    }

    #region 단일 연결 리스트

    ////단일 연결리스트에 노드
    //public class SinglyLinkedNode<T>
    //{
    //    public T Data { get; set; }
    //    public SinglyLinkedNode<T> Next { get; set; }

    //    public SinglyLinkedNode(T data)
    //    {
    //        this.Data = data;
    //        this.Next = null;
    //    }
    //}

    ////단일 링크드리스트
    //public class SinglyLinkedList<T>
    //{
    //    private SinglyLinkedNode<T> head;

    //    public void Add(SinglyLinkedNode<T> newNode)
    //    {
    //        //List is Empty
    //        if (head == null)
    //            head = newNode;
    //        else
    //        {
    //            var current = head;
    //            //마지막 노드로 이동하여 추가.
    //            while(current != null && current.Next != null)
    //            {
    //                current = current.Next;
    //            }
    //            current.Next = newNode;
    //        }
    //    }

    //    public void AddAfter(SinglyLinkedNode<T> current, SinglyLinkedNode<T> newNode)
    //    {
    //        if(head == null ||current == null || newNode == null)
    //        {
    //            throw new InvalidOperationException();
    //        }

    //        newNode.Next = current.Next;
    //        current.Next = newNode;
    //    }


    //    public void Remove(SinglyLinkedNode<T> removeNode)
    //    {
    //        if (head == null || removeNode == null)
    //            return;

    //        //삭제할 노드가 첫 노드이면.
    //        if(removeNode == null)
    //        {
    //            head = head.Next;
    //            removeNode = null;
    //        }
    //        else//첫 노드가 아니면, 해당 노드를 검색하여 삭제.
    //        {
    //            var current = head;

    //            //단방향이므로 삭제할 노드의 바로 이전 노드를 검색해야한다.
    //            while(current != null && current.Next != removeNode)
    //            {
    //                current = current.Next;
    //            }

    //            if(current != null)
    //            {
    //                //이전 노드의 Next에 삭제노드의 Next 할당.
    //                current.Next = removeNode.Next;
    //                removeNode = null;
    //            }
    //        }
    //    }

    //    public SinglyLinkedNode<T> GetNode(int index)
    //    {
    //        var current = head;
    //        for(int i=0;i<index && current != null; i++)
    //        {
    //            current = current.Next;
    //        }

    //        //만약 index가 리스트카운트보다 크면
    //        //null이 리턴됨.
    //        return current;
    //    }

    //    public int Count()
    //    {
    //        int cnt = 0;

    //        var current = head;
    //        while(current != null)
    //        {
    //            cnt++;
    //            current = current.Next;
    //        }

    //        return cnt;
    //    }
    //}
    #endregion
}
