using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MaritimeData.Models;
using Microsoft.Extensions.ObjectPool;

[Route("api/[controller]")] //define the URL where the controller is accesed
[ApiController] // transform the class into an API

public class ShipsController : ControllerBase{

    private bool ShipExists(int id){ //verify if already exists a ship with that id in db
    return _context.Ships.Any(e => e.Id == id);
}
    private readonly ApplicationDbContext _context;
    public ShipsController(ApplicationDbContext context){
        _context = context;
    }

    // GET method

    [HttpGet("{id}")]
    public async Task<ActionResult<Ship>> GetShip(int id){
        var ship = await _context.Ships.FindAsync(id);

        if(ship == null){
            return NotFound(); // if no ship was found return 404 not found
        }

        return ship; // if found return 200 OK
    }

    // POST method (add a new ship in db)

    [HttpPost]
    public async Task<ActionResult<Ship>> PostShip(Ship ship){
        _context.Ships.Add(ship);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetShip", new {id=ship.Id}, ship);
    }

    //PUT method
    [HttpPut("{id}")]
    public async Task<IActionResult> PutShip(int id, Ship ship){
        if(id != ship.Id){
            return BadRequest();
        }

        _context.Entry(ship).State = EntityState.Modified;

        try{
            await _context.SaveChangesAsync();
        } catch(DbUpdateConcurrencyException){
            if(!ShipExists(id)){
                return NotFound();
            }
            else{
                throw;
            }
        }
        return NoContent();
    }

    //DELETE method
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShip(int id){
        var ship = await _context.Ships.FindAsync(id);
        if(ship == null){
            return NotFound();
        }

        _context.Ships.Remove(ship);
        await _context.SaveChangesAsync();

        return NoContent();
    }


}