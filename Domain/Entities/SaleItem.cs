﻿namespace Domain.Entities
{
    public class SaleItem
    {
        public int Id { get; set; }
        public string Product { get; set; }=string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}