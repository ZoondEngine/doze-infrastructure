using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Doze.Ini
{
    public class Placeholder : IDictionary<string, Section>
	{
		private readonly Dictionary<string, Section> _sections;
		public IEqualityComparer<string> StringComparer;

		public bool SaveEmptySections;

		public Placeholder()
				: this(DefaultComparer)
		{
		}

		public Placeholder(IEqualityComparer<string> stringComparer)
		{
			StringComparer = stringComparer;
			_sections = new Dictionary<string, Section>(StringComparer);
		}

		public void Save(string path, FileMode mode = FileMode.Create)
		{
			using (var stream = new FileStream(path, mode, FileAccess.Write))
			{
				Save(stream);
			}
		}

		public void Save(Stream stream)
		{
			using (var writer = new StreamWriter(stream))
			{
				Save(writer);
			}
		}

		public void Save(StreamWriter writer)
		{
			foreach (var section in _sections)
			{
				if (section.Value.Count > 0 || SaveEmptySections)
				{
					writer.WriteLine($"[{section.Key.Trim()}]");
					foreach (var kvp in section.Value)
					{
						writer.WriteLine($"{kvp.Key}={kvp.Value}");
					}
					writer.WriteLine("");
				}
			}
		}

		public void Load(string path, bool ordered = false)
		{
			using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				Load(stream, ordered);
			}
		}

		public void Load(Stream stream, bool ordered = false)
		{
			using (var reader = new StreamReader(stream))
			{
				Load(reader, ordered);
			}
		}

		public void Load(StreamReader reader, bool ordered = false)
		{
			Section section = null;

			while (!reader.EndOfStream)
			{
				var line = reader.ReadLine();

				if (line != null)
				{
					var trimStart = line.TrimStart();

					if (trimStart.Length > 0)
					{
						if (trimStart[0] == '[')
						{
							var sectionEnd = trimStart.IndexOf(']');
							if (sectionEnd > 0)
							{
								var sectionName = trimStart.Substring(1, sectionEnd - 1).Trim();
								section = new Section(StringComparer) { Ordered = ordered };
								_sections[sectionName] = section;
							}
						}
						else if (section != null && trimStart[0] != ';')
						{
							string key;
							Element val;

							if (LoadValue(line, out key, out val))
							{
								section[key] = val;
							}
						}
					}
				}
			}
		}

		private bool LoadValue(string line, out string key, out Element val)
		{
			var assignIndex = line.IndexOf('=');
			if (assignIndex <= 0)
			{
				key = null;
				val = null;
				return false;
			}

			key = line.Substring(0, assignIndex).Trim();
			var value = line.Substring(assignIndex + 1);

			val = new Element(value);
			return true;
		}

		public bool ContainsSection(string section)
		{
			return _sections.ContainsKey(section);
		}

		public bool TryGetSection(string section, out Section result)
		{
			return _sections.TryGetValue(section, out result);
		}

		bool IDictionary<string, Section>.TryGetValue(string key, out Section value)
		{
			return TryGetSection(key, out value);
		}

		public bool Remove(string section)
		{
			return _sections.Remove(section);
		}

		public Section Add(string section, Dictionary<string, Element> values, bool ordered = false)
		{
			return Add(section, new Section(values, StringComparer) { Ordered = ordered });
		}

		public Section Add(string section, Section value)
		{
			if (value.Comparer != StringComparer)
			{
				value = new Section(value, StringComparer);
			}
			_sections.Add(section, value);
			return value;
		}

		public Section Add(string section, bool ordered = false)
		{
			var value = new Section(StringComparer) { Ordered = ordered };
			_sections.Add(section, value);
			return value;
		}

		void IDictionary<string, Section>.Add(string key, Section value)
		{
			Add(key, value);
		}

		bool IDictionary<string, Section>.ContainsKey(string key)
		{
			return ContainsSection(key);
		}

		public ICollection<string> Keys
		{
			get { return _sections.Keys; }
		}

		public ICollection<Section> Values
		{
			get { return _sections.Values; }
		}

		void ICollection<KeyValuePair<string, Section>>.Add(KeyValuePair<string, Section> item)
		{
			((IDictionary<string, Section>)_sections).Add(item);
		}

		public void Clear()
		{
			_sections.Clear();
		}

		bool ICollection<KeyValuePair<string, Section>>.Contains(KeyValuePair<string, Section> item)
		{
			return ((IDictionary<string, Section>)_sections).Contains(item);
		}

		void ICollection<KeyValuePair<string, Section>>.CopyTo(KeyValuePair<string, Section>[] array, int arrayIndex)
		{
			((IDictionary<string, Section>)_sections).CopyTo(array, arrayIndex);
		}

		public int Count
		{
			get { return _sections.Count; }
		}

		bool ICollection<KeyValuePair<string, Section>>.IsReadOnly
		{
			get { return ((IDictionary<string, Section>)_sections).IsReadOnly; }
		}

		bool ICollection<KeyValuePair<string, Section>>.Remove(KeyValuePair<string, Section> item)
		{
			return ((IDictionary<string, Section>)_sections).Remove(item);
		}

		public IEnumerator<KeyValuePair<string, Section>> GetEnumerator()
		{
			return _sections.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public Section this[string section]
		{
			get
			{
				Section s;
				if (_sections.TryGetValue(section, out s))
				{
					return s;
				}
				s = new Section(StringComparer);
				_sections[section] = s;
				return s;
			}
			set
			{
				var v = value;
				if (v.Comparer != StringComparer)
				{
					v = new Section(v, StringComparer);
				}
				_sections[section] = v;
			}
		}

		public string GetContents()
		{
			using (var stream = new MemoryStream())
			{
				Save(stream);
				stream.Flush();
				var builder = new StringBuilder(Encoding.UTF8.GetString(stream.ToArray()));
				return builder.ToString();
			}
		}

		public static IEqualityComparer<string> DefaultComparer = new CaseInsensitiveStringComparer();

		private class CaseInsensitiveStringComparer : IEqualityComparer<string>
		{
			public bool Equals(string x, string y)
			{
				return string.Compare(x, y, StringComparison.OrdinalIgnoreCase) == 0;
			}

			public int GetHashCode(string obj)
			{
				return obj.ToLowerInvariant().GetHashCode();
			}
		}
	}
}
