using System;
using System.Collections;
using System.Collections.Generic;

namespace FunWithList
{
    public class DronQueue<T> : IEnumerable<T> where T : IEquatable<T>
    {
        private const string QueueIsEmpty = "Queue is empty";
        private Node _headElement;
        private Node _tailElement;
        private int _size;

        public void Enqueue(T item)
        {
            Node node = new Node(item);
            Node preLastNode = _tailElement;
            _tailElement = node;
            if (_size == 0)
                _headElement = _tailElement;
            else
                preLastNode.Next = _tailElement;
            _size++;
        }

        public T Dequeue()
        {
            if (_size == 0)
                throw new InvalidOperationException(QueueIsEmpty);
            T item = _headElement.Item;
            _headElement = _headElement.Next;
            _size--;
            return item;
        }

        public T First
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException(QueueIsEmpty);
                return _headElement.Item;
            }
        }

        public T Last
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException(QueueIsEmpty);
                return _tailElement.Item;
            }
        }

        public int Count => _size;
        public bool IsEmpty => _size == 0;

        public void Clear()
        {
            _headElement = null;
            _tailElement = null;
            _size = 0;
        }

        public bool Contains(T item)
        {
            Node current = _headElement;
            while (current != null)
            {
                if (current.Item.Equals(item))
                    return true;
                current = current.Next;
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node current = _headElement;
            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        private class Node
        {
            public Node(T item)
            {
                Item = item;
            }

            public T Item { get; set; }
            public Node Next { get; set; }
        }
    }
}