using MongoDB.Driver;
using pokedex.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
    
namespace pokedex.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IMongoCollection<Pokemon> _pokemonCollection;

        public PokemonService(IConfiguration configuration)
        {
            var mongoSettings = configuration.GetSection("MongoDB");
            var client = new MongoClient(mongoSettings["ConnectionString"]);
            var database = client.GetDatabase(mongoSettings["DatabaseName"]);
            _pokemonCollection = database.GetCollection<Pokemon>("Pokemons");
        }
        // Add new Pokemon, ensuring ID is not set manually
      public async Task<Pokemon> AddPokemonAsync(Pokemon newPokemon)
        {
           await _pokemonCollection.InsertOneAsync(newPokemon); 
           return newPokemon;
        }
        // Get all Pokemons
        public async Task<List<Pokemon>> GetAllPokemonAsync()
        {
            return await _pokemonCollection.Find(p => true).ToListAsync();
        }

        // Get Pokemon by ID, handling string ID correctly
        public async Task<Pokemon> GetPokemonByIdAsync(string id) {
            return await _pokemonCollection.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        // Update existing Pokemon by ID
        public async Task<Pokemon> UpdatePokemonAsync(string id, Pokemon updatedPokemon)
        {
           await _pokemonCollection.ReplaceOneAsync(pM => pM.Id == id, updatedPokemon);
            return updatedPokemon;
        }

        // Delete Pokemon by ID
        public async Task<bool> DeletePokemonAsync(string id)
        {
            var deleteResult = await _pokemonCollection.DeleteOneAsync(p => p.Id == id);
            return deleteResult.DeletedCount > 0;
        }
    }
}