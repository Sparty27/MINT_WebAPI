using MINT_WebAPI.DataControllers;
using MINT_WebAPI.Models;

namespace MINT_WebAPI.Managers.CustomerManaging
{
    public class CustomerManager : ICustomerManager
    {
        private readonly CustomersDataController _customersDataController;

        public CustomerManager(IConfiguration configuration)
        {
            _customersDataController = new CustomersDataController(configuration);
        }

        public IEnumerable<Customer> GetAllCustomers()
            => _customersDataController.GetAllCustomers();

        public Customer? GetCustomerById(int id)
            => _customersDataController.GetCustomerById(id);

        public Customer? GetCustomerByName(string name)
            => _customersDataController.GetCustomerByName(name);

        public int CreateCustomer(Customer customer)
            => _customersDataController.CreateCustomer(customer);

        public int UpdateCustomer(Customer customer)
            => _customersDataController.UpdateCustomer(customer);

        public int DeleteCustomerById(int id)
            => _customersDataController.DeleteCustomerById(id);
    }
}
