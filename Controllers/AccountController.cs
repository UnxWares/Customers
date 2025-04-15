using InertiaCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Customers.Controllers;

[Route("[controller]")]
[Controller]
public class AccountController
{
    [HttpGet("register")]
    [AllowAnonymous]
    public IActionResult Register()
    {
        return Inertia.Render("Account/Register");
    }
}