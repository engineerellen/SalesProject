using Domain.Entities;

namespace Application.Interfaces
{
    public interface ISaleService
    {
        IEnumerable<Sale> GetAll();
        Sale GetById(int id);
        Sale Create(Sale sale);
        Sale Update(int id, Sale sale);
        void Cancel(int id);
    }
}