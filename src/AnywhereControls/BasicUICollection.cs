using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Microsoft.StandardUI
{
    public class BasicUICollection<T> : IUICollection<T>, IList
    {
        private const int DefaultCapacity = 4;
        private const int ArrayMaxLength = 0X7FFFFFC7;  // Copied from .NET core source

        internal T[] _items; // Do not rename (binary serialization)
        internal int _size; // Do not rename (binary serialization)
        private int _version; // Do not rename (binary serialization)

        private static readonly T[] s_emptyArray = new T[0];

        // Constructs a List. The list is initially empty and has a capacity
        // of zero. Upon adding the first element to the list the capacity is
        // increased to DefaultCapacity, and then increased in multiples of two
        // as required.
        public BasicUICollection()
        {
            _items = s_emptyArray;
        }

        // Gets and sets the capacity of this list.  The capacity is the size of
        // the internal array used to hold items.  When set, the internal
        // array of the list is reallocated to the given capacity.
        //
        public int Capacity
        {
            get => _items.Length;
            set
            {
                if (value < _size)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "capacity was less than the current size.");
                }

                if (value != _items.Length)
                {
                    if (value > 0)
                    {
                        T[] newItems = new T[value];
                        if (_size > 0)
                        {
                            Array.Copy(_items, newItems, _size);
                        }
                        _items = newItems;
                    }
                    else
                    {
                        _items = s_emptyArray;
                    }
                }
            }
        }

        // Read-only property describing how many elements are in the List.
        public int Count => _size;

        bool IList.IsFixedSize => false;

        // Is this List read-only?
        bool ICollection<T>.IsReadOnly => false;

        bool IList.IsReadOnly => false;

        // Is this List synchronized (thread-safe)?
        bool ICollection.IsSynchronized => false;

        // Synchronization root for this object.
        object ICollection.SyncRoot => this;

        // Sets or Gets the element at the given index.
        public T this[int index]
        {
            get
            {
                // Following trick can reduce the range check by one
                if ((uint)index >= (uint)_size)
                {
                    ThrowArgumentOutOfRange_IndexException();
                }
                return _items[index];
            }

            set
            {
                if ((uint)index >= (uint)_size)
                {
                    ThrowArgumentOutOfRange_IndexException();
                }

                OnItemRemoved(_items[index]);
                _items[index] = value;
                _version++;
                OnItemAdded(value);
            }
        }

        private static bool IsCompatibleObject(object? value)
        {
            // Non-null values are fine.  Only accept nulls if T is a class or Nullable<U>.
            // Note that default(T) is not equal to null for value types except when T is Nullable<U>.
            return (value is T) || (value == null && default(T) == null);
        }

        object? IList.this[int index]
        {
            get => this[index];
            set
            {
                IfNullAndNullsAreIllegalThenThrow(nameof(value), value);

                try
                {
                    this[index] = (T)value!;
                }
                catch (InvalidCastException)
                {
                    ThrowWrongValueTypeArgumentException(nameof(value), value);
                }
            }
        }

        // Allow nulls for reference types and Nullable<U>, but not for value types.
        // Aggressively inline so the jit evaluates the if in place and either drops the call altogether
        // Or just leaves null test and call to the Non-returning ThrowHelper.ThrowArgumentNullException
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void IfNullAndNullsAreIllegalThenThrow(string argName, object? value)
        {
            // Note that default(T) is not equal to null for value types except when T is Nullable<U>.
            if (!(default(T) == null) && value == null)
                throw new ArgumentNullException(argName);
        }

        // Adds the given object to the end of this list. The size of the list is
        // increased by one. If required, the capacity of the list is doubled
        // before adding the new element.
        //
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(T item)
        {
            _version++;
            T[] array = _items;
            int size = _size;
            if ((uint)size < (uint)array.Length)
            {
                _size = size + 1;
                array[size] = item;
                OnItemAdded(item);
            }
            else
            {
                AddWithResize(item);
            }
        }

        public void Set(params T[] newItems)
        {
            if (_items.Length > 0)
            {
                Clear();
                _items = s_emptyArray;
            }

            int newItemsLength = newItems.Length;
            if (newItemsLength == 0)
            {
                return;
            }

            _version++;
            Capacity = newItemsLength;
            _size = newItemsLength;
            Array.Copy(newItems, _items, newItemsLength);

            for (int i = 0; i < newItemsLength; i++)
            {
                OnItemAdded(newItems[i]);
            }
        }

        // Non-inline from List.Add to improve its code quality as uncommon path
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void AddWithResize(T item)
        {
            int size = _size;
            Grow(size + 1);
            _size = size + 1;
            _items[size] = item;
            OnItemAdded(item);
        }

        int IList.Add(object? item)
        {
            IfNullAndNullsAreIllegalThenThrow(nameof(item), item);

            try
            {
                Add((T)item!);
            }
            catch (InvalidCastException)
            {
                ThrowWrongValueTypeArgumentException(nameof(item), item);
            }

            return Count - 1;
        }

        // Clears the contents of List.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear()
        {
            _version++;
            int size = _size;
            _size = 0;
            if (size > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    OnItemRemoved(_items[i]);
                }

                Array.Clear(_items, 0, size); // Clear the elements so that the gc can reclaim the references.
            }
        }

        // Contains returns true if the specified element is in the List.
        // It does a linear, O(n) search.  Equality is determined by calling
        // EqualityComparer<T>.Default.Equals().
        //
        public bool Contains(T item)
        {
            // PERF: IndexOf calls Array.IndexOf, which internally
            // calls EqualityComparer<T>.Default.IndexOf, which
            // is specialized for different types. This
            // boosts performance since instead of making a
            // virtual method call each iteration of the loop,
            // via EqualityComparer<T>.Default.Equals, we
            // only make one virtual call to EqualityComparer.IndexOf.

            return _size != 0 && IndexOf(item) != -1;
        }

        bool IList.Contains(object? item)
        {
            if (IsCompatibleObject(item))
            {
                return Contains((T)item!);
            }
            return false;
        }

        // Copies this List into array, which must be of a
        // compatible array type.
        public void CopyTo(T[] array)
            => CopyTo(array, 0);

        // Copies this List into array, which must be of a
        // compatible array type.
        void ICollection.CopyTo(Array array, int arrayIndex)
        {
            if ((array != null) && (array.Rank != 1))
            {
                throw new ArgumentException("Only single dimensional arrays are supported for the requested action.");
            }

            try
            {
                // Array.Copy will check for NULL.
                Array.Copy(_items, 0, array!, arrayIndex, _size);
            }
            catch (ArrayTypeMismatchException)
            {
                throw new ArgumentException("Target array type is not compatible with the type of items in the collection.");
            }
        }

        // Copies a section of this list to the given array at the given index.
        //
        // The method uses the Array.Copy method to copy the elements.
        //
        public void CopyTo(int index, T[] array, int arrayIndex, int count)
        {
            if (_size - index < count)
            {
                throw new ArgumentException("Offset and length were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection.");
            }

            // Delegate rest of error checking to Array.Copy.
            Array.Copy(_items, index, array, arrayIndex, count);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            // Delegate rest of error checking to Array.Copy.
            Array.Copy(_items, 0, array, arrayIndex, _size);
        }

        // Returns an enumerator for this list with the given
        // permission for removal of elements. If modifications made to the list
        // while an enumeration is in progress, the MoveNext and
        // GetObject methods of the enumerator will throw an exception.
        //
        public Enumerator GetEnumerator() => new Enumerator(this);

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => new Enumerator(this);

        IEnumerator IEnumerable.GetEnumerator() => new Enumerator(this);

        /// <summary>
        /// Increase the capacity of this list to at least the specified <paramref name="capacity"/>.
        /// </summary>
        /// <param name="capacity">The minimum capacity to ensure.</param>
        private void Grow(int capacity)
        {
            int newcapacity = _items.Length == 0 ? DefaultCapacity : 2 * _items.Length;

            // Allow the list to grow to maximum possible capacity (~2G elements) before encountering overflow.
            // Note that this check works even when _items.Length overflowed thanks to the (uint) cast
            if ((uint)newcapacity > ArrayMaxLength) newcapacity = ArrayMaxLength;

            // If the computed capacity is still less than specified, set to the original argument.
            // Capacities exceeding Array.MaxLength will be surfaced as OutOfMemoryException by Array.Resize.
            if (newcapacity < capacity) newcapacity = capacity;

            Capacity = newcapacity;
        }

        // Returns the index of the first occurrence of a given value in a range of
        // this list. The list is searched forwards from beginning to end.
        // The elements of the list are compared to the given value using the
        // Object.Equals method.
        //
        // This method uses the Array.IndexOf method to perform the
        // search.
        //
        public int IndexOf(T item)
            => Array.IndexOf(_items, item, 0, _size);

        int IList.IndexOf(object? item)
        {
            if (IsCompatibleObject(item))
            {
                return IndexOf((T)item!);
            }
            return -1;
        }

        // Inserts an element into this list at a given index. The size of the list
        // is increased by one. If required, the capacity of the list is doubled
        // before inserting the new element.
        //
        public void Insert(int index, T item)
        {
            // Note that insertions at the end are legal.
            if ((uint)index > (uint)_size)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index must be within the bounds of the collection.");
            }
            if (_size == _items.Length) Grow(_size + 1);
            if (index < _size)
            {
                Array.Copy(_items, index, _items, index + 1, _size - index);
            }
            _items[index] = item;
            _size++;
            _version++;
            OnItemAdded(item);
        }

        void IList.Insert(int index, object? item)
        {
            IfNullAndNullsAreIllegalThenThrow(nameof(item), item);

            try
            {
                Insert(index, (T)item!);
            }
            catch (InvalidCastException)
            {
                ThrowWrongValueTypeArgumentException(nameof(item), item);
            }
        }

        protected virtual void OnItemAdded(T item)
        {
        }

        protected virtual void OnItemRemoved(T item)
        {
        }

        // Removes the element at the given index. The size of the list is
        // decreased by one.
        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        void IList.Remove(object? item)
        {
            if (IsCompatibleObject(item))
            {
                Remove((T)item!);
            }
        }

        // Removes the element at the given index. The size of the list is
        // decreased by one.
        public void RemoveAt(int index)
        {
            if ((uint)index >= (uint)_size)
            {
                ThrowArgumentOutOfRange_IndexException();
            }
            OnItemRemoved(_items[index]);
            _size--;
            if (index < _size)
            {
                Array.Copy(_items, index + 1, _items, index, _size - index);
            }
            _items[_size] = default!;
            _version++;
        }

        private static void ThrowArgumentOutOfRange_IndexException()
        {
            throw new ArgumentOutOfRangeException("index", "Index was out of range. Must be non-negative and less than the size of the collection.");
        }

        private static void ThrowWrongValueTypeArgumentException(string argName, object? value)
        {
            throw new ArgumentException($"The value '{value}' is not of type '{typeof(T)}' and cannot be used in this generic collection.", argName);
        }

        public struct Enumerator : IEnumerator<T>, IEnumerator
        {
            private readonly BasicUICollection<T> _list;
            private int _index;
            private readonly int _version;
            private T? _current;

            internal Enumerator(BasicUICollection<T> list)
            {
                _list = list;
                _index = 0;
                _version = list._version;
                _current = default;
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                BasicUICollection<T> localList = _list;

                if (_version == localList._version && ((uint)_index < (uint)localList._size))
                {
                    _current = localList._items[_index];
                    _index++;
                    return true;
                }
                return MoveNextRare();
            }

            private bool MoveNextRare()
            {
                if (_version != _list._version)
                {
                    ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
                }

                _index = _list._size + 1;
                _current = default;
                return false;
            }

            public T Current => _current!;

            object? IEnumerator.Current
            {
                get
                {
                    if (_index == 0 || _index == _list._size + 1)
                    {
                        throw new InvalidOperationException("Enumeration has either not started or has already finished.");
                    }
                    return Current;
                }
            }

            void IEnumerator.Reset()
            {
                if (_version != _list._version)
                {
                    ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
                }

                _index = 0;
                _current = default;
            }

            private static void ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion()
            {
                throw new InvalidOperationException("Collection was modified after the enumerator was instantiated.");
            }
        }
    }
}



#if OLD





        protected readonly List<TItem> _items;


        public BasicUICollection()
        {
            _items = new List<TItem>();
        }

        public int IndexOf(TItem item)
        {
            return _items.IndexOf(item);
        }

        public void Insert(int index, TItem item)
        {
            _items.Insert(index, item);
            OnItemAdded(item);
        }

        public void RemoveAt(int index)
        {
            OnItemRemoved(_items[index]);
            _items.RemoveAt(index);
        }

        public TItem this[int index]
        {
            get => _items[index];
            set
            {
                OnItemRemoved(_items[index]);
                _items[index] = value;
                OnItemAdded(value);
            }
        }

        public void Clear()
        {
            var temp = _items.ToArray();
            foreach (var t in temp)
                OnItemRemoved(t);

            _items.Clear();
        }

        public void Add(TItem item)
        {
            _items.Add(item);
            OnItemAdded(item);
        }

        public bool Contains(TItem item) => _items.Contains(item);

        public void CopyTo(TItem[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);

        public bool Remove(TItem item)
        {
            bool result = _items.Remove(item);
            if (result)
                OnItemRemoved(item);
            return result;
        }

        public bool IsReadOnly => false;

        public int Count => _items.Count;

        public List<TItem>.Enumerator GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        IEnumerator<TItem> IEnumerable<TItem>.GetEnumerator() => GetEnumerator();

        private void OnItemAdded(TItem element)
        {
        }

        private void OnItemRemoved(TItem element)
        {
        }


#if false
#region Nongeneric IList members

        object ICollection.SyncRoot => ((ICollection)_items).SyncRoot;

        bool ICollection.IsSynchronized => ((ICollection)_items).IsSynchronized;

        bool IList.IsFixedSize => false;

        IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();

        void ICollection.CopyTo(Array array, int index) => ((IList)_items).CopyTo(array, index);

        object IList.this[int index]
        {
            get => _items[index];
            set
            {
                if (!(value is TItem item))
                    throw new InvalidOperationException($"Only {typeof(TItem)} subclasses can be added to this collection");

                OnItemRemoved(_items[index]);

                _items[index] = item;

                OnItemAdded(item);
            }
        }

        int IList.Add(object itemObject)
        {
            if (!(itemObject is TItem item))
                throw new InvalidOperationException($"Only {typeof(TItem)} subclasses can be added to this collection");

            int index = ((IList)_items).Add(item);
            OnItemAdded(item);
            return index;
        }

        bool IList.Contains(object itemObject)
        {
            if (!(itemObject is TItem item))
                return false;

            return _items.Contains(item);
        }

        int IList.IndexOf(object itemObject)
        {
            if (!(itemObject is TItem item))
                return -1;
            return _items.IndexOf(item);
        }

        void IList.Insert(int index, object itemObject)
        {
            if (!(itemObject is TItem item))
                throw new InvalidOperationException($"Only {typeof(TItem)} subclasses can be added to this collection");

            _items.Insert(index, item);
            OnItemAdded(item);
        }

        void IList.Remove(object itemObject)
        {
            if (!(itemObject is TItem item))
                return;

            bool result = _items.Remove(item);
            if (result)
                OnItemRemoved(item);
        }

#endregion
#endif
#endif
