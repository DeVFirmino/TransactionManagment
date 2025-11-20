using Microsoft.AspNetCore.Mvc;


namespace TransactionManagment.Controllers;

[ApiController]

[Route("api/[controller]")]

public class FinancialGoalController : ControllerBase
{
    [HttpPost]
    public IActionResult Register()
    {
        return Ok();

    }

    [HttpPut]
    public IActionResult Update()
    {
        return Ok();
    }

    [HttpDelete]
    public IActionResult Remove()
    {
        return Ok();
    }

    [HttpGet]
    public IActionResult List()
    {
        return Ok();
    } 

    [HttpGet("{id}")]
    public IActionResult Details()
    {
        return Ok();
    }
    
    
    
    
}