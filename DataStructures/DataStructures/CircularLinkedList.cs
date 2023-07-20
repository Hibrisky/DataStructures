using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class CircularLinkedList<T>
    {
        private DoubleLinkedList.DoublyLinkedListNode<T> head;

        //Add(newNode) : 리스트가 비어있으면 Head에 새 노드를 할당하고, 비어있지 않으면 첫 노드의 이전노드인 마지막 노드를 찾고
        // 첫 노드와 마지막 노드사이에 새 노드를 추가한다.
        /*
         * 원형 이중연결 리스트는 일반 이중연결 리스트와 달리 마지막 노드를 찾기위해 모든 노드를 순차적으로 이동할 필요가 없다.
         * 왜냐하면, 첫 노드의 이전 노드가 항상 마지막 노드를 가리키고있기 때문에 바로 마지막 노드를 알아 낼 수 있기 때문이다.
         */
        public void Add(DoubleLinkedList.DoublyLinkedListNode<T> newNode)
        {
            if (head == null)//리스트가 비어있으면.
            {
                head = newNode;
                head.Next = head;
                head.Prev = head;
            }
            else //비어있지 않으면 헤드와 테일 사이에 삽입.
            {
                var tail = head.Prev;

                head.Prev = newNode;
                tail.Next = newNode;
                newNode.Prev = tail;
                newNode.Next = head;
            }
        }

        /*
         * AddAfter(currNode,newNode) : 이는 이중 연결 리스트와 도일한 메서드이다.
         * 단, 이중 연결 리스트는 마지막 노드 다음이 null이어서 current.Next.Prev 문장에 대해 current.Next가 null인지 먼저 체크해야 하지만,
         * 원형 이중 연결 리스트는 마지막 노드 다음이 헤드이므로 별도로 null을 체크할 필요가 없다.
         */

        public void AddAfter(DoubleLinkedList.DoublyLinkedListNode<T> current, DoubleLinkedList.DoublyLinkedListNode<T> newNode)
        {
            if (head == null || current == null || newNode == null)
                throw new InvalidOperationException();

            newNode.Next = current.Next;
            current.Next.Prev = newNode;
            newNode.Prev = current;
            current.Next = newNode;
        }
        /*
         * Remove(removeNoe) : 삭제할 노드가 첫 노드이고 전체 노드의 수가 하나이면, 헤드를 null로 설정한다.
         * 이 경우가 아니면, 삭제할 노드의 이전 노드와 다음 노드를 서로 연결하는 작업을 진행하고, 삭제할 노드를 null로 설정한다.
         */
        public void Remove(DoubleLinkedList.DoublyLinkedListNode<T> removeNode)
        {
            if (head == null || removeNode == null)
            {
                return;
            }

            //삭제할 노드가 헤드 노드이고 노드가 1개이면.
            if (removeNode == head && head == head.Next)
            {
                head = null;
            }
            else //아니면 prev 노드와 next노드를 연결
            {
                removeNode.Prev.Next = removeNode.Next;
                removeNode.Next.Prev = removeNode.Prev;
            }

            removeNode = null;
        }

        /*GetNode(index) : 이중 연결 리스트에서 특정 위치 인덱스에 있는 노드를 리턴한다. 
         * 리스트가 원형이므로 루프를 돌며 이동할 때 다시 순환해서 헤드로 돌아오면 찾는 노드가 없는 것이므로 null을 리턴한다.*/
        public DoubleLinkedList.DoublyLinkedListNode<T> GetNode(int index)
        {
            if (head == null) return null;

            int cnt = 0;
            var current = head;
            while (cnt < index)
            {
                current = current.Next;
                cnt++;
                if (current == head)
                {
                    return null;
                }
            }

            return current;
        }

        /*
         * Head부터 마지막 노드까지 이동하면서 카운트를 증가시킨다.
         * 마지막 노드의 다음 노드로 이동하면 Head를 만나게 되므로 이러한 조건일때 루프를 중지하면 된다.
         */
        public int Count()
        {
            if (head == null) return 0;

            int cnt = 0;
            var current = head;
            do
            {
                cnt++;
                current = current.Next;
            }
            while (current != head);

            return cnt;
        }

       
    }
}
