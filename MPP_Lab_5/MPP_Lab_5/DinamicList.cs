using System;
using System.Collections;
using System.Collections.Generic;

namespace MPP_Lab_5
{
    public class DinamicList<T> : IEnumerable<T>
    {
        public int Count { get; private set; }
        public int Capasity { get; private set; }
        private T[] _list;

        public DinamicList()
        {
            _list = new T[0];
            Count = 0;
            Capasity = 0;            
        }

        public DinamicList(IEnumerable<T> newList)
        {
            _list = new T[0];
            Count = 0;
            foreach (var item in newList)
            {
                Add(item);
            }
        }

        public DinamicList(int count)
        {
            _list = new T[count];
            Count = count;
        }

        public void Add(T item)
        {
            TryResize();
            _list[Count - 1] = item;
        }

        private void TryResize()
        {
            Count++;
            if (_list.Length < Count)
            {
                Capasity = _list.Length * 2;
                Array.Resize(ref _list, _list.Length == 0 ? 1 : Capasity);
            }
        }

        public T this[int index]
        {
            get
            {
                if ((index < 0) || (index >= Count))
                {
                    throw new IndexOutOfRangeException(nameof(index));
                }
                return _list[index];
            }
            set
            {
                if ((index < 0) || (index >= Count))
                {
                    throw new IndexOutOfRangeException(nameof(index));
                }
                _list[index] = value;
            }
        }

        public void RemoveAt(int index)
        {
            if ((index < 0) || (index >= Count))
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
            for (var i = index; i < Count - 1; i++)
            {
                _list[i] = _list[i + 1];
            }
            _list[Count - 1] = default;
            Count--;
        }

        public void Remove(T x) => RemoveAt(IndexOf(x));

        private int IndexOf(T x)
        {
            int i = 0;            
            while ((_list[i] == null) || (i < Count) && (!_list[i].Equals(x)))
            {
                i++;
            }
            return i;            
        }

        public void Clear()
        {
            Array.Resize(ref _list, 0);
            Count = 0;
            Capasity = 0;
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            int i = 0;
            while (i < Count)
            {
                yield return _list[i++];                
            }
        }
    }
}
