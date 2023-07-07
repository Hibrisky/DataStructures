using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class SingleLinkedList
    {
        //단일 연결리스트에 노드
        public class SinglyLinkedNode<T>
        {
            public T Data { get; set; }
            public SinglyLinkedNode<T> Next { get; set; }

            public SinglyLinkedNode(T data)
            {
                this.Data = data;
                this.Next = null;
            }
        }

        //단일 링크드리스트
        public class SinglyLinkedList<T>
        {
            private SinglyLinkedNode<T> head;

            //리스트가 비어있으면 Head에 새 노드를 할당하고, 비어있지않으면 마지막 노드를 찾아 이동한 후 마지막 노드 다음에 새 노드를 추가한다.
            // 만약 위 singlyLinkedList 클래스에서 Head와 함께 Tail필드를 추가하고 마지막 노드를 Tail필드에 저장한다면,
            // add 메서드에서 새 노드를 추가할때 tail이 가리키는 마지막 노드 다음에 직접 새 노드를 추가 할 수 있다.
            public void Add(SinglyLinkedNode<T> newNode)
            {
                //List is Empty
                if (head == null)
                    head = newNode;
                else
                {
                    var current = head;
                    //마지막 노드로 이동하여 추가.
                    while (current != null && current.Next != null)
                    {
                        current = current.Next;
                    }
                    current.Next = newNode;
                }
            }

            //새 노드의 Next에 현재 노드의 Next를 먼저 할당하고, 현재 노드의 Next에 새 노드를 할당한다.
            public void AddAfter(SinglyLinkedNode<T> current, SinglyLinkedNode<T> newNode)
            {
                if (head == null || current == null || newNode == null)
                {
                    throw new InvalidOperationException();
                }

                newNode.Next = current.Next;
                current.Next = newNode;
            }

            //삭제할 노드가 첫 노드이면, Head의 다음 노드 즉 두번째 노드를 Head에 할당하고, 첫 노드가 아니면 해당 노드를 검색하여 삭제한다.
            //해당 노드를 검색할 때, 단일 연결 리스트는 단방향으로 연결되어있으므로 삭제할 노드의 바로 이전 노드를 찾아서 삭제노드를 지워야한다.
            //즉, 이전 노드의 Next에 삭제노드의 Next를 할당해야 지울 수 있다.
            //여기서 Remove() 메서드의 한 변형으로 RemoveAfter(previousNode)와 같은 메서드를 작성한다면 이미 삭제한 노드의 이전 노드를 이미 알고있으므로 삭제는 포인터만 변경해주면 될것이다.

            public void Remove(SinglyLinkedNode<T> removeNode)
            {
                if (head == null || removeNode == null)
                    return;

                //삭제할 노드가 첫 노드이면.
                if (removeNode == null)
                {
                    head = head.Next;
                    removeNode = null;
                }
                else//첫 노드가 아니면, 해당 노드를 검색하여 삭제.
                {
                    var current = head;

                    //단방향이므로 삭제할 노드의 바로 이전 노드를 검색해야한다.
                    while (current != null && current.Next != removeNode)
                    {
                        current = current.Next;
                    }

                    if (current != null)
                    {
                        //이전 노드의 Next에 삭제노드의 Next 할당.
                        current.Next = removeNode.Next;
                        removeNode = null;
                    }
                }
            }

            //단일 연결 리스트에서 특정 위치 인덱스에 있는 노드를 리턴한다. 만약 인덱스가 연결 리스트 범위를 벗어나면 null을 리턴한다.
            //배열은 인덱스를 통해 즉시 배열 요소를 찾을 수 있지만(즉 o(1) 의 검색 성능), 링크드 리스트는 해당 인덱스만큼 계속 이동해서 노드를 찾아야 하므로 o(n)의 검색 시간을 갖는다.
            public SinglyLinkedNode<T> GetNode(int index)
            {
                var current = head;
                for (int i = 0; i < index && current != null; i++)
                {
                    current = current.Next;
                }

                //만약 index가 리스트카운트보다 크면
                //null이 리턴됨.
                return current;
            }

            //Head부터 마지막 노드까지 이동하면서 카운트를 증가시킨다.
            public int Count()
            {
                int cnt = 0;

                var current = head;
                while (current != null)
                {
                    cnt++;
                    current = current.Next;
                }

                return cnt;
            }
        }
    }
}
