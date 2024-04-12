using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using projekt2.Models;
using projekt2.Models.DTOs;
using projekt2.Repositories;

namespace projekt2.Controllers;
[ApiController]
[Route("aniapi/animals")]
public class AnimalController : Controller
{
 private readonly IAnimalRepository _animalRepository;
 public AnimalController(IAnimalRepository animalRepository)
 {
  _animalRepository = animalRepository;
 }
 
 [HttpGet]
 public IActionResult GetAnimals()
 {
  var animals = _animalRepository.GetAnimals();//tak powinno byc
  
  return Ok(animals);
 }

 [HttpPost]
 public IActionResult AddAnimal(AddAnimal animal)
 {
  // //Otwieramy polaczenie do bazy
  // using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
  // connection.Open();
  // //Definicja commanda
  // using SqlCommand command = new SqlCommand();
  // command.Connection = connection;
  // command.CommandText = "INSERT INTO Animal VALUES(@animalName,'','','')";
  // command.Parameters.AddWithValue("@animalName", animal.Name);
  //
  // command.ExecuteNonQuery();


_animalRepository.AddAnimal(animal);
  return Created("", null);
 }
 
 
 
 
 
 
}