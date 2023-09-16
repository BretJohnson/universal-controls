using System.Collections;
using Avalonia.Controls;

namespace AnywhereControls.Avalonia
{
    /// <summary>
    /// A UIElementCollection is a ordered collection of UIElements. This code was copied/adapted
    /// from the WPF source at https://github.com/dotnet/wpf/blob/2e07d987e84216e4e223cc72646d1f60f7145eaa/src/Microsoft.DotNet.Wpf/src/PresentationFramework/System/Windows/Controls/UIElementCollection.cs
    /// </summary>
    /// <remarks>
    /// A UIElementCollection has implied context affinity. It is a violation to access
    /// the collection from a different context than that of the owning Panel.
    /// </remarks>
    /// <seealso cref="System.Windows.Media.VisualCollection" />
    public sealed class UIElementCollection<TNativeUIElment, TAnywhereControlUIElement>
#if LATER
        : IList, IList<TNativeUIElment>
#endif
        where TNativeUIElment : Control where TAnywhereControlUIElement : IUIElement
    {
#if LATER
        private readonly VisualCollection _visualChildren;
        private readonly FrameworkElement _visualParent;
        private readonly ILogicalParent _logicalParent;
        private IUICollection<TAnywhereControlUIElement>? _standardUIElementCollection;

        /// <summary>
        ///     The colleciton is the children collection of the visualParent. The logicalParent 
        ///     is used to do logical parenting. The flags is used to invalidate 
        ///     the resource properties in the child tree, if an Application object exists. 
        /// </summary>
        /// <param name="visualParent">The element of whom this is a children collection</param>
        /// <param name="logicalParent">The logicalParent of the elements of this collection. 
        /// if overriding Panel.CreateUIElementCollection, pass the logicalParent parameter of that method here.
        /// </param>
        public UIElementCollection(FrameworkElement parent)
        {
            _visualChildren = new VisualCollection(parent);
            _visualParent = parent;
            _logicalParent = (ILogicalParent)parent;
        }

        public IUICollection<TAnywhereControlUIElement> ToStandardUIElementCollection()
        {
            if (_standardUIElementCollection == null)
            {
                _standardUIElementCollection = new StandardUIElementCollection(this);
            }

            return _standardUIElementCollection;
        }

        /// <summary>
        /// Gets the number of elements in the collection.
        /// </summary>
        public int Count => _visualChildren.Count;

        /// <summary>
        /// Gets a value indicating whether access to the ICollection is synchronized (thread-safe).
        /// For more details, see <see cref="System.Windows.Media.VisualCollection" />
        /// </summary>
        public bool IsSynchronized => _visualChildren.IsSynchronized;

        /// <summary>
        /// For more details, see <see cref="System.Windows.Media.VisualCollection" />
        /// </summary>
        public object SyncRoot => _visualChildren.SyncRoot;

        /// <summary>
        /// Copies the collection into the Array.
        /// For more details, see <see cref="System.Windows.Media.VisualCollection" />
        /// </summary>
        public void CopyTo(Array array, int index) => _visualChildren.CopyTo(array, index);

        /// <summary>
        /// Strongly typed version of CopyTo
        /// Copies the collection into the Array.
        /// For more details, see <see cref="System.Windows.Media.VisualCollection" />
        /// </summary>
        public void CopyTo(TNativeUIElment[] array, int index) => _visualChildren.CopyTo(array, index);

        /// <summary>
        /// For more details, see <see cref="System.Windows.Media.VisualCollection" />
        /// </summary>
        public TNativeUIElment this[int index]
        {
            get => (TNativeUIElment)_visualChildren[index];
            set
            {
                ValidateElementNonNull(value);

                VisualCollection vc = _visualChildren;

                // If setting new element into slot, remove previously hooked element from the
                // logical tree
                Visual oldVisual = vc[index];
                if (oldVisual != value)
                {
                    _logicalParent.RemoveLogicalChild(oldVisual);
                    vc[index] = value;
                    _logicalParent.AddLogicalChild(value);
                    _visualParent.InvalidateMeasure();
                }
            }
        }

        /// <summary>
        /// Adds the element to the UIElementCollection
        /// For more details, see <see cref="System.Windows.Media.VisualCollection" />
        /// </summary>
        public int Add(TNativeUIElment element)
        {
            ValidateElementNonNull(element);

            //Visual visual = ToVisual(element);
            _logicalParent.AddLogicalChild(element);
            int retVal = _visualChildren.Add(element);

            // invalidate measure on visual parent
            _visualParent.InvalidateMeasure();

            return retVal;
        }

        void ICollection<TNativeUIElment>.Add(TNativeUIElment item) => Add(item);

        /// <summary>
        /// Returns the index of the element in the UIElementCollection
        /// For more details, see <see cref="System.Windows.Media.VisualCollection" />
        /// </summary>
        public int IndexOf(TNativeUIElment element) => _visualChildren.IndexOf(element);

        /// <summary>
        /// Removes the specified element from the UIElementCollection.
        /// For more details, see <see cref="System.Windows.Media.VisualCollection" />
        /// </summary>
        public bool Remove(TNativeUIElment element)
        {
            var index = _visualChildren.IndexOf(element);
            if (index == -1)
                return false;

            _visualChildren.RemoveAt(index);
            _logicalParent.RemoveLogicalChild(element);
            _visualParent.InvalidateMeasure();

            return true;
        }

        /// <summary>
        /// Determines whether a element is in the UIElementCollection.
        /// For more details, see <see cref="System.Windows.Media.VisualCollection" />
        /// </summary>
        public bool Contains(TNativeUIElment element) => _visualChildren.Contains(element);

        /// <summary>
        /// Removes all elements from the UIElementCollection.
        /// For more details, see <see cref="System.Windows.Media.VisualCollection" />
        /// </summary>
        public void Clear()
        {
            VisualCollection vc = _visualChildren;
            int cnt = vc.Count;

            if (cnt > 0)
            {
                // copy children in VisualCollection so that we can clear the visual link first, 
                // followed by the logical link
                Visual[] visuals = new Visual[cnt];
                for (int i = 0; i < cnt; i++)
                {
                    visuals[i] = vc[i];
                }

                vc.Clear();

                //disconnect from logical tree
                for (int i = 0; i < cnt; i++)
                {
                    Visual visual = visuals[i];
                    _logicalParent.RemoveLogicalChild(visual);
                }

                _visualParent.InvalidateMeasure();
            }
        }

        /// <summary>
        /// Inserts an element into the UIElementCollection at the specified index.
        /// For more details, see <see cref="System.Windows.Media.VisualCollection" />
        /// </summary>
        public void Insert(int index, TNativeUIElment element)
        {
            ValidateElementNonNull(element);

            _logicalParent.AddLogicalChild(element);
            _visualChildren.Insert(index, element);
            _visualParent.InvalidateMeasure();
        }

        /// <summary>
        /// Removes the UIElement at the specified index.
        /// For more details, see <see cref="System.Windows.Media.VisualCollection" />
        /// </summary>
        public void RemoveAt(int index)
        {
            VisualCollection vc = _visualChildren;

            // Disconnect from logical tree
            Visual oldVisual = vc[index];
            vc.RemoveAt(index);
            _logicalParent.RemoveLogicalChild(oldVisual);

            _visualParent.InvalidateMeasure();
        }

        /// <summary>
        /// Removes a range of Visuals from the VisualCollection.
        /// For more details, see <see cref="System.Windows.Media.VisualCollection" />
        /// </summary>
        public void RemoveRange(int index, int count)
        {
            VisualCollection vc = _visualChildren;
            int cnt = vc.Count;
            if (count > (cnt - index))
            {
                count = cnt - index;
            }

            if (count > 0)
            {
                // copy children in VisualCollection so that we can clear the visual link first, 
                // followed by the logical link
                Visual[] visuals = new Visual[count];
                int i = index;
                for (int loop = 0; loop < count; i++, loop++)
                {
                    visuals[loop] = vc[i];
                }

                vc.RemoveRange(index, count);

                //disconnect from logical tree
                for (i = 0; i < count; i++)
                {
                    Visual visual = visuals[i];
                    _logicalParent.RemoveLogicalChild(visual);
                }

                _visualParent.InvalidateMeasure();
            }
        }

        public IEnumerator<TNativeUIElment> GetEnumerator() => new NativeUIEnumerator(this);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public bool IsFixedSize => false;

        public bool IsReadOnly => false;

        /// <summary>
        /// Adds an element to the UIElementCollection
        /// </summary>
        int IList.Add(object? value) => Add((TNativeUIElment)value!);

        /// <summary>
        /// Determines whether an element is in the UIElementCollection.
        /// </summary>
        bool IList.Contains(object? value) => Contains((TNativeUIElment)value!);

        /// <summary>
        /// Returns the index of the element in the UIElementCollection
        /// </summary>
        int IList.IndexOf(object? value) => IndexOf((TNativeUIElment)value!);

        /// <summary>
        /// Inserts an element into the UIElementCollection
        /// </summary>
        void IList.Insert(int index, object? value) => Insert(index, (TNativeUIElment)value!);

        /// <summary>
        /// Removes an element from the UIElementCollection
        /// </summary>
        void IList.Remove(object? value) => Remove((TNativeUIElment)value!);

        /// <summary>
        /// For more details, see <see cref="System.Windows.Media.VisualCollection" />
        /// </summary>
        object? IList.this[int index]
        {
            get => this[index];
            set => this[index] = (TNativeUIElment)value!;
        }

        internal VisualCollection VisualCollection => _visualChildren;

        // Helper function to validate element; will throw exceptions if problems are detected.
        private static void ValidateElementNonNull(TNativeUIElment? element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("Element can't be null");
            }
        }

        /// <summary>
        /// This class provides a Standard UI wrapper for the collection, implementing IUICollection<TStandardUIElement>,
        /// allowing accessing the collection using Standard UI interfaces.
        /// </summary>
        public class StandardUIElementCollection : IUICollection<TAnywhereControlUIElement>
        {
            private readonly UIElementCollection<TNativeUIElment, TAnywhereControlUIElement> _nativeUIElementCollection;

            public StandardUIElementCollection(UIElementCollection<TNativeUIElment, TAnywhereControlUIElement> nativeUIElementCollection)
            {
                _nativeUIElementCollection = nativeUIElementCollection;
            }

            TAnywhereControlUIElement IList<TAnywhereControlUIElement>.this[int index]
            {
                get => ToStandardUIElement(_nativeUIElementCollection[index]);
                set => _nativeUIElementCollection[index] = ToNativeUIElement(value);
            }

            public int Count => _nativeUIElementCollection.Count;

            public bool IsReadOnly => _nativeUIElementCollection.IsReadOnly;

            public void Add(TAnywhereControlUIElement item) => _nativeUIElementCollection.Add(ToNativeUIElement(item));

            public void Clear() => _nativeUIElementCollection.Clear();

            public bool Contains(TAnywhereControlUIElement item) => _nativeUIElementCollection.Contains(ToNativeUIElement(item));

            public void CopyTo(TAnywhereControlUIElement[] array, int arrayIndex)
            {
                int count = _nativeUIElementCollection.Count;
                for (int i = arrayIndex; i < count; i++)
                {
                    array[i] = ToStandardUIElement(_nativeUIElementCollection[i]);
                }
            }

            public IEnumerator<TAnywhereControlUIElement> GetEnumerator() => new StandardUIEnumerator(_nativeUIElementCollection);

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            public int IndexOf(TAnywhereControlUIElement item) => _nativeUIElementCollection.IndexOf(ToNativeUIElement(item));

            public void Insert(int index, TAnywhereControlUIElement item) => _nativeUIElementCollection.Insert(index, ToNativeUIElement(item));

            public bool Remove(TAnywhereControlUIElement item) => _nativeUIElementCollection.Remove(ToNativeUIElement(item));

            public void RemoveAt(int index) => _nativeUIElementCollection.RemoveAt(index);

            public void Set(params TAnywhereControlUIElement[] items)
            {
                // TODO: Potentially provide a more optimized implementation later
                Clear();

                int length = items.Length;
                for (int i = 0; i < length; i++)
                {
                    Add(items[i]);
                }
            }

            internal static TNativeUIElment ToNativeUIElement(TAnywhereControlUIElement element)
            {
                if (element is TNativeUIElment nativeUIElement)
                    return nativeUIElement;

                if (element is WrappedNativeUIElement wrappedNativeUIElement)
                {
                    FrameworkElement frameworkElement = wrappedNativeUIElement.Control;
                    if (frameworkElement is TNativeUIElment frameworkElementOfNeededType)
                        return frameworkElementOfNeededType;
                }

                throw new InvalidOperationException($"UIElement is of unexpected type '{element.GetType()}' and can't be converted to a native WPF UIElement");
            }

            internal static TAnywhereControlUIElement ToStandardUIElement(TNativeUIElment element)
            {
                if (element is TAnywhereControlUIElement standardUIElement)
                    return standardUIElement;

                if (element is FrameworkElement frameworkElement)
                {
                    var wrappedNativeUIElement = new WrappedNativeUIElement(frameworkElement);
                    if (wrappedNativeUIElement is TAnywhereControlUIElement standardUIElementOfNeededType)
                        return standardUIElementOfNeededType;
                }

                throw new InvalidOperationException($"UIElement is of unexpected type '{element.GetType()}' and can't be converted to a StandardUI interface");
            }
        }

        public struct NativeUIEnumerator : IEnumerator<TNativeUIElment>
        {
            private VisualCollection.Enumerator _visualCollectionEnumerator;

            public NativeUIEnumerator(UIElementCollection<TNativeUIElment, TAnywhereControlUIElement> nativeUIElementCollection)
            {
                _visualCollectionEnumerator = nativeUIElementCollection.VisualCollection.GetEnumerator();
            }

            /// <summary>
            /// Advances the enumerator to the next element of the collection.
            /// </summary>
            public bool MoveNext() => _visualCollectionEnumerator.MoveNext();

            public TNativeUIElment Current => (TNativeUIElment)_visualCollectionEnumerator.Current!;

            object? IEnumerator.Current => Current;

            /// <summary>
            /// Sets the enumerator to its initial position, which is before the first element in the collection.
            /// </summary>
            public void Reset() => _visualCollectionEnumerator.Reset();

            public void Dispose()
            {
            }
        }

        public struct StandardUIEnumerator : IEnumerator<TAnywhereControlUIElement>
        {
            private IEnumerator _visualCollectionEnumerator;

            public StandardUIEnumerator(UIElementCollection<TNativeUIElment, TAnywhereControlUIElement> nativeUIElementCollection)
            {
                _visualCollectionEnumerator = nativeUIElementCollection.VisualCollection.GetEnumerator();
            }

            /// <summary>
            /// Advances the enumerator to the next element of the collection.
            /// </summary>
            public bool MoveNext() => _visualCollectionEnumerator.MoveNext();

            public TAnywhereControlUIElement Current => StandardUIElementCollection.ToStandardUIElement((TNativeUIElment)_visualCollectionEnumerator.Current!);

            object? IEnumerator.Current => Current;

            /// <summary>
            /// Sets the enumerator to its initial position, which is before the first element in the collection.
            /// </summary>
            public void Reset() => _visualCollectionEnumerator.Reset();

            public void Dispose()
            {
            }
        }
#endif
    }
}
