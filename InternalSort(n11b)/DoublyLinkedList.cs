using System;
using System.Collections;
using System.Collections.Generic;

namespace InternalSort_n11b_
{
    public class DoublyLinkedList : IEnumerable  // двусвязный список
    {
        DoublyNode _head; // головной/первый элемент
        DoublyNode _tail; // хвостовой элемент
        int _count;  // количество элементов в списке

        public DoublyLinkedList()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public int Count { get { return _count; } }
        public bool IsEmpty { get { return _count == 0; } }

        /// <summary>
        /// Упорядоченное добавление элемента слева
        /// </summary>
        /// <param name="data">Элемент</param>
        /// <param name="actions">Очередь действий, происходящих с числами</param>
        /// <param name="insertIndex">Индекс вставляемого элемента</param>
        public void OrderAddFromLeft(int data, Queue<ActionHandle> actions, int insertIndex)
        {
            // если список пуст
            DoublyNode node = new DoublyNode(data);
            DoublyNode current = _head;
            
            int currentIndex = 0;
            if (_head == null)
            {
                actions.Enqueue(new ActionHandle(insertIndex, insertIndex, Act.InsertBefore));
                _head = node;
                _tail = node;
            }
            // если узел должен быть вставлен в начале двусвязного списка
            else if (_head.Data >= data)
            {
                actions.Enqueue(new ActionHandle(insertIndex, currentIndex, Act.Compare));
                actions.Enqueue(new ActionHandle(insertIndex, insertIndex, Act.InsertBefore));
                node.Next = _head;
                node.Next.Previous = node;
                _head = node;
            }
            else
            {
                actions.Enqueue(new ActionHandle(insertIndex, currentIndex, Act.Compare));
                // найти узел, после которого новый узел
                // должен быть вставлен
                while (current.Next != null && current.Next.Data < node.Data)
                {
                    currentIndex++;
                    actions.Enqueue(new ActionHandle(insertIndex, currentIndex, Act.Compare));
                    current = current.Next;
                }
                actions.Enqueue(new ActionHandle(insertIndex, currentIndex+1, Act.Compare));

                node.Next = current.Next;
                // если новый узел не вставлен
                // в конце списка
                if (current.Next != null)
                {
                    current.Next.Previous = node;
                    actions.Enqueue(new ActionHandle(currentIndex, currentIndex+1, Act.InsertBetween));
                }
                else
                {
                    _tail = node;
                    actions.Enqueue(new ActionHandle(insertIndex, insertIndex, Act.InsertAfter));
                }

                current.Next = node;
                node.Previous = current;
            }
            _count++;
        }

        /// <summary>
        /// Упорядоченное добавление элемента права
        /// </summary>
        /// <param name="data">Элемент</param>
        /// <param name="actions">Очередь действий, происходящих с числами</param>
        /// <param name="insertIndex">Индекс вставляемого элемента</param>
        public void OrderAddFromRight(int data, Queue<ActionHandle> actions, int insertIndex)
        {
            // если список пуст
            DoublyNode node = new DoublyNode(data);
            DoublyNode current = _tail;

            int currentIndex = Count-1;
            if (_tail == null)
            {
                actions.Enqueue(new ActionHandle(insertIndex, insertIndex, Act.InsertAfter));
                _head = node;
                _tail = node;
            }
            // если узел должен быть вставлен в конец
            // из двусвязного списка
            else if (_tail.Data <= data)
            {
                actions.Enqueue(new ActionHandle(insertIndex, currentIndex, Act.Compare));
                actions.Enqueue(new ActionHandle(insertIndex, insertIndex, Act.InsertAfter));
                node.Previous = _tail;
                node.Previous.Next = node;
                _tail = node;
            }
            else
            {
                actions.Enqueue(new ActionHandle(insertIndex, currentIndex, Act.Compare));
                // найти узел, после которого новый узел
                // должен быть вставлен
                while (current.Previous != null && current.Previous.Data > node.Data)
                {
                    currentIndex--;
                    actions.Enqueue(new ActionHandle(insertIndex, currentIndex, Act.Compare));
                    current = current.Previous;
                }
                actions.Enqueue(new ActionHandle(insertIndex, currentIndex - 1, Act.Compare));

                node.Previous = current.Previous;
                // если новый узел не вставлен
                // в начале списка
                if (current.Previous != null)
                {
                    current.Previous.Next = node;
                    actions.Enqueue(new ActionHandle(currentIndex, currentIndex + 1, Act.InsertBetween));
                }
                else
                {
                    _head = node;
                    actions.Enqueue(new ActionHandle(insertIndex, insertIndex, Act.InsertBefore));
                }

                current.Previous = node;
                node.Next = current;
            }
            _count++;
        }

        /// <summary>
        /// Печать списка на экран
        /// </summary>
        public void Print()
        {
            DoublyNode curr = _head;
            while (curr != null)
            {
                Console.WriteLine(curr.Data);
                curr = curr.Next;
            }
        }

        /// <summary>
        /// Удаление элемента
        /// </summary>
        /// <param name="data">Удаляемый элемент</param>
        /// <returns>Удален ли элемент</returns>
        public bool Remove(int data)
        {
            DoublyNode current = _head;

            // поиск удаляемого узла
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }
            if (current != null)
            {
                // если узел не последний
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                    _tail = current;
                

                // если узел не первый
                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    // если первый, переустанавливаем head
                    _head = current.Next;
                }
                _count--;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Преобразование списка в массив
        /// </summary>
        /// <returns></returns>
        public int[] ToArray()
        {
            int[] result = new int[_count];
            DoublyNode tmp = _head;
        
            for (int i = 0; i < _count && tmp != null; i++, tmp = tmp.Next)
            {
                result[i] = tmp.Data;
            }

            return result;
        }

       

        /// <summary>
        /// Очистка списка
        /// </summary>
        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        /// <summary>
        /// Проверка на содержание элемента
        /// </summary>
        /// <param name="data">Искомый элемент</param>
        /// <returns>Найден ли элемент в списке</returns>
        public bool Contains(int data)
        {
            DoublyNode current = _head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public IEnumerator GetEnumerator()
        {
            DoublyNode tmp = _head;
            while (tmp != null)
            {
                yield return tmp.Data;
                tmp = tmp.Next;
            }
        }
    }
}
