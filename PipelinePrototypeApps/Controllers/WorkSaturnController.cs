using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

namespace PipelineAppSun.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkSaturnController : ControllerBase
{
    // POST api/items
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] string requestJson)
    {
        Console.WriteLine($"Request as string: {requestJson}");
        string? request = JsonSerializer.Deserialize<string>(requestJson);   
        if (requestJson.Length < 1 || request == null)
        {
            return BadRequest("Input is required.");
        }
        var duodecimalRegex = new Regex(@"^[0-9xXeE]{12}$");
        if (!duodecimalRegex.IsMatch(request))
        {
            return BadRequest("Input is not a 12 digit duodecimal number.");
        }

        string result = await WorkSaturn.InvokeAsyncWork(request);
        Console.WriteLine($"Amount of attempts: {result}");

        return Ok(result);
    }

    // GET api/WorkSaturn
    //[HttpGet]
    //public IActionResult Get()
    //{
    //    var items = new[] { "hash1", "hash2", "hash3" };
    //    return Ok(items);
    //}

    // GET api/WorkSaturn/5
    //[HttpGet("[action]/{id:int}")]
    //public IActionResult Get(int id)
    //{
    //    return Ok(new { Id = id, Value = $"hash{id}" });
    //}
}