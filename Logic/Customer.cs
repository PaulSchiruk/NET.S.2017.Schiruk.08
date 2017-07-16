using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Customer class with the fields "Name", "ContactPhone" and "Revenue"
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Class Properties
        /// </summary>
        #region Properties
        /// <value>The Name property gets/sets the value of the string field name</value>
        public string Name { get; set; }
        /// <value>The Name property gets/sets the value of the string field contactPhone</value>
        public string ContactPhone { get; set; }
        /// <value>The Name property gets/sets the value of the decimal field revenue</value>
        public decimal Revenue { get; set; }
        #endregion


        #region Ctors
        /// <summary>
        /// Ctor with 2 parameters of a "Customer" class
        /// </summary>
        /// <param name="name">Customer name</param>
        /// <param name="contactPhone">Customer contact number</param>
        /// <param name="revenue">How much customer receives</param>
        public Customer(string name, string contactPhone, decimal revenue)
        {
            Name = name;
            ContactPhone = contactPhone;
            Revenue = revenue;
        } 
        /// <summary>
        /// Ctor with no parameters of a "Customer" class
        /// Establish default value for all properties
        /// </summary>
        public Customer()
        {
            Name = "John Smith";
            ContactPhone = "+375(33)6666666";
            Revenue = 10000;
        }
        #endregion


        #region Methods
        /// <summary>
        /// Owerreded method "ToString"
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.ToString("DEF");
        }
        /// <summary>
        /// Format ToSrting method
        /// </summary>
        /// <param name="format">String.Format wich you can use:
        /// "DEF", "P", "NR", "N" or "R"</param>
        /// <returns>Returns string representation of a Customer class, 
        /// demends of wich format you use.</returns>
        public string ToString(string format)
        {
            if (String.IsNullOrEmpty(format)) format = "DEF";
            format = format.Trim().ToUpperInvariant();
            
            switch (format)
            {
                case "DEF":
                    return $"Customer record: {this.Name}, {this.Revenue:N}, {this.ContactPhone}";
                case "PH":
                    return $"Customer record: {this.ContactPhone}";
                case "NR":
                    return $"Customer record: {this.Name}, {this.Revenue:N}";
                case "NA":
                    return $"Customer record: {this.Name}";
                case "RE":
                    return $"Customer record: {this.Revenue}";
                default:
                    throw new FormatException($"The \"{format}\" format string is not supported.");
            }
        }
        #endregion
    }
}
