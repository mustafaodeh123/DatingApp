using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ValuesController : ControllerBase
  {
    private readonly DataContext context;
    public ValuesController(DataContext context)
    {
      this.context = context;
    }

    // GET api/values
    [HttpGet]
    public async Task<IActionResult> GetValues()
    {
      return Ok(await context.Values.ToListAsync());
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetValue(int id)
    {
      return Ok(await context.Values.FirstOrDefaultAsync(v => v.Id == id));
    }

    // POST api/values
    [HttpPost]
    public ActionResult<string> Post([FromBody] string value)
    {
      return "post - api call";
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
