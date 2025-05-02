using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MaritimeData.Models;

[Route("api/[controller]")]
[ApiController]

public class CountriesVisitedController : ControllerBase{
    private readonly ApplicationDbContext _context;
    public CountriesVisitedController(ApplicationDbContext context){
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CountryVisited>>> GetCountriesVisited(){
        var countries = await _context.CountriesVisited.ToListAsync();
        if(countries == null || !countries.Any()){
            return NotFound("No countries found.");
        }
        return countries;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CountryVisited>> GetCountryVisited(int id){
        var countryvisited = await _context.CountriesVisited.FindAsync();

        if(countryvisited == null){
            return NotFound();
        }

        return countryvisited;
    }

    [HttpPost]
    public async Task<ActionResult<CountryVisited>> PostCountryVisited(CountryVisited countryVisited){
        _context.CountriesVisited.Add(countryVisited);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCountryVisited", new {id = countryVisited.Id} , countryVisited);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCountryVisited(int id, CountryVisited countryVisited){
        if(id != countryVisited.Id){
            return BadRequest();
        }

        _context.Entry(countryVisited).State = EntityState.Modified;

        try{
            await _context.SaveChangesAsync();
        } catch(DbUpdateConcurrencyException){
            if(!CountryVisitedExisted(id)){
                return NotFound();
            }else{
                throw;
            }
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCountryVisited(int id){
        var countryVisited = await _context.CountriesVisited.FindAsync(id);
        if(countryVisited == null){
            return NotFound();
        }

        _context.CountriesVisited.Remove(countryVisited);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CountryVisitedExisted(int id){
        return _context.CountriesVisited.Any(e => e.Id == id);
    }
}