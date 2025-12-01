using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using TransactionManagment.DTOs;
using TransactionManagment.Interfaces;
using TransactionManagment.Models;

namespace TransactionManagment.Controllers;

[ApiController]
[Route("[controller]")]    


public class TransactionController : ControllerBase
{
    private readonly ITransactionService _service;

    public TransactionController(ITransactionService service) //can also inject other things 
    {
        _service = service; // preadonly to call the interface, pass the name,
                            // create class that geat my controller which receives the interface and give a name
                            // on the method I inject the _service on the controller method an passes the interface.
    }
        
        
    // [HttpPost] 
    // public IActionResult Register()
    // {
    //     return Ok();
    // }
    //
    // [HttpDelete]
    //
    // public IActionResult Delete()
    // {
    //     return Ok();
    // }

    [HttpPost]
    public async Task<IActionResult> ProcessTransaction([FromBody] CreateTransactionDto request)
    {

        try
        {
            var transaction = await _service.ProcessTransactionAsync(request);
            return Ok(transaction);
        }
        catch (InvalidOperationException)
        {
            return BadRequest();
        }
        catch(KeyNotFoundException)
        {
            return NotFound();
        }

 
    }
    //
    // public decimal TargetAmount { get; set; }
    //
    // public  Guid FinancialId { get; set; }
    //
    // public TransactionDepositEnum DepositOrWithdraw { get; set; }
    //
    // [HttpGet ("{id}")]
    // public IActionResult Details()
    // {
    //     return Ok();
    // }
    //

    
}