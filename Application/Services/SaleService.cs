using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _repository;

        public SaleService(ISaleRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Sale> GetAll() => _repository.GetAll();

        public Sale GetById(int id) => _repository.GetById(id);

        public Sale Create(Sale sale)
        {
            ApplyDiscounts(sale);
            _repository.Add(sale);
            _repository.SaveChanges();
            LogEvent("SaleCreated", sale);
            return sale;
        }

        public Sale Update(int id, Sale sale)
        {
            var existing = _repository.GetById(id);
            if (existing == null) throw new Exception("Sale not found");

            existing.Date = sale.Date;
            existing.Customer = sale.Customer;
            existing.Branch = sale.Branch;
            existing.Items = sale.Items;
            ApplyDiscounts(existing);
            _repository.Update(existing);
            _repository.SaveChanges();
            LogEvent("SaleModified", existing);
            return existing;
        }

        public void Cancel(int id)
        {
            var sale = _repository.GetById(id);
            if (sale == null) throw new Exception("Sale not found");

            sale.IsCancelled = true;
            _repository.SaveChanges();
            LogEvent("SaleCancelled", sale);
        }

        private void ApplyDiscounts(Sale sale)
        {
            foreach (var item in sale.Items)
            {
                if (item.Quantity > 20) throw new Exception("Cannot sell more than 20 identical items");

                if (item.Quantity >= 10)
                    item.Discount = 0.2m;
                else if (item.Quantity >= 4)
                    item.Discount = 0.1m;
                else
                    item.Discount = 0m;

                item.TotalAmount = item.Quantity * item.UnitPrice * (1 - item.Discount);
            }

            sale.TotalAmount = sale.Items.Sum(i => i.TotalAmount);
        }

        private void LogEvent(string eventName, Sale sale)
        {
            Console.WriteLine($"Event: {eventName}, Sale ID: {sale.Id}, Sale Number: {sale.SaleNumber}");
        }
    }
}