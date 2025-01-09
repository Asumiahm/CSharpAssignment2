using pokedex.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pokedex.Services
{
    public interface IPokemonService
    {
        Task<List<Pokemon>> GetAllPokemonAsync();
        Task<Pokemon> GetPokemonByIdAsync(string id);
        Task<Pokemon> AddPokemonAsync(Pokemon newPokemon);
        Task<Pokemon> UpdatePokemonAsync(string id, Pokemon updatedPokemon);
        Task<bool> DeletePokemonAsync(string id);
    }
}