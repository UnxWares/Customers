using Microsoft.AspNetCore.Identity;

namespace Customers.Models;

public class ApplicationUser : IdentityUser<Guid>
{
    public Customer? Customer { get; set; }
}