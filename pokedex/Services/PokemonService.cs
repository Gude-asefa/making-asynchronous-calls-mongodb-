using pokedex.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace pokedex.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IMongoCollection<Pokemon> _pokemonCollection;

        public PokemonService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            var mongoClient = new MongoClient(mongoDBSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _pokemonCollection = mongoDatabase.GetCollection<Pokemon>(mongoDBSettings.Value.PokemonCollectionName);
        }
        // Method to retrieve all Pokémon from the collection

        public async Task<List<Pokemon>> GetPokemons()
        {
            return await _pokemonCollection.Find(_ => true).ToListAsync();
        }
  // Method to retrieve a Pokémon by its ID
        public async Task<Pokemon> GetPokemonById(string id)
        {
            var pokemon = await _pokemonCollection.Find(p => p.Id == id).FirstOrDefaultAsync();
            if (pokemon == null)
                throw new Exception("Pokemon not found");
            return pokemon;
        }
      // Method to retrieve a Pokémon by its name
        public async Task<Pokemon> GetPokemonByName(string name)
        {
            var pokemon = await _pokemonCollection.Find(p => p.Name == name).FirstOrDefaultAsync();
            if (pokemon == null)
                throw new Exception("Pokemon not found");
            return pokemon;
        }
             // Method to add a new Pokémon to the collection
        public async Task<Pokemon> AddPokemon(Pokemon newPokemon)
        {
            await _pokemonCollection.InsertOneAsync(newPokemon);
            return newPokemon;
        }
         // Method to update an existing Pokémon by its ID

        public async Task<Pokemon> UpdatePokemon(string id, Pokemon updatedPokemon)
        {
            var result = await _pokemonCollection.ReplaceOneAsync(p => p.Id == id, updatedPokemon);
            if (result.MatchedCount == 0)
                throw new Exception("Pokemon not found");
            return updatedPokemon;
        }
        // Method to delete a Pokémon by its ID

        public async Task<bool> DeletePokemon(string id)
        {
            var result = await _pokemonCollection.DeleteOneAsync(p => p.Id == id);
            if (result.DeletedCount == 0)
                throw new Exception("Pokemon not found");
            return true;
        }
    }
}
