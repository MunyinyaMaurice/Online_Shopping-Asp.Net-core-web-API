using Microsoft.AspNetCore.Mvc;
using Shop_online.Interfaces;
using Shop_online.Model;



namespace Shop_online.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerInterface _customerInterface;

        public CustomersController(CustomerInterface customerInterface)
        {
            _customerInterface = customerInterface;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = _customerInterface.GetCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult GetCustomer(int id)
        {
            var customer = _customerInterface.GetCustomer(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                return BadRequest();
            }

            var customer = new Customer
            {
                customer_names = customerDto.customer_names,
                customer_email = customerDto.customer_email,
                customer_phoneNo = customerDto.customer_phoneNo,
                customer_yearOfDate = customerDto.customer_yearOfDate,
                customer_nationality = customerDto.customer_nationality,
                customer_address = customerDto.customer_address,
                //Orders = customerDto.orders
                Orders = (ICollection<Order>)customerDto.orders
            };

            _customerInterface.CreateCustmer(customer);

            return CreatedAtRoute("GetCustomer", new { id = customer.customer_id }, customer);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] CustomerDto customerDto)
        {
            if (customerDto == null || customerDto.customer_id != id)
            {
                return BadRequest();
            }

            var customer = _customerInterface.GetCustomer(id);

            if (customer == null)
            {
                return NotFound();
            }

            customer.customer_names = customerDto.customer_names;
            customer.customer_email = customerDto.customer_email;
            customer.customer_phoneNo = customerDto.customer_phoneNo;
            customer.customer_yearOfDate = customerDto.customer_yearOfDate;
            customer.customer_nationality = customerDto.customer_nationality;
            customer.customer_address = customerDto.customer_address;
            customer.Orders = (ICollection<Order>)customerDto.orders;

            _customerInterface.UpdateCustmer(customer);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _customerInterface.GetCustomer(id);

            if (customer == null)
            {
                return NotFound();
            }

            _customerInterface.DeleteCustmer(customer);

            return NoContent();
        }
    }
}
