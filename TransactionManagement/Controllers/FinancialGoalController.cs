using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using TransactionManagment.DTOs;
using TransactionManagment.Interfaces;
using TransactionManagment.Models;


namespace TransactionManagment.Controllers;

[ApiController]
[Route("[controller]")]

public class FinancialGoalController : ControllerBase
{

    private readonly IFinancialGoalService _service;  //calling the service DI here xD

    public FinancialGoalController(IFinancialGoalService service) //passing the service as parameter
    {
        _service = service;
        
    }

    [HttpPost] //Do not put id as this comes from my db. 
    public async Task<IActionResult> Register([FromBody] CreateGoalInputDto request)

    {
        var createdGoal = await _service.CreateGoalAsync(request);

        return CreatedAtAction(nameof(Details), new
        {
            id = createdGoal.Id
        }, createdGoal);
    }   

    [HttpPut("{id}")]
    //No update, chama iactionresult, dentro do obj update tem q passar o id q quer atualizar,
    // vai na no frombody
    public async Task <IActionResult> Update(Guid id, [FromBody] UpdateGoalInputDto request) //should return200
    
    {
        try
        {
            var updated = await _service.UpdateAsync(request, id);
            return Ok(updated);
        }
        catch(KeyNotFoundException)
        {
            //waits a objetct, i can use a n middleware for erros treatment as well.
            //or instance a new message for json
            //return NotFound(new { message = ex.Message }); // 404 if not found.

            return NotFound(); 
        }
    }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            try 
            {
                await _service.DeleteAsync(id);

                return NoContent();
            }
            catch(KeyNotFoundException)
            {
                return NotFound();
            }
        }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        
        {
            var goals = await _service.GetAllGoalsAsync();
            
            var dtos = goals.Select(g => new GoalSummaryDto
            {
                Id = g.Id,
                Title = g.Title,
                TargetAmount = g.TargetAmount,
                CurrentBalance = g.CurrentBalance

            }).ToList();

            return Ok(dtos);
        }
        
    } 

    [HttpGet("{id}")]
    public async Task<IActionResult> Details(Guid id)
    {
        try
        {
            var details = await _service.GetByIdAsync(id);
            return Ok(details); //Must return the object  created on when accessing the db and the method getbyid.
        }
        catch(KeyNotFoundException)
        {
            return NotFound();
        }
        
    }
    
    
    
    
}