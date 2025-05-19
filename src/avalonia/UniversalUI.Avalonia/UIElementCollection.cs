using System.Collections;
using AnywhereUI;
using Avalonia.Collections;
using Avalonia.Controls;

namespace AnywhereControlsAvalonia
{
    /// <summary>
    /// A UIElementCollection is a ordered collection of UIElements. This code was copied/adapted
    /// from the Avalonia source a
    /// https://github.com/AvaloniaUI/Avalonia/blob/1cb271fb372eda132bdcc76d1bd16d6256e12b16/src/Avalonia.Controls/Controls.cs#L10
    /// https://github.com/AvaloniaUI/Avalonia/blob/1cb271fb372eda132bdcc76d1bd16d6256e12b16/src/Avalonia.Base/Collections/AvaloniaList.cs#L53
    /// </summary>
    public sealed class UIElementCollection<TNativeUIElement, TAnywhereControlsUIElement>
        : IList, IList<TNativeUIElement>
        where TNativeUIElement : Control where TAnywhereControlsUIElement : IUIElement
    {
        private readonly List<TNativeUIElement> _inner;
        private IUICollection<TAnywhereControlsUIElement>? _standardUIElementCollection;

        // TODO: Make use of parent or remove. Also support notifications as needed.
        public UIElementCollection(Control parent)
        {
            _inner = new List<TNativeUIElement>();
        }

        public IUICollection<TAnywhereControlsUIElement> ToAnywhereControlsUIElementCollection()
        {
            if (_standardUIElementCollection == null)
            {
                _standardUIElementCollection = new AnywhereControlsUIElementCollection(this);
            }

            return _standardUIElementCollection;
        }

        /// <summary>
        /// Gets the number of items in the collection.
        /// </summary>
        public int Count => _inner.Count;

        /// <inheritdoc/>
        bool IList.IsFixedSize => false;

        /// <inheritdoc/>
        bool IList.IsReadOnly => false;

        /// <inheritdoc/>
        int ICollection.Count => _inner.Count;

        /// <inheritdoc/>
        bool ICollection.IsSynchronized => false;

        /// <inheritdoc/>
        object ICollection.SyncRoot => this;

        /// <inheritdoc/>
        bool ICollection<TNativeUIElement>.IsReadOnly => false;

        /// <summary>
        /// Gets or sets the item at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The item.</returns>
        public TNativeUIElement this[int index]
        {
            get
            {
                return _inner[index];
            }

            set
            {
                TNativeUIElement old = _inner[index];

                if (!EqualityComparer<TNativeUIElement>.Default.Equals(old, value))
                {
                    _inner[index] = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the item at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The item.</returns>
        object? IList.this[int index]
        {
            get { return this[index]; }
            set { this[index] = (TNativeUIElement)value!; }
        }

        /// <summary>
        /// Gets or sets the total number of elements the internal data structure can hold without resizing.
        /// </summary>
        public int Capacity
        {
            get => _inner.Capacity;
            set => _inner.Capacity = value;
        }

        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Add(TNativeUIElement item)
        {
            int index = _inner.Count;
            _inner.Add(item);
        }

        /// <summary>
        /// Adds multiple items to the collection.
        /// </summary>
        /// <param name="items">The items.</param>
        public void AddRange(IEnumerable<TNativeUIElement> items) => InsertRange(_inner.Count, items);

        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        public void Clear()
        {
            if (Count > 0)
            {
                _inner.Clear();
            }
        }

        /// <summary>
        /// Tests if the collection contains the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>True if the collection contains the item; otherwise false.</returns>
        public bool Contains(TNativeUIElement item)
        {
            return _inner.Contains(item);
        }

        /// <summary>
        /// Copies the collection's contents to an array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="arrayIndex">The first index of the array to copy to.</param>
        public void CopyTo(TNativeUIElement[] array, int arrayIndex)
        {
            _inner.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Returns an enumerator that enumerates the items in the collection.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}"/>.</returns>
        IEnumerator<TNativeUIElement> IEnumerable<TNativeUIElement>.GetEnumerator()
        {
            return new Enumerator(_inner);
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(_inner);
        }

        public Enumerator GetEnumerator()
        {
            return new Enumerator(_inner);
        }

        /// <summary>
        /// Gets a range of items from the collection.
        /// </summary>
        /// <param name="index">The zero-based <see cref="AvaloniaList{T}"/> index at which the range starts.</param>
        /// <param name="count">The number of elements in the range.</param>
        public IEnumerable<TNativeUIElement> GetRange(int index, int count)
        {
            return _inner.GetRange(index, count);
        }

        /// <summary>
        /// Gets the index of the specified item in the collection.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        /// The index of the item or -1 if the item is not contained in the collection.
        /// </returns>
        public int IndexOf(TNativeUIElement item)
        {
            return _inner.IndexOf(item);
        }

        /// <summary>
        /// Inserts an item at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
        public void Insert(int index, TNativeUIElement item)
        {
            _inner.Insert(index, item);
        }

        /// <summary>
        /// Inserts multiple items at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="items">The items.</param>
        public void InsertRange(int index, IEnumerable<TNativeUIElement> items)
        {
            _ = items ?? throw new ArgumentNullException(nameof(items));

            if (items is IList list)
            {
                if (list.Count > 0)
                {
                    if (list is ICollection<TNativeUIElement> collection)
                    {
                        _inner.InsertRange(index, collection);
                    }
                    else
                    {
                        EnsureCapacity(_inner.Count + list.Count);

                        using (IEnumerator<TNativeUIElement> en = items.GetEnumerator())
                        {
                            int insertIndex = index;

                            while (en.MoveNext())
                            {
                                TNativeUIElement item = en.Current;

                                _inner.Insert(insertIndex++, item);
                            }
                        }
                    }
                }
            }
            else
            {
                using (IEnumerator<TNativeUIElement> en = items.GetEnumerator())
                {
                    if (en.MoveNext())
                    {
                        int insertIndex = index;

                        do
                        {
                            TNativeUIElement item = en.Current;

                            _inner.Insert(insertIndex++, item);

                        } while (en.MoveNext());
                    }
                }
            }
        }

        /// <summary>
        /// Ensures that the capacity of the list is at least <see cref="Capacity"/>.
        /// </summary>
        /// <param name="capacity">The capacity.</param>
        public void EnsureCapacity(int capacity)
        {
            // Adapted from List<T> implementation.
            var currentCapacity = _inner.Capacity;

            if (currentCapacity < capacity)
            {
                var newCapacity = currentCapacity == 0 ? 4 : currentCapacity * 2;

                if (newCapacity < capacity)
                {
                    newCapacity = capacity;
                }

                _inner.Capacity = newCapacity;
            }
        }

        /// <summary>
        /// Removes an item from the collection.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>True if the item was found and removed, otherwise false.</returns>
        public bool Remove(TNativeUIElement item)
        {
            int index = _inner.IndexOf(item);

            if (index != -1)
            {
                _inner.RemoveAt(index);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Removes the item at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        public void RemoveAt(int index)
        {
            TNativeUIElement item = _inner[index];
            _inner.RemoveAt(index);
        }

        /// <inheritdoc/>
        int IList.Add(object? value)
        {
            int index = Count;
            Add((TNativeUIElement)value!);
            return index;
        }

        /// <inheritdoc/>
        bool IList.Contains(object? value)
        {
            return Contains((TNativeUIElement)value!);
        }

        /// <inheritdoc/>
        void IList.Clear()
        {
            Clear();
        }

        /// <inheritdoc/>
        int IList.IndexOf(object? value)
        {
            return IndexOf((TNativeUIElement)value!);
        }

        /// <inheritdoc/>
        void IList.Insert(int index, object? value)
        {
            Insert(index, (TNativeUIElement)value!);
        }

        /// <inheritdoc/>
        void IList.Remove(object? value)
        {
            Remove((TNativeUIElement)value!);
        }

        /// <inheritdoc/>
        void IList.RemoveAt(int index)
        {
            RemoveAt(index);
        }

        /// <inheritdoc/>
        void ICollection.CopyTo(Array array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Rank != 1)
            {
                throw new ArgumentException("Multi-dimensional arrays are not supported.");
            }

            if (array.GetLowerBound(0) != 0)
            {
                throw new ArgumentException("Non-zero lower bounds are not supported.");
            }

            if (index < 0)
            {
                throw new ArgumentException("Invalid index.");
            }

            if (array.Length - index < Count)
            {
                throw new ArgumentException("The target array is too small.");
            }

            if (array is TNativeUIElement[] tArray)
            {
                _inner.CopyTo(tArray, index);
            }
            else
            {
                //
                // Catch the obvious case assignment will fail.
                // We can't find all possible problems by doing the check though.
                // For example, if the element type of the Array is derived from T,
                // we can't figure out if we can successfully copy the element beforehand.
                //
                Type targetType = array.GetType().GetElementType()!;
                Type sourceType = typeof(TNativeUIElement);
                if (!(targetType.IsAssignableFrom(sourceType) || sourceType.IsAssignableFrom(targetType)))
                {
                    throw new ArgumentException("Invalid array type");
                }

                //
                // We can't cast array of value type to object[], so we don't support
                // widening of primitive types here.
                //
                if (array is not object?[] objects)
                {
                    throw new ArgumentException("Invalid array type");
                }

                int count = _inner.Count;
                try
                {
                    for (int i = 0; i < count; i++)
                    {
                        objects[index++] = _inner[i];
                    }
                }
                catch (ArrayTypeMismatchException)
                {
                    throw new ArgumentException("Invalid array type");
                }
            }
        }

        /// <summary>
        /// Enumerates the elements of a <see cref="AvaloniaList{T}"/>.
        /// </summary>
        public struct Enumerator : IEnumerator<TNativeUIElement>
        {
            private List<TNativeUIElement>.Enumerator _innerEnumerator;

            public Enumerator(List<TNativeUIElement> inner)
            {
                _innerEnumerator = inner.GetEnumerator();
            }

            public bool MoveNext()
            {
                return _innerEnumerator.MoveNext();
            }

            void IEnumerator.Reset()
            {
                ((IEnumerator)_innerEnumerator).Reset();
            }

            public TNativeUIElement Current => _innerEnumerator.Current;

            object? IEnumerator.Current => Current;

            public void Dispose()
            {
                _innerEnumerator.Dispose();
            }
        }


        /// <summary>
        /// This class provides a Standard UI wrapper for the collection, implementing IUICollection<TStandardUIElement>,
        /// allowing accessing the collection using Standard UI interfaces.
        /// </summary>
        public class AnywhereControlsUIElementCollection : IUICollection<TAnywhereControlsUIElement>
        {
            private readonly UIElementCollection<TNativeUIElement, TAnywhereControlsUIElement> _nativeUIElementCollection;

            public AnywhereControlsUIElementCollection(UIElementCollection<TNativeUIElement, TAnywhereControlsUIElement> nativeUIElementCollection)
            {
                _nativeUIElementCollection = nativeUIElementCollection;
            }

            TAnywhereControlsUIElement IList<TAnywhereControlsUIElement>.this[int index]
            {
                get => ToAnywhereControlsUIElement(_nativeUIElementCollection[index]);
                set => _nativeUIElementCollection[index] = ToNativeUIElement(value);
            }

            public int Count => _nativeUIElementCollection.Count;

            public bool IsReadOnly => false;

            public void Add(TAnywhereControlsUIElement item) => _nativeUIElementCollection.Add(ToNativeUIElement(item));

            public void Clear() => _nativeUIElementCollection.Clear();

            public bool Contains(TAnywhereControlsUIElement item) => _nativeUIElementCollection.Contains(ToNativeUIElement(item));

            public void CopyTo(TAnywhereControlsUIElement[] array, int arrayIndex)
            {
                int count = _nativeUIElementCollection.Count;
                for (int i = arrayIndex; i < count; i++)
                {
                    array[i] = ToAnywhereControlsUIElement(_nativeUIElementCollection[i]);
                }
            }

            public IEnumerator<TAnywhereControlsUIElement> GetEnumerator() => new AnywhereControlsUIElementEnumerator(_nativeUIElementCollection);

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            public int IndexOf(TAnywhereControlsUIElement item) => _nativeUIElementCollection.IndexOf(ToNativeUIElement(item));

            public void Insert(int index, TAnywhereControlsUIElement item) => _nativeUIElementCollection.Insert(index, ToNativeUIElement(item));

            public bool Remove(TAnywhereControlsUIElement item) => _nativeUIElementCollection.Remove(ToNativeUIElement(item));

            public void RemoveAt(int index) => _nativeUIElementCollection.RemoveAt(index);

            public void Set(params TAnywhereControlsUIElement[] items)
            {
                // TODO: Potentially provide a more optimized implementation later
                Clear();

                int length = items.Length;
                for (int i = 0; i < length; i++)
                {
                    Add(items[i]);
                }
            }

            internal static TNativeUIElement ToNativeUIElement(TAnywhereControlsUIElement element)
            {
                if (element is TNativeUIElement nativeUIElement)
                    return nativeUIElement;

                if (element is WrappedNativeUIElement wrappedNativeUIElement)
                {
                    Control control = wrappedNativeUIElement.Control;
                    if (control is TNativeUIElement frameworkElementOfNeededType)
                        return frameworkElementOfNeededType;
                }

                throw new InvalidOperationException($"UIElement is of unexpected type '{element.GetType()}' and can't be converted to a native WPF UIElement");
            }

            internal static TAnywhereControlsUIElement ToAnywhereControlsUIElement(TNativeUIElement element)
            {
                if (element is TAnywhereControlsUIElement standardUIElement)
                    return standardUIElement;

                if (element is Control control)
                {
                    var wrappedNativeUIElement = new WrappedNativeUIElement(control);
                    if (wrappedNativeUIElement is TAnywhereControlsUIElement standardUIElementOfNeededType)
                        return standardUIElementOfNeededType;
                }

                throw new InvalidOperationException($"UIElement is of unexpected type '{element.GetType()}' and can't be converted to a StandardUI interface");
            }
        }

        public struct AnywhereControlsUIElementEnumerator : IEnumerator<TAnywhereControlsUIElement>
        {
            private IEnumerator _nativeCollectionEnumerator;

            public AnywhereControlsUIElementEnumerator(UIElementCollection<TNativeUIElement, TAnywhereControlsUIElement> nativeUIElementCollection)
            {
                _nativeCollectionEnumerator = nativeUIElementCollection.GetEnumerator();
            }

            /// <summary>
            /// Advances the enumerator to the next element of the collection.
            /// </summary>
            public bool MoveNext() => _nativeCollectionEnumerator.MoveNext();

            public TAnywhereControlsUIElement Current => AnywhereControlsUIElementCollection.ToAnywhereControlsUIElement((TNativeUIElement)_nativeCollectionEnumerator.Current!);

            object? IEnumerator.Current => Current;

            /// <summary>
            /// Sets the enumerator to its initial position, which is before the first element in the collection.
            /// </summary>
            public void Reset() => _nativeCollectionEnumerator.Reset();

            public void Dispose()
            {
            }
        }
    }
}
