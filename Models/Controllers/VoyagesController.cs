using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MaritimeData.Models;

[Route("api/[controller]")]
[ApiController]

public class VoyagesController : ControllerBase{

    private readonly ApplicationDbContext _context;
    public VoyagesController(ApplicationDbContext context){
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Voyage>>> GetVoyages(){
        return await _context.Voyages.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Voyage>> GetVoyage(int id){
        var voyage = await _context.Voyages.FindAsync();

        if(voyage == null){
            return NotFound();
        }

        return voyage;
    }

    [HttpPost]
    public async Task<ActionResult<Voyage>> PostVoyage(Voyage voyage){
        _context.Voyages.Add(voyage);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetVoyage", new {id = voyage.Id}, voyage);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutVoyage(int id, Voyage voyage){
        if(id != voyage.Id){
            return BadRequest();
        }

        _context.Entry(voyage).State = EntityState.Modified;
        try{
            await _context.SaveChangesAsync();
        } catch(DbUpdateConcurrencyException){
            if(!VoyageExists(id)){
                return NotFound();
            }else{
                throw;
            }
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVoyage(int id){
        var voyage = await _context.Voyages.FindAsync(id);
        if(voyage == null){
            return NotFound();
        }

        _context.Voyages.Remove(voyage);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool VoyageExists(int id){
        return _context.Voyages.Any(e => e.Id == id);
    }
}