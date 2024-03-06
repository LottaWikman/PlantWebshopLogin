using PlantWebshopLogin.Models;
using PlantWebshopLogin.Client.Models;

namespace PlantWebshopLogin.Data;

public class CustomerService
{
    private Customer _currentCustomer;

    public void CreateCustomer(Customer customer)
    {
        _currentCustomer = customer;
    }

    public Customer GetCurrentCustomer()
    {
        return _currentCustomer;
    }

    public void ClearCustomer()
    {
        _currentCustomer = null;
    }

    public ClientCustomer ConvertToClientCustomer(Customer customer)
    {
        return new ClientCustomer
        {
            Id = customer.Id,
            Firstname = customer.Firstname,
            Lastname = customer.Lastname,
            Address = customer.Address,
            City = customer.City
        };
    }

}
