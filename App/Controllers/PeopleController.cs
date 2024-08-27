namespace App.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PeopleController : ControllerBase 
{
    public IActionResult Index() => Ok("Hello World!");
}