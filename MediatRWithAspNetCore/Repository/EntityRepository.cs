using MediatRWithAspNetCore.Entities;
using System.Collections.Generic;

namespace MediatRWithAspNetCore.Repository
{
    public class EntityRepository
    {
        public EntityRepository()
        {
            Customers = new List<Customer>();
        }

        public List<Customer> Customers { get; set; }
    }
}
