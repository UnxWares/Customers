using InertiaCore;
using Microsoft.AspNetCore.Mvc;

namespace Customers.Controllers;

[Controller]
public class HomeController
{
    [HttpGet("/")]
    public async Task<IActionResult> Index()
    {
        return Inertia.Render("Index");
    }
}