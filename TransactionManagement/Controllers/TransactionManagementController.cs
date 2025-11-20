using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace TransactionManagment.Controllers;

[ApiController]
[Route("{controller}")]


public class TransactionManagementController : ControllerBase
{
    [HttpPost]

    public IActionResult Register()
    {
        return Ok();
    }

    [HttpDelete]

    public IActionResult Delete()
    {
        return Ok();
    }

    [HttpGet]
    public IActionResult List()
    {
        return Ok();
    }

    [HttpGet ("{id}")]
    public IActionResult Details()
    {
        return Ok();
    }
    

    
}