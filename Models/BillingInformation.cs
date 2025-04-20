namespace Customers.Models;

public class BillingInformation
{
    public Guid CustomerId { get; set; } // PK + FK
    
    public string BillingAddress { get; set; } = null!;
    public string BillingCity { get; set; } = null!;
    public string BillingState { get; set; } = null!;
    public string BillingPostalCode { get; set; } = null!;
    public string BillingCountry { get; set; } = null!;
    public bool IsVatExempt { get; set; }
    public string? VatId { get; set; }
    public string? PreferredCurrency { get; set; }
    
    // Navigation property
    public Customer Customer { get; set; } = null!;
}