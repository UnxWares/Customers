namespace Customers.Models;

public enum CustomerType
{
    Individual,
    Business
}

public class Customer
{
    public Guid Id { get; set; } // FK to ApplicationUser.Id
    public CustomerType Type { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }

    public ApplicationUser User { get; set; } = null!;
    public IndividualCustomer? Individual { get; set; }
    public BusinessCustomer? Business { get; set; }
}

public class IndividualCustomer
{
    public Guid CustomerId { get; set; } // PK + FK
    
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    
    public Customer Customer { get; set; } = null!;
}

public class BusinessCustomer
{
    public Guid CustomerId { get; set; } // PK + FK

    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string BusinessIdNumber { get; set; } = null!;
    public string VatNumber { get; set; } = null!;
    public string ContactAddress { get; set; } = null!;

    public Customer Customer { get; set; } = null!;
}