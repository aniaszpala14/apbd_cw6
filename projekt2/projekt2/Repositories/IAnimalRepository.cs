using projekt2.Models;
using projekt2.Models.DTOs;

namespace projekt2.Repositories;

public interface IAnimalRepository
{
    IEnumerable<Animal> GetAnimals();
    void AddAnimal(AddAnimal animal);
    
}