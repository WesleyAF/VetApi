using Microsoft.EntityFrameworkCore;
using VetApi.Data;
using VetApi.Interfaces.Repositories;
using VetApi.Models;

namespace VetApi.Repositories
{
    public class AnimalRepository : Repository<AnimalModel>, IAnimalRepository
    {
        private readonly AppDbContext _context;
        public AnimalRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<AnimalModel?> ListConsultasByAnimal(int Id)
        {
           return await _context.Animals.Include(a => a.Consultas).FirstOrDefaultAsync(animal => animal.Id == Id);
        }
    }
}
