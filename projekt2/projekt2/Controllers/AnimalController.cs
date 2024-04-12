using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using projekt2.Models;
using projekt2.Models.DTOs;

namespace projekt2.Controllers;
[ApiController]
[Route("aniapi/animals")]
public class AnimalController : Controller
{
 private readonly IConfiguration _configuration;
 public AnimalController(IConfiguration configuration)
 {
  _configuration = configuration;
 }
 
 [HttpGet]
 public IActionResult GetAnimals()
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
  return Ok(animals);
 }

 [HttpPost]
 public IActionResult AddAnimal(AddAnimal animal)
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



  return Created("", null);
 }
 
 
 
 
 
 
}