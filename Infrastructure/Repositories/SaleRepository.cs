using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly SalesDbContext _context;

        public SaleRepository(SalesDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Sale> GetAll() => _context.Sales.Include(s => s.Items).ToList();

        public Sale GetById(int id) => _context.Sales.Include(s => s.Items).FirstOrDefault(s => s.Id == id);

        public void Add(Sale sale) => _context.Sales.Add(sale);

        public void Update(Sale sale) => _context.Sales.Update(sale);

        public void SaveChanges() => _context.SaveChanges();
    }
}