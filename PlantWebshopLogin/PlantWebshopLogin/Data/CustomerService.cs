using PlantWebshopLogin.Models;


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

}
