GUDINA ASEFA
UGR/8011/13

# Pokedex API

## Overview
This project is a simple API for managing Pokémon data using ASP.NET Core and MongoDB. It provides endpoints to interact with a Pokémon database, allowing clients to perform CRUD operations.

## Features
- Asynchronous handling of requests using ASP.NET Core.
- MongoDB integration for data storage.
- Swagger UI for API documentation and testing.
- Logging configuration for monitoring application behavior.

## Technologies Used
- **ASP.NET Core**: Framework for building web applications.
- **MongoDB**: NoSQL database for storing Pokémon data.
- **C#**: Programming language used for developing the API.
- **Swagger**: Tool for API documentation.

## Getting Started

### Prerequisites
- [.NET SDK 9.0](https://dotnet.microsoft.com/download) installed on your machine.
- [MongoDB](https://www.mongodb.com/try/download/community) installed and running.

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/Gude-asefa/making-asynchronous-calls.git
   ```
2. Navigate to the project directory:
   ```bash
   cd pokedex
   ```

3. Restore the dependencies:
   ```bash
   dotnet restore
   ```

### Configuration
Before running the application, you need to configure the MongoDB settings in the `appsettings.json` file. The default settings are:

```json
"MongoDB": {
  "ConnectionString": "mongodb://localhost:27017",
  "DatabaseName": "PokedexDB",
  "PokemonCollectionName": "Pokemons"
}
```

Make sure your MongoDB instance is running and the database is set up accordingly.

## Usage
To run the application, use the following command:

```bash
dotnet run
```

You can access the API documentation via Swagger by navigating to `http://localhost:<port>/swagger` in your web browser.

### Endpoints
- **GET /api/pokemons**: Retrieve all Pokémon.
- **POST /api/pokemons**: Add a new Pokémon.
- **GET /api/pokemons/{id}**: Retrieve a Pokémon by ID.
- **PUT /api/pokemons/{id}**: Update a Pokémon by ID.
- **DELETE /api/pokemons/{id}**: Delete a Pokémon by ID.

