using StreamOneInterface.Models.Abstract;
using StreamOneInterface.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;

namespace StreamOneInterface.Models.DAL
{
    internal  class UnitOfWork : IUnitOfWork
    {

        //Fields
        private ApplicationDbContext _context = new ApplicationDbContext();

        private IRepository<Order> _orderRepository;
        private IRepository<OrderRow> _orderRowRepository;
        private IRepository<Reseller> _resellerRepository;


        public IRepository<Order> OrderRepository
        {
            get
            {
                return _orderRepository ?? (_orderRepository = new Repository<Order>(_context));
            }
        }
        public IRepository<OrderRow> OrderRowRepository
        {
            get
            {
                return _orderRowRepository ?? (_orderRowRepository = new Repository<OrderRow>(_context));
            }
        }
        public IRepository<Reseller> ResellerRepository
        {
            get
            {
                return _resellerRepository ?? (_resellerRepository = new Repository<Reseller>(_context));
            }
        }


        /// <summary>
        /// Saves changes to Database from which Entities are mapped
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }

        #region IDisposable

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}