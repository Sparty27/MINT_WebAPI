using MINT_WebAPI.Models;

namespace MINT_WebAPI.Managers.CustomerManaging
{
    public interface ICustomerManager
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer? GetCustomerById(int id);

        Customer? GetCustomerByName(string name);
        int CreateCustomer(Customer customer);

        int UpdateCustomer(Customer customer);

        int DeleteCustomerById(int id);
    }
}
