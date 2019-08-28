using System;
using System.Collections;
using System.Collections.Generic;

namespace FunWithList
{
    public class DronStack<T> : IEnumerable<T> where T : IEquatable<T>
    {
        private const int _defaultCapacity = 8;
        private const int resizeThreshold = 66;
        private T[] _items;
        private int _size;

        public DronStack()
        {
            _items = new T[_defaultCapacity];
            _size = 0;
        }

        public int Count => _size;

        public void Push(T item)
        {
            if (_size == _items.Length - 1)
            {
                ChangeSize(1.66);
            }

            _items[_size] = item;
            _size += 1;
        }
        public T Peek()
        {
            if (_size < 0)
            {
                throw new ArithmeticException("Index is out of range");
            }
            return _items[_size - 1];
        }

        public T Pop()
        {
            if (_size < 0)
            {
                throw new ArithmeticException("Index is out of range");
            }

            var firstItem = _items[_size - 1];
            _items[_size - 1] = default(T);
            _size -= 1;
            int lengthRatio = (Count / _items.Length) * 100;

            if (lengthRatio >= resizeThreshold)
            {
                ChangeSize(0.66);
            }

            return firstItem;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }


        private int IndexOf(T item)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_items[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }
       

        public void Clear()
        {
            _items = new T[_defaultCapacity];
            _size = 0;
        }

        private void ChangeSize(double ratio)
        {
            var newItems = new T[(int) (_items.Length * ratio)];
            for (int i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];
            }

            _items = newItems;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class MyEnumerator : IEnumerator<T>
        {
            private readonly DronStack<T> _stack;
            private int _position = -1;


            public MyEnumerator(DronStack<T> stack)
            {
                _stack = stack;
            }

            public bool MoveNext()
            {
                if (_position < _stack.Count - 1)
                {
                    _position++;
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                _position = -1;
            }

            public T Current
            {
                get
                {
                    if (_position == -1 || _position >= _stack.Count)
                        throw new InvalidOperationException();
                    return _stack._items[_position];
                }
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }
    }
}