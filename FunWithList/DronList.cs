using System;
using System.Collections;
using System.Collections.Generic;

namespace FunWithList
{
    public class DronList<T> : IEnumerable<T> where T : IEquatable<T>
    {
        private const int _defaultCapacity = 10;
        private const int resizeThreshold = 75;
        private T[] _items;
        private int _lastItemIndex;

        public DronList()
        {
            _items = new T[_defaultCapacity];
            _lastItemIndex = 0;
        }

        public int Count => _lastItemIndex;

        public void Add(T item)
        {
            if (_items.Length - 1 == _lastItemIndex)
            {
                IncreaseSize();
            }

            _items[_lastItemIndex] = item;
            _lastItemIndex += 1;
        }


        public void Clear()
        {
            _items = new T[_defaultCapacity];
            _lastItemIndex = 0;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }


        public int IndexOf(T item)
        {
            for (int i = 0; i < _lastItemIndex; i++)
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
            if (index < 0 || index > _lastItemIndex)
            {
                throw new ArgumentException("Index is out of range");
            }

            if (_items.Length - 1 == _lastItemIndex)
            {
                IncreaseSize();
            }

            SlideElementToRight(index);

            _items[index] = item;
            _lastItemIndex += 1;
        }

        public void Remove(T item)
        {
            int index = IndexOf(item);

            if (index < 0)
            {
                return;
            }

            SlideElementToLeft(index);

            _items[_lastItemIndex] = default(T);
            _lastItemIndex -= 1;

            int lengthRatio = (Count / _items.Length) * 100;

            if (lengthRatio >= resizeThreshold)
            {
                DecreaseSize();
            }
        }

        private void IncreaseSize()
        {
            ChangeSize(_items.Length + _items.Length * 75 / 100);
        }

        private void DecreaseSize()
        {
            ChangeSize(_lastItemIndex + _items.Length * 75 / 100);
        }

        private void ChangeSize(int newLength)
        {
            var newItems = new T[newLength];
            for (int i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];
            }

            _items = newItems;
        }

        private void SlideElementToRight(int index)
        {
            for (int i = _lastItemIndex; i >= index; i--)
            {
                _items[i + 1] = _items[i];
            }
        }

        private void SlideElementToLeft(int index)
        {
            for (int i = _lastItemIndex; i >= index; i--)
            {
                _items[i + 1] = _items[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}