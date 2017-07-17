using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logic
{
    public class CustomerFormatsProvider : IFormatProvider, ICustomFormatter
    {
        IFormatProvider _parent;
        public CustomerFormatsProvider() : this(CultureInfo.CurrentCulture) { }

        public CustomerFormatsProvider(IFormatProvider parent)
        {
            _parent = parent;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null || format != "QWE")
                return string.Format(_parent, "{0:" + format + "}", arg);


            StringBuilder result = new StringBuilder();
            string pattern = @"[0-9]";
            string sentence = arg.ToString();
            foreach (Match match in Regex.Matches(sentence, pattern))
                result.Append(match.Value);
            decimal number = Decimal.Parse(result.ToString());

            if (number >= 10000)
                return $"He has a very good revenue";
            if (number <= 1000)
                return $"How he has not yet died with such revenue?";

            return $"Not so bad";
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter)) return this;
            return null;
        }
    }
}
