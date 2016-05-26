using StreamOneInterface.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamOneInterface.Models.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Order> OrderRepository { get; }
        IRepository<OrderRow> OrderRowRepository { get; }
        IRepository<Reseller> ResellerRepository { get; }
        IRepository<Product> ProductRepository { get; }
       
        void Save();
    }
}
