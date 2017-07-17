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

    
}