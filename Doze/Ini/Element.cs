using System;

namespace Doze.Ini
{
    public struct Element
	{
		private static bool TryParseInt(string text, out int value)
		{
			if (int.TryParse(text,
					System.Globalization.NumberStyles.Integer,
					System.Globalization.CultureInfo.InvariantCulture,
					out var res))
			{
				value = res;
				return true;
			}
			value = 0;
			return false;
		}

		private static bool TryParseDouble(string text, out double value)
		{
			double res;
			if (double.TryParse(text,
					System.Globalization.NumberStyles.Float,
					System.Globalization.CultureInfo.InvariantCulture,
					out res))
			{
				value = res;
				return true;
			}
			value = Double.NaN;
			return false;
		}

		public string Value;

		public Element(object value)
		{
			if (value is IFormattable formattable)
			{
				Value = formattable.ToString(null, System.Globalization.CultureInfo.InvariantCulture);
			}
			else
			{
				Value = value?.ToString();
			}
		}

		public Element(string value)
		{
			Value = value;
		}

		public bool ToBool(bool valueIfInvalid = false)
		{
			bool res;
			if (TryConvertBool(out res))
			{
				return res;
			}
			return valueIfInvalid;
		}

		public bool TryConvertBool(out bool result)
		{
			if (Value == null)
			{
				result = default(bool);
				return false;
			}
			var boolStr = Value.Trim().ToLowerInvariant();
			if (boolStr == "true")
			{
				result = true;
				return true;
			}
			else if (boolStr == "false")
			{
				result = false;
				return true;
			}
			result = default(bool);
			return false;
		}

		public int ToInt(int valueIfInvalid = 0)
		{
			int res;
			if (TryConvertInt(out res))
			{
				return res;
			}
			return valueIfInvalid;
		}

		public bool TryConvertInt(out int result)
		{
			if (Value == null)
			{
				result = default(int);
				return false;
			}
			if (TryParseInt(Value.Trim(), out result))
			{
				return true;
			}
			return false;
		}

		public double ToDouble(double valueIfInvalid = 0)
		{
			double res;
			if (TryConvertDouble(out res))
			{
				return res;
			}
			return valueIfInvalid;
		}

		public bool TryConvertDouble(out double result)
		{
			if (Value == null)
			{
				result = default(double);
				return false;
			}
			if (TryParseDouble(Value.Trim(), out result))
			{
				return true;
			}
			return false;
		}

		public string GetString()
		{
			return GetString(true, false);
		}

		public string GetString(bool preserveWhitespace)
		{
			return GetString(true, preserveWhitespace);
		}

		public string GetString(bool allowOuterQuotes, bool preserveWhitespace)
		{
			if (Value == null)
			{
				return "";
			}
			var trimmed = Value.Trim();
			if (allowOuterQuotes && trimmed.Length >= 2 && trimmed[0] == '"' && trimmed[trimmed.Length - 1] == '"')
			{
				var inner = trimmed.Substring(1, trimmed.Length - 2);
				return preserveWhitespace ? inner : inner.Trim();
			}
			else
			{
				return preserveWhitespace ? Value : Value.Trim();
			}
		}

		public T Get<T>()
		{
			if (typeof(T) == typeof(bool))
				return (T)(object)ToBool();

			if (typeof(T) == typeof(double))
				return (T)(object)ToDouble();

			if (typeof(T) == typeof(int))
				return (T)(object)ToInt();

			if (typeof(T) == typeof(string))
				return (T)(object)GetString();

			return default;
		}

		public override string ToString()
		{
			return Value;
		}

		public static implicit operator Element(byte o)
		{
			return new Element(o);
		}

		public static implicit operator Element(short o)
		{
			return new Element(o);
		}

		public static implicit operator Element(int o)
		{
			return new Element(o);
		}

		public static implicit operator Element(sbyte o)
		{
			return new Element(o);
		}

		public static implicit operator Element(ushort o)
		{
			return new Element(o);
		}

		public static implicit operator Element(uint o)
		{
			return new Element(o);
		}

		public static implicit operator Element(float o)
		{
			return new Element(o);
		}

		public static implicit operator Element(double o)
		{
			return new Element(o);
		}

		public static implicit operator Element(bool o)
		{
			return new Element(o);
		}

		public static implicit operator Element(string o)
		{
			return new Element(o);
		}

		public static Element Default { get; } = new Element();
	}
}
