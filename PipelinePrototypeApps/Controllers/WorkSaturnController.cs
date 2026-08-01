using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

namespace PipelineAppSun.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkSaturnController : ControllerBase
{
    // POST api/items
    [HttpPost]
    public IActionResult Post([FromBody] string request)
    {
        var duodecimalRegex = new Regex(@"^[\dxXeE]{12}$");
        if (!(request.Length < 1)|| request.IsWhiteSpace())
        {
            return BadRequest("Input is required.");
        }
        if (!duodecimalRegex.IsMatch(request))
        {
            return BadRequest("Input is not a 12 digit duodecimal number.");
        }
        
        string result = WorkSaturn.InvokeAsyncWork(request).GetAwaiter().GetResult();
        
        return CreatedAtAction(nameof(Get), new { id = 1 }, result); //need to handle the identifiers of each work call
    }
    
    // GET api/items
    [HttpGet]
    public IActionResult Get()
    {
        var items = new[] { "hash1", "hash2", "hash3" };
        return Ok(items);
    }

    // GET api/items/5
    [HttpGet("[action]/{id:int}")]
    public IActionResult Get(int id)
    {
        return Ok(new { Id = id, Value = $"hash{id}" });
    }
}