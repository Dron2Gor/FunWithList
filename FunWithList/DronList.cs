using System;
using System.Collections;
using System.Collections.Generic;

namespace FunWithList
{
    public class DronList<T> : IEnumerable<T> where T : IEquatable<T>
    {
        private const int _defaultCapacity = 8;
        private const int resizeThreshold = 75;
        private T[] _items;
        private int _size;

        public DronList()
        {
            _items = new T[_defaultCapacity];
            _size = 0;
        }

        public int Count => _size;

        public void Add(T item)
        {
            if (_size == _items.Length - 1)
            {
                ChangeSize(1.75);
            }

            _items[_size] = item;
            _size += 1;
        }


        public void Clear()
        {
            _items = new T[_defaultCapacity];
            _size = 0;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }


        public int IndexOf(T item)
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

        public void Insert(int index, T item)
        {
            if (index < 0 || index > _size)
            {
                throw new ArgumentException("Index is out of range");
            }

            if (_items.Length - 1 == _size)
            {
                ChangeSize(1.75);
            }

            SlideElementsToRight(index);

            _items[index] = item;
            _size += 1;
        }

        public void Remove(T item)
        {
            int index = IndexOf(item);

            if (index < 0)
            {
                return;
            }

            SlideElementsToLeft(index);

            _size -= 1;

            int lengthRatio = (Count / _items.Length) * 100;

            if (lengthRatio >= resizeThreshold)
            {
                ChangeSize(0.75);
            }
        }
        
        private void ChangeSize(double ratio)
        {
            var newItems = new T[(int)(_items.Length*ratio)];
            for (int i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];
            }

            _items = newItems;
        }

        private void SlideElementsToRight(int index)
        {
            for (int i = _size-1; i >= index; i--)
            {
                _items[i + 1] = _items[i];
            }
        }

        private void SlideElementsToLeft(int index)
        {
            for (int i = index; i < _size; i++)
            {
                _items[i] = _items[i+1];
            }
        }
        public T this[int i]
        {
            get
            {
                if (i>=_size)
                {throw new ArgumentException("Index is out of range");}

                return _items[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal class MyEnumerator : IEnumerator<T>
        {
            private readonly DronList<T> _dronList;
            private int _position = -1;


            public MyEnumerator(DronList<T> dronList)
            {
                _dronList = dronList;
            }

            public bool MoveNext()
            {
                if (_position < _dronList.Count-1)
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
                    if (_position == -1 || _position >= _dronList.Count)
                        throw new InvalidOperationException();
                    return _dronList[_position];
                }
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }

        
    }
}