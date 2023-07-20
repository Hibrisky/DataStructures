using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class DoubleLinkedList
    {
        //이중 연결 리스트는 단방향으로 연결된 단일 연결 리스트의 탐색 기능을 개선한 것으로
        //리스트 안에 노드가 이전 노드와 다음 노드를 가리키는 포인터를 모두 가지고있어서 양방향으로 탐색이 가능한 자료구조이다.
        
        //이중 연결 리스트 노드
        public class DoublyLinkedListNode<T>
        {
            public T Data { get; set; }
            public DoublyLinkedListNode<T> Prev { get; set; }
            public DoublyLinkedListNode<T> Next { get; set; }

            public DoublyLinkedListNode(T data) : this(data, null, null)
            {
            }

            public DoublyLinkedListNode(T data, DoublyLinkedListNode<T> prev, DoublyLinkedListNode<T> next)
            {
                this.Data = data;
                this.Prev = prev;
                this.Next = next;
            }

            public static bool isCircular(DoublyLinkedListNode<T> head)
            {
                //빈 리스트는 원형 리스트임.
                if (head == null)
                    return true;

                var current = head;
                while (current != null)
                {
                    current = current.Next;
                    if (current == head)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        //이중 연결 리스트
        public class DoublylinkedList<T>
        {
            private DoublyLinkedListNode<T> head;

            // 리스트가 비어있으면, Head에 새 노드를 할당하고, 비어있지 않으면 마지막 노들르 찾아 이동한 후 마지막 노드 다음에 새 노드 추가.
            public void Add(DoublyLinkedListNode<T> newNode) 
            {
                if (head == null)//리스트가 비어있으면(선언 후 처음 Add할때)
                {
                    head = newNode;
                }
                else//비어 있지 않으면, 마지막으로 이동하여 추가.
                {
                    var current = head;
                    while (current != null && current.Next != null)
                    {
                        current = current.Next;
                    }

                    //추가할 때 양방향 연결
                    current.Next = newNode;
                    newNode.Prev = current;
                    newNode.Next = null;
                }
            }

            //현재 노드를A, 새로 추가하는 노드를 B, 현재 노드의 다음노드를 C라고  가정했을때. A의Next 레퍼런스를 B에 연결하고 C의 Prev 레퍼런스를 B에 연결하고, B의 Prev를A에,
            //B의Next를 C에 연결한다. 이렇게 각 노드의 이전 노드와 다음 노드 레퍼런스만 수정해 주기 때문에 이 메서드느느 O(1)의 처리 시간을 갖는다.
            public void AddAfter(DoublyLinkedListNode<T> current, DoublyLinkedListNode<T> newNode) 
            {
                if (head == null || current == null || newNode == null)
                {
                    throw new InvalidOperationException();
                }


                newNode.Next = current.Next;
                current.Next.Prev = newNode;
                newNode.Prev = current;
                current.Next = newNode;
            }

            //삭제할 노드가 첫 노드이면, Head의 다음노드 즉 두번재 노드를 Head에 할당하고, 첫 노드가 아니면 삭제할 노드의 이전 노드와 다음 노드를 서로 연결한다.
            //단일 연결 리스트와 달리 이중연결 리스트는 이전 노드를 가지고있으므로, 삭제시 이전 노드를 검색할 필요가 없이즉시 이전노드와 다음노드를 연결할 수 있다.
            //이 메서드는 O(1)의 처리시간을 갖는다.

            public void Remove(DoublyLinkedListNode<T> removeNode)
            {
                if (head == null || removeNode == null)
                    return;

                //삭제가 첫 노드이면.
                if(removeNode == head)
                {
                    head = head.Next;
                    if(head != null)
                    {
                        head.Prev = null;
                    }
                }
                //첫 노드가 아니면, Prev노드와 Next노드를 연결.
                else
                {
                    removeNode.Prev.Next = removeNode.Next;
                    if (removeNode.Next != null)
                    {
                        removeNode.Next.Prev = removeNode.Prev;
                    }
                }

                removeNode = null;
            }

            //이중 연결 리스트에서 특정 위치 인덱스에 있는 노드를 리턴한다. 만약 인덱스가 리스트밖에있으면, null을 리턴한다.
            //이중 연결 리스트는 해당 인덱스 만큼 계속 이동해서 노드를 찾아야 하므로 O(n)의 검색 시간을 갖는다.
            public DoublyLinkedListNode<T> GetNode(int index)
            {
                var current = head;
                for(int i=0;i<index && current != null; i++)
                {
                    current = current.Next;
                }
                //만약 Index가 리스트 카운트 보다 크면 null 리턴.
                return current;
            }

            //Head부터 마지막 노드까지 이동하면서 카운트를 증가시킨다. 역시 O(n)의 처리 시간을 갖는다.
            public int Count()
            {
                int cnt = 0;

                var current = head;
                while(current != null)
                {
                    cnt++;
                    current = current.Next;
                }

                return cnt;
            }

            //public static bool isCircular(DoublyLinkedListNode<T> head)
            //{
            //    //빈 리스트는 원형 리스트임.
            //    if (head == null)
            //        return true;

            //    var current = head;
            //    while (current != null)
            //    {
            //        current = current.Next;
            //        if (current != null)
            //        {
            //            return true;
            //        }
            //    }

            //    return false;
            //}

        }

    }
}
