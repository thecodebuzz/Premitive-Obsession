using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace S2
{

    public class Order
    {
        public Order(string name, string email, int orderid, string address)
        {
            CustomerName = name;
            CustomerEmail = email;
            OrderId = orderid;
            Address = address;
        }
        public string CustomerName { get; private set; }
        public string CustomerEmail { get; private set; }
        public int OrderId { get; set; }
        public string Address { get; set; }
    }

    public class Employees
    {
        public Employees(string firstName, string lastName,string contactCellNo,string ssn)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = contactCellNo;
            SSN = ssn;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string SSN { get; set; }
        public string GetAreaCode()
        {
            var phone = PhoneNumber;
            // Extract the area code
            var areacode = "";
            int index = phone.LastIndexOf("-", StringComparison.Ordinal);
            if (index > 0 && index < phone.Length)
                areacode = phone.Substring(0, index);
            return areacode;
        }

        internal void GetEmployeeDetails()
        {
            throw new NotImplementedException();
        }

        public string GetLast4Digit()
        {
            var index = SSN.LastIndexOf("-", StringComparison.Ordinal);
            return index > 0 && index < SSN.Length
                ? SSN.Substring(index + 1, SSN.Length - index + 1)
                : SSN;
        }
    }

    public class Contact
    {
        public Contact(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new InvalidDataException();

            PhoneNumber = number;
        }

        public string PhoneNumber { get; }

        public string GetAreaCode()
        {
            var index = PhoneNumber.IndexOf("-", StringComparison.Ordinal);
            return index > 0 && index < PhoneNumber.Length
                ? PhoneNumber.Substring(0,index)
                : PhoneNumber;
        }
    }
}

namespace OrderService1
{
    public class Order
    {
        public Order(string customerName, string customerEmail, int orderId, string orderDate, string address, string city, string state, int orderAmout)
        {
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            OrderId = orderId;
            OrderDate = orderDate;
            Address = address;
            City = city;
            State = state;
            OrderAmout = orderAmout;
        }

        public string CustomerName { get; private set; }
        public string CustomerEmail { get; private set; }
        public int OrderId { get; set; }
        public string OrderDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int OrderAmout { get; set; }
        public DateTime date { get; set; }

       
    }

    public class Employee
    {
        public Employee(string firstName, string lastName,Contact contactCellNo, SocialSecurity ssn)
        {
            FirstName = firstName;
            LastName = lastName;
            Contact = contactCellNo;
            SocialSecurity = ssn;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Contact Contact { get; set; }
        public SocialSecurity SocialSecurity { get; set; }
    }

    public class SocialSecurity
    {
        public SocialSecurity(string ssn)
        {
            SSN = ssn;
        }

        public string SSN { get; set; }

        public string GetLast4Digit()
        {
            var index = SSN.LastIndexOf("-", StringComparison.Ordinal);
            return index > 0 && index < SSN.Length
                ? SSN.Substring(index+1, SSN.Length -index+1)
                : SSN;
        }
    }

    public class Contact
    {
        public Contact(string number)
        { 
            PhoneNumber = number;
        }

        public string PhoneNumber { get; set; }

        public string GetAreaCode()
        {
            var index = PhoneNumber.IndexOf("-", StringComparison.Ordinal);
            return index > 0 && index < PhoneNumber.Length
                ? PhoneNumber.Substring(0, index)
                : PhoneNumber;
        }
    }

}
