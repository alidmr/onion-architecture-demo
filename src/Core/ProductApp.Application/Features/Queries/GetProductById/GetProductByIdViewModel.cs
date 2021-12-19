using System;

namespace ProductApp.Application.Features.Queries.GetProductById
{
    public class GetProductByIdViewModel
    {
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public String Name { get; set; }

        public decimal Amount { get; set; }

        public int Quantity { get; set; }
    }
}
