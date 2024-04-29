using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Repositories
{
    public class CarWorkshopRepository : ICarWorkshopRepository
    {
        private readonly CarWorkshopDbContext _dbContext;
        public CarWorkshopRepository(CarWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Domain.Entities.CarWorkshop carWorkshop)
        {
            _dbContext.Add(carWorkshop);
            await _dbContext.SaveChangesAsync();
        }

        public Task<Domain.Entities.CarWorkshop?> GetByName(string name)
         => _dbContext.CarWorkshops.FirstOrDefaultAsync(cw => cw.Name.ToLower() == name.ToLower());

        public async Task<IEnumerable<Domain.Entities.CarWorkshop?>> GetAll()
         => await _dbContext.CarWorkshops.ToListAsync();

        public async Task<Domain.Entities.CarWorkshop> GetByEncodedName(string encodedName)
         => await _dbContext.CarWorkshops.FirstAsync(cw => cw.EncodedName == encodedName);

        public async Task<Domain.Entities.CarWorkshop> Edit(Domain.Entities.CarWorkshop carWorkshop)
        {
            var item = await _dbContext.CarWorkshops.FirstOrDefaultAsync(cw => cw.Id == carWorkshop.Id);
            item.Update(carWorkshop);
            _dbContext.Update(item);
            await _dbContext.SaveChangesAsync();

            return item;
        }
        public Task Commit()
         => _dbContext.SaveChangesAsync();
    }
}
