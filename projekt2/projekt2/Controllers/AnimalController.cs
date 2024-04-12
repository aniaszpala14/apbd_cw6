using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

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
  SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
  connection.Open();
  
  return Ok();
 }
}