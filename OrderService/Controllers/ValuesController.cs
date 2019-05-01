using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderService1;
using S2;


namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<Employee> Get(int id)
        {
            var contact = new OrderService1.Contact("123-456-6789");
            var areaCode = contact.GetAreaCode();
            OrderService1.Contact contact1 = new OrderService1.Contact("123-456-7890");
            SocialSecurity ssn = new SocialSecurity("111-22-3333");

            Employee emp = new Employee("abcd", "asdas", contact1, ssn);

            return emp;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Employees> Get()
        {
            
            var phone = "111-22-3333";
            var areacode = string.Empty;
            Employees emp = null;
            try
            {
                // Get area code from phone number
                int index = phone.IndexOf("-", StringComparison.Ordinal);
                if (index > 0 && index < phone.Length)
                    areacode = phone.Substring(0,index);

                // Business logic
                emp = new Employees("abcd", "asdas", areacode, phone);
                emp.GetEmployeeDetails();
                if (emp == null)
                { return NoContent(); }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            // Business logic

            return Ok(emp);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Employee value)
        {
           if(value!=null)
            {
                string employeeAreaCode= value.Contact.GetAreaCode();
                //string employee4DigitSSN = value.SocialSecurity.GetLast4Digit();
            }
        }

        [HttpPost]
        [Route("ssn")]
        public void Update([FromBody]Employee value)
        {
            if (value != null)
            {
                string employee4DigitSSN = value.SocialSecurity.GetLast4Digit();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
