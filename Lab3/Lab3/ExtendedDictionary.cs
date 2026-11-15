using System;
using System.Collections;
using System.Collections.Generic;

namespace ExtensionsDemo
{
    public class ExtendedDictionary<T, U, V> : IEnumerable<ExtendedDictionaryElement<T, U, V>>
    {
        private readonly List<ExtendedDictionaryElement<T, U, V>> _items = new List<ExtendedDictionaryElement<T, U, V>>();

        public int Count => _items.Count;

        public void Add(T key, U value1, V value2)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key), "Ключ не може бути null.");

            if (ContainsKey(key))
                throw new ArgumentException($"Елемент із ключем '{key}' вже існує у словнику.");

            _items.Add(new ExtendedDictionaryElement<T, U, V>(key, value1, value2));
        }

        public bool Remove(T key)
        {
            var element = FindByKey(key);
            if (element != null)
            {
                return _items.Remove(element);
            }
            return false;
        }

        public bool ContainsKey(T key)
        {
            return FindByKey(key) != null;
        }

        public bool ContainsValues(U value1, V value2)
        {
            foreach (var item in _items)
            {
                bool v1Equal = EqualityComparer<U>.Default.Equals(item.Value1, value1);
                bool v2Equal = EqualityComparer<V>.Default.Equals(item.Value2, value2);

                if (v1Equal && v2Equal)
                    return true;
            }
            return false;
        }

        public ExtendedDictionaryElement<T, U, V> this[T key]
        {
            get
            {
                var element = FindByKey(key);
                if (element == null)
                    throw new KeyNotFoundException($"Елемент із ключем '{key}' не знайдено.");
                return element;
            }
        }

        private ExtendedDictionaryElement<T, U, V> FindByKey(T key)
        {
            foreach (var item in _items)
            {
                if (EqualityComparer<T>.Default.Equals(item.Key, key))
                    return item;
            }
            return null;
        }

        public IEnumerator<ExtendedDictionaryElement<T, U, V>> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}