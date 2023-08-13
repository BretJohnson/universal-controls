using System;
using Microsoft.UI.Xaml;

namespace Microsoft.StandardUI.WinUI
{
    public sealed class UIElementCollection<TNativeUIElment, TStandardUIElement> : BasicUICollection<TNativeUIElment>
        where TNativeUIElment : FrameworkElement where TStandardUIElement : IUIElement
    {
        private readonly FrameworkElement _parent;

#if LATER
        private IUICollection<TStandardUIElement>? _standardUIElementCollection;
#endif

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
            _parent = parent;
        }

        public IUICollection<TStandardUIElement> ToStandardUIElementCollection() => throw new NotImplementedException();

#if LATER
        public IUICollection<TStandardUIElement> ToStandardUIElementCollection()
        {
            if (_standardUIElementCollection == null)
            {
                _standardUIElementCollection = new StandardUIElementCollection(this);
            }

            return _standardUIElementCollection;
        }

        /// <summary>
        /// This class provides a Standard UI wrapper for the collection, implementing IUICollection<TStandardUIElement>,
        /// allowing accessing the collection using Standard UI interfaces.
        /// </summary>
        public class StandardUIElementCollection : IUICollection<TStandardUIElement>
        {
            private readonly UIElementCollection<TNativeUIElment, TStandardUIElement> _nativeUIElementCollection;

            public StandardUIElementCollection(UIElementCollection<TNativeUIElment, TStandardUIElement> nativeUIElementCollection)
            {
                _nativeUIElementCollection = nativeUIElementCollection;
            }

            TStandardUIElement IList<TStandardUIElement>.this[int index]
            {
                get => ToStandardUIElement(_nativeUIElementCollection[index]);
                set => _nativeUIElementCollection[index] = ToNativeUIElement(value);
            }

            public int Count => _nativeUIElementCollection.Count;

            public bool IsReadOnly => false;

            public void Add(TStandardUIElement item) => _nativeUIElementCollection.Add(ToNativeUIElement(item));

            public void Clear() => _nativeUIElementCollection.Clear();

            public bool Contains(TStandardUIElement item) => _nativeUIElementCollection.Contains(ToNativeUIElement(item));

            public void CopyTo(TStandardUIElement[] array, int arrayIndex)
            {
                int count = _nativeUIElementCollection.Count;
                for (int i = arrayIndex; i < count; i++)
                {
                    array[i] = ToStandardUIElement(_nativeUIElementCollection[i]);
                }
            }

            public IEnumerator<TStandardUIElement> GetEnumerator() => new StandardUIEnumerator(_nativeUIElementCollection);

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            public int IndexOf(TStandardUIElement item) => _nativeUIElementCollection.IndexOf(ToNativeUIElement(item));

            public void Insert(int index, TStandardUIElement item) => _nativeUIElementCollection.Insert(index, ToNativeUIElement(item));

            public bool Remove(TStandardUIElement item) => _nativeUIElementCollection.Remove(ToNativeUIElement(item));

            public void RemoveAt(int index) => _nativeUIElementCollection.RemoveAt(index);

            public void Set(params TStandardUIElement[] items)
            {
                // TODO: Potentially provide a more optimized implementation later
                Clear();

                int length = items.Length;
                for (int i = 0; i < length; i++)
                {
                    Add(items[i]);
                }
            }

            internal static TNativeUIElment ToNativeUIElement(TStandardUIElement element)
            {
                if (element is TNativeUIElment nativeUIElement)
                    return nativeUIElement;

                if (element is NativeUIElement wrappedNativeUIElement)
                {
                    FrameworkElement frameworkElement = wrappedNativeUIElement.FrameworkElement;
                    if (frameworkElement is TNativeUIElment frameworkElementOfNeededType)
                        return frameworkElementOfNeededType;
                }

                throw new InvalidOperationException($"UIElement is of unexpected type '{element.GetType()}' and can't be converted to a native WPF UIElement");
            }

            internal static TStandardUIElement ToStandardUIElement(TNativeUIElment element)
            {
                if (element is TStandardUIElement standardUIElement)
                    return standardUIElement;

                if (element is FrameworkElement frameworkElement)
                {
                    var wrappedNativeUIElement = new NativeUIElement(frameworkElement);
                    if (wrappedNativeUIElement is TStandardUIElement standardUIElementOfNeededType)
                        return standardUIElementOfNeededType;
                }

                throw new InvalidOperationException($"UIElement is of unexpected type '{element.GetType()}' and can't be converted to a StandardUI interface");
            }
        }

        public struct NativeUIEnumerator : IEnumerator<TNativeUIElment>
        {
            private VisualCollection.Enumerator _visualCollectionEnumerator;

            public NativeUIEnumerator(UIElementCollection<TNativeUIElment, TStandardUIElement> nativeUIElementCollection)
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

        public struct StandardUIEnumerator : IEnumerator<TStandardUIElement>
        {
            private IEnumerator _visualCollectionEnumerator;

            public StandardUIEnumerator(UIElementCollection<TNativeUIElment, TStandardUIElement> nativeUIElementCollection)
            {
                _visualCollectionEnumerator = nativeUIElementCollection.VisualCollection.GetEnumerator();
            }

            /// <summary>
            /// Advances the enumerator to the next element of the collection.
            /// </summary>
            public bool MoveNext() => _visualCollectionEnumerator.MoveNext();

            public TStandardUIElement Current => StandardUIElementCollection.ToStandardUIElement((TNativeUIElment)_visualCollectionEnumerator.Current!);

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
