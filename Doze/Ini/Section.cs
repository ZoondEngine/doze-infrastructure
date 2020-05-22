using System;
using System.Collections.Generic;
using System.Linq;

namespace Doze.Ini
{
    public class Section : IDictionary<string, Element>
	{
		private readonly Dictionary<string, Element> _values;

		#region Ordered
		private List<string> _orderedKeys;

		public int IndexOf(string key)
		{
			if (!Ordered)
			{
				throw new InvalidOperationException("Cannot call IndexOf(string) on IniSection: section was not ordered.");
			}
			return IndexOf(key, 0, _orderedKeys.Count);
		}

		public int IndexOf(string key, int index)
		{
			if (!Ordered)
			{
				throw new InvalidOperationException("Cannot call IndexOf(string, int) on IniSection: section was not ordered.");
			}
			return IndexOf(key, index, _orderedKeys.Count - index);
		}

		public int IndexOf(string key, int index, int count)
		{
			if (!Ordered)
			{
				throw new InvalidOperationException("Cannot call IndexOf(string, int, int) on IniSection: section was not ordered.");
			}
			if (index < 0 || index > _orderedKeys.Count)
			{
				throw new IndexOutOfRangeException("Index must be within the bounds." + Environment.NewLine + "Parameter name: index");
			}
			if (count < 0)
			{
				throw new IndexOutOfRangeException("Count cannot be less than zero." + Environment.NewLine + "Parameter name: count");
			}
			if (index + count > _orderedKeys.Count)
			{
				throw new ArgumentException("Index and count were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection.");
			}
			var end = index + count;
			for (int i = index; i < end; i++)
			{
				if (Comparer.Equals(_orderedKeys[i], key))
				{
					return i;
				}
			}
			return -1;
		}

		public int LastIndexOf(string key)
		{
			if (!Ordered)
			{
				throw new InvalidOperationException("Cannot call LastIndexOf(string) on IniSection: section was not ordered.");
			}
			return LastIndexOf(key, 0, _orderedKeys.Count);
		}

		public int LastIndexOf(string key, int index)
		{
			if (!Ordered)
			{
				throw new InvalidOperationException("Cannot call LastIndexOf(string, int) on IniSection: section was not ordered.");
			}
			return LastIndexOf(key, index, _orderedKeys.Count - index);
		}

		public int LastIndexOf(string key, int index, int count)
		{
			if (!Ordered)
			{
				throw new InvalidOperationException("Cannot call LastIndexOf(string, int, int) on IniSection: section was not ordered.");
			}
			if (index < 0 || index > _orderedKeys.Count)
			{
				throw new IndexOutOfRangeException("Index must be within the bounds." + Environment.NewLine + "Parameter name: index");
			}
			if (count < 0)
			{
				throw new IndexOutOfRangeException("Count cannot be less than zero." + Environment.NewLine + "Parameter name: count");
			}
			if (index + count > _orderedKeys.Count)
			{
				throw new ArgumentException("Index and count were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection.");
			}
			var end = index + count;
			for (int i = end - 1; i >= index; i--)
			{
				if (Comparer.Equals(_orderedKeys[i], key))
				{
					return i;
				}
			}
			return -1;
		}

		public void Insert(int index, string key, Element value)
		{
			if (!Ordered)
			{
				throw new InvalidOperationException("Cannot call Insert(int, string, Element) on IniSection: section was not ordered.");
			}
			if (index < 0 || index > _orderedKeys.Count)
			{
				throw new IndexOutOfRangeException("Index must be within the bounds." + Environment.NewLine + "Parameter name: index");
			}
			_values.Add(key, value);
			_orderedKeys.Insert(index, key);
		}

		public void InsertRange(int index, IEnumerable<KeyValuePair<string, Element>> collection)
		{
			if (!Ordered)
			{
				throw new InvalidOperationException("Cannot call InsertRange(int, IEnumerable<KeyValuePair<string, Element>>) on IniSection: section was not ordered.");
			}
			if (collection == null)
			{
				throw new ArgumentNullException("Value cannot be null." + Environment.NewLine + "Parameter name: collection");
			}
			if (index < 0 || index > _orderedKeys.Count)
			{
				throw new IndexOutOfRangeException("Index must be within the bounds." + Environment.NewLine + "Parameter name: index");
			}
			foreach (var kvp in collection)
			{
				Insert(index, kvp.Key, kvp.Value);
				index++;
			}
		}

		public void RemoveAt(int index)
		{
			if (!Ordered)
			{
				throw new InvalidOperationException("Cannot call RemoveAt(int) on IniSection: section was not ordered.");
			}
			if (index < 0 || index > _orderedKeys.Count)
			{
				throw new IndexOutOfRangeException("Index must be within the bounds." + Environment.NewLine + "Parameter name: index");
			}
			var key = _orderedKeys[index];
			_orderedKeys.RemoveAt(index);
			_values.Remove(key);
		}

		public void RemoveRange(int index, int count)
		{
			if (!Ordered)
			{
				throw new InvalidOperationException("Cannot call RemoveRange(int, int) on IniSection: section was not ordered.");
			}
			if (index < 0 || index > _orderedKeys.Count)
			{
				throw new IndexOutOfRangeException("Index must be within the bounds." + Environment.NewLine + "Parameter name: index");
			}
			if (count < 0)
			{
				throw new IndexOutOfRangeException("Count cannot be less than zero." + Environment.NewLine + "Parameter name: count");
			}
			if (index + count > _orderedKeys.Count)
			{
				throw new ArgumentException("Index and count were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection.");
			}
			for (int i = 0; i < count; i++)
			{
				RemoveAt(index);
			}
		}

		public void Reverse()
		{
			if (!Ordered)
			{
				throw new InvalidOperationException("Cannot call Reverse() on IniSection: section was not ordered.");
			}
			_orderedKeys.Reverse();
		}

		public void Reverse(int index, int count)
		{
			if (!Ordered)
			{
				throw new InvalidOperationException("Cannot call Reverse(int, int) on IniSection: section was not ordered.");
			}
			if (index < 0 || index > _orderedKeys.Count)
			{
				throw new IndexOutOfRangeException("Index must be within the bounds." + Environment.NewLine + "Parameter name: index");
			}
			if (count < 0)
			{
				throw new IndexOutOfRangeException("Count cannot be less than zero." + Environment.NewLine + "Parameter name: count");
			}
			if (index + count > _orderedKeys.Count)
			{
				throw new ArgumentException("Index and count were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection.");
			}
			_orderedKeys.Reverse(index, count);
		}

		public ICollection<Element> GetOrderedValues()
		{
			if (!Ordered)
			{
				throw new InvalidOperationException("Cannot call GetOrderedValues() on IniSection: section was not ordered.");
			}
			var list = new List<Element>();
			for (int i = 0; i < _orderedKeys.Count; i++)
			{
				list.Add(_values[_orderedKeys[i]]);
			}
			return list;
		}

		public Element this[int index]
		{
			get
			{
				if (!Ordered)
				{
					throw new InvalidOperationException("Cannot index IniSection using integer key: section was not ordered.");
				}
				if (index < 0 || index >= _orderedKeys.Count)
				{
					throw new IndexOutOfRangeException("Index must be within the bounds." + Environment.NewLine + "Parameter name: index");
				}
				return _values[_orderedKeys[index]];
			}
			set
			{
				if (!Ordered)
				{
					throw new InvalidOperationException("Cannot index IniSection using integer key: section was not ordered.");
				}
				if (index < 0 || index >= _orderedKeys.Count)
				{
					throw new IndexOutOfRangeException("Index must be within the bounds." + Environment.NewLine + "Parameter name: index");
				}
				var key = _orderedKeys[index];
				_values[key] = value;
			}
		}

		public bool Ordered
		{
			get
			{
				return _orderedKeys != null;
			}
			set
			{
				if (Ordered != value)
				{
					_orderedKeys = value ? new List<string>(_values.Keys) : null;
				}
			}
		}
		#endregion

		public Section()
				: this(Placeholder.DefaultComparer)
		{
		}

		public Section(IEqualityComparer<string> stringComparer)
		{
			this._values = new Dictionary<string, Element>(stringComparer);
		}

		public Section(Dictionary<string, Element> values)
				: this(values, Placeholder.DefaultComparer)
		{
		}

		public Section(Dictionary<string, Element> values, IEqualityComparer<string> stringComparer)
		{
			this._values = new Dictionary<string, Element>(values, stringComparer);
		}

		public Section(Section values)
				: this(values, Placeholder.DefaultComparer)
		{
		}

		public Section(Section values, IEqualityComparer<string> stringComparer)
		{
			this._values = new Dictionary<string, Element>(values._values, stringComparer);
		}

		public void Add(string key, Element value)
		{
			_values.Add(key, value);
			if (Ordered)
			{
				_orderedKeys.Add(key);
			}
		}

		public bool ContainsKey(string key)
		{
			return _values.ContainsKey(key);
		}

		/// <summary>
		/// Returns this IniSection's collection of keys. If the IniSection is ordered, the keys will be returned in order.
		/// </summary>
		public ICollection<string> Keys
		{
			get { return Ordered ? (ICollection<string>)_orderedKeys : _values.Keys; }
		}

		public bool Remove(string key)
		{
			var ret = _values.Remove(key);
			if (Ordered && ret)
			{
				for (int i = 0; i < _orderedKeys.Count; i++)
				{
					if (Comparer.Equals(_orderedKeys[i], key))
					{
						_orderedKeys.RemoveAt(i);
						break;
					}
				}
			}
			return ret;
		}

		public bool TryGetValue(string key, out Element value)
		{
			return _values.TryGetValue(key, out value);
		}

		/// <summary>
		/// Returns the values in this IniSection. These values are always out of order. To get ordered values from an IniSection call GetOrderedValues instead.
		/// </summary>
		public ICollection<Element> Values
		{
			get
			{
				return _values.Values;
			}
		}

		void ICollection<KeyValuePair<string, Element>>.Add(KeyValuePair<string, Element> item)
		{
			((IDictionary<string, Element>)_values).Add(item);
			if (Ordered)
			{
				_orderedKeys.Add(item.Key);
			}
		}

		public void Clear()
		{
			_values.Clear();
			if (Ordered)
			{
				_orderedKeys.Clear();
			}
		}

		bool ICollection<KeyValuePair<string, Element>>.Contains(KeyValuePair<string, Element> item)
		{
			return ((IDictionary<string, Element>)_values).Contains(item);
		}

		void ICollection<KeyValuePair<string, Element>>.CopyTo(KeyValuePair<string, Element>[] array, int arrayIndex)
		{
			((IDictionary<string, Element>)_values).CopyTo(array, arrayIndex);
		}

		public int Count
		{
			get { return _values.Count; }
		}

		bool ICollection<KeyValuePair<string, Element>>.IsReadOnly
		{
			get { return ((IDictionary<string, Element>)_values).IsReadOnly; }
		}

		bool ICollection<KeyValuePair<string, Element>>.Remove(KeyValuePair<string, Element> item)
		{
			var ret = ((IDictionary<string, Element>)_values).Remove(item);
			if (Ordered && ret)
			{
				for (int i = 0; i < _orderedKeys.Count; i++)
				{
					if (Comparer.Equals(_orderedKeys[i], item.Key))
					{
						_orderedKeys.RemoveAt(i);
						break;
					}
				}
			}
			return ret;
		}

		public IEnumerator<KeyValuePair<string, Element>> GetEnumerator()
		{
			if (Ordered)
			{
				return GetOrderedEnumerator();
			}
			else
			{
				return _values.GetEnumerator();
			}
		}

		private IEnumerator<KeyValuePair<string, Element>> GetOrderedEnumerator()
		{
			for (int i = 0; i < _orderedKeys.Count; i++)
			{
				yield return new KeyValuePair<string, Element>(_orderedKeys[i], _values[_orderedKeys[i]]);
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEqualityComparer<string> Comparer => _values.Comparer;

		public Element this[string name]
		{
			get => _values.TryGetValue(name, out var val) ? val : Element.Default;
			set
			{
				if (Ordered && !_orderedKeys.Contains(name, Comparer))
				{
					_orderedKeys.Add(name);
				}
				_values[name] = value;
			}
		}

		public static implicit operator Section(Dictionary<string, Element> dict)
		{
			return new Section(dict);
		}

		public static explicit operator Dictionary<string, Element>(Section section)
		{
			return section._values;
		}
	}
}
