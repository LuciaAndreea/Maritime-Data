using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MaritimeData.Models;

[Route("api/[controller]")]
[ApiController]

public class PortsController : ControllerBase{
    private readonly ApplicationDbContext _context;

    public PortsController(ApplicationDbContext context){
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Port>>> GetPorts(){
        return await _context.Ports.ToListAsync();
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<Port>> GetPort(int id){
        var port = await _context.Ports.FindAsync(id);

        if(port == null){
            return NotFound();
        }

        return port;
    }

    [HttpPost]
    public async Task<ActionResult<Port>> PostPort(Port port){
        _context.Ports.Add(port);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPort", new {id = port.Id}, port);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPort(int id, Port port){
        if(id != port.Id){
            return BadRequest();
        }

        _context.Entry(port).State = EntityState.Modified;

        try{
            await _context.SaveChangesAsync();
        } catch(DbUpdateConcurrencyException){
            if(!PortExists(id)){
                return NotFound();
            }
            else{
                throw;
            }
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePort(int id){
        var port = await _context.Ports.FindAsync(id);
        if(port == null){
            return NotFound();
        }

        _context.Ports.Remove(port);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PortExists(int id){
        return _context.Ports.Any(e => e.Id == id);
    }
}

