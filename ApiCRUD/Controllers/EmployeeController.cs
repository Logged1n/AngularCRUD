using ApiCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiCRUD.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _employee;
    private readonly IWebHostEnvironment _env;

    public EmployeeController(IEmployeeRepository employee, IWebHostEnvironment env)
    {
        _employee = employee ?? throw new ArgumentNullException(nameof(employee));
        _env = env ?? throw new ArgumentNullException(nameof(env));
    }

    [HttpGet("GetEmployee")]
    public async Task<IActionResult> Get()
    {
        return Ok(await _employee.GetEmployees());
    }

    [HttpGet("GetEmployeeByID/{Id}")]
    public async Task<IActionResult> GetEmpByID(int Id)
    {
        return Ok(await _employee.GetEmployeeById(Id));
    }

    [HttpPost("AddEmployee")]
    public async Task<IActionResult> Post(Employee? emp)
    {
        var result = await _employee.InsertEmployee(emp);
        return Ok("Added Successfully");
    }

    [HttpPut("UpdateEmployee")]
    public async Task<IActionResult> Put(Employee emp)
    {
        await _employee.UpdateEmployee(emp);
        return Ok("Updated Successfully");
    }

    [HttpDelete("DeleteEmployee/{id}")]
    public IActionResult Delete(int id)
    {
        var result = _employee.DeleteEmployee(id);
        return Ok("Deleted Successfully");
    }
    
}