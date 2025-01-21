using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ISaleRepository
    {
        IEnumerable<Sale> GetAll();
        Sale GetById(int id);
        void Add(Sale sale);
        void Update(Sale sale);
        void SaveChanges();
    }
}