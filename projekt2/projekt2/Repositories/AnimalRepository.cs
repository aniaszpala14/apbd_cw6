using Microsoft.Data.SqlClient;
using projekt2.Models;
using projekt2.Models.DTOs;

namespace projekt2.Repositories;

public class AnimalRepository : IAnimalRepository
{

    public readonly IConfiguration _configuration;

    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public IEnumerable<Animal> GetAnimals()
    {
        //Otwieramy polaczenie do bazy
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();
        //Definicja commanda
        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM Animal;";
  
        //wykonanie
        var reader = command.ExecuteReader();
        var animals = new List<Animal>();
        int idAnimalOrdinal = reader.GetOrdinal("IdAnimal");
        int nameOrdinal = reader.GetOrdinal("Name");
  
        while (reader.Read())
        {
            animals.Add(new Animal()
            {
                IdAnimal=reader.GetInt32(idAnimalOrdinal),
                Name=reader.GetString(nameOrdinal)      // inna opcja reader["IdAnimal"].ToString()
    
            });
        }
   
    }

    void AddAnimal(AddAnimal animal)
    {
        //Otwieramy polaczenie do bazy
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();
        //Definicja commanda
        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "INSERT INTO Animal VALUES(@animalName,'','','')";
        command.Parameters.AddWithValue("@animalName", animal.Name);

        command.ExecuteNonQuery();
        
    }
}