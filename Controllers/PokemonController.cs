using Microsoft.AspNetCore.Mvc;
using pokedex.Models;
using pokedex.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pokedex.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }
        [HttpPost]
        public async Task<ActionResult<Pokemon>> AddPokemon(Pokemon newPokemon)
        {
            try{
                await _pokemonService.AddPokemonAsync(newPokemon);
                return Ok("Pokeman added successfully");
            }
            catch{
                return BadRequest("Failed to add Pokeman");
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<Pokemon>>> GetAllPokemons()
        {
            try{
                return Ok(await _pokemonService.GetAllPokemonAsync());
            }
            catch{
                return NotFound("No pokeman found");
            }   
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pokemon>> GetPokemonById(string id)
        {
             try{
                return Ok(await _pokemonService.GetPokemonByIdAsync(id));
            }
            catch{
                return NotFound("Pokeman not found");
            }
        }

       

        [HttpPut("{id}")]
        public async Task<ActionResult<Pokemon>> UpdatePokemon(string id, Pokemon updatedPokemon)
        {
             try{
                await _pokemonService.UpdatePokemonAsync(id, updatedPokemon);
                return Ok("pokeman updated successfully");
            }
            catch{
                return NotFound("pokeman not found");
            }  
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeletePokemon(string id)
        {
             var result = await _pokemonService.DeletePokemonAsync(id);
    if (result)
    {
        return Ok("Deleted successfully");
    }
    else
    {
        return NotFound("Pokemon not found");
    }
        }
    }
}