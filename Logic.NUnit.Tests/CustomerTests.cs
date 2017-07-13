using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace Logic.NUnit.Tests
{

    [TestFixture()]
    public class CustomerTests
    {
        [TestCase( ExpectedResult = true)]
        public bool Customer_ToString_FormatP_PositiveTests()
        {
            Customer testCustomer = new Customer();
            string tst1 = testCustomer.ToString("p");
            string tst2 = $"Customer record: {testCustomer.ContactPhone}";
            return String.CompareOrdinal(tst2,tst1) == 0;
        }


        [TestCase(ExpectedResult = true)]
        public bool Customer_ToString_FormatDEF_PositiveTests()
        {
            Customer testCustomer = new Customer();
            string tst1 = $"{testCustomer:DEF}";
            string tst2 = $"Customer record: John Smith, {testCustomer.Revenue:N}, +375(33)6666666";
            return String.CompareOrdinal(tst2, tst1) == 0;
        }  

        [TestCase(ExpectedResult = true)]
        public bool Customer_ToString_FormatAdd_PositiveTests()
        {
            CultureInfo ci = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name);
            Customer testCustomer = new Customer();
            string tst1 = string.Format(ci, "{0:QWE}", testCustomer);
            string tst2 = "He has a very good revenue";
            return String.CompareOrdinal(tst2, tst1) == 0;
        }
    }

    public class AdditionalFormatsProvider : IFormatProvider, ICustomFormatter
    {
        IFormatProvider _parent;
        public AdditionalFormatsProvider() : this (CultureInfo.CurrentCulture) { }

        public AdditionalFormatsProvider(IFormatProvider parent)
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