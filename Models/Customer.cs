using System.ComponentModel.DataAnnotations;

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
    public BillingInformation? Billing { get; set; }
}

public class IndividualCustomer
{
    public Guid CustomerId { get; set; } // PK + FK
    
    [Required, MaxLength(100)]
    public string FirstName { get; set; } = null!;
    [Required, MaxLength(100)]
    public string LastName { get; set; } = null!;
    [MaxLength(20)]
    public string? PhoneNumber { get; set; } = null!;
    
    public Customer Customer { get; set; } = null!;
}

public class BusinessCustomer
{
    public Guid CustomerId { get; set; } // PK + FK

    [Required, MaxLength(200)]
    public string Name { get; set; } = null!;
    [MaxLength(100)]
    public string? LegalForm { get; set; }
    [MaxLength(50)]
    public string BusinessIdNumber { get; set; } = null!;
    [MaxLength(100)]
    public string ContactAddress { get; set; } = null!;

    public Customer Customer { get; set; } = null!;
}