using StreamOneInterface.Models.Abstract;
using StreamOneInterface.Models.DAL;
using StreamOneInterface.Models.Entities;
using StreamOneInterface.Models.Webservices;
using StreamOneInterface.Models.Webservices.APIFacade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreamOneInterface.Models
{
    public class Service : IService 
    {
        private readonly ISettings _settings;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IProvisioningWebService _provisioningWebService;
        //private readonly ICancellationWebService _cancellationWebService;

        //Constructors
        public Service()
            //: this(new Settings(true), new UnitOfWork(), new ProvisioningWebService(), new CancellationWebService())
            : this(new Settings(true), new UnitOfWork())
        {
            // Empty
        }

        //public Service(Settings settings, IUnitOfWork unitOfWork, IProvisioningWebService provisioningWebService, ICancellationWebService cancellationWebService)
        public Service(Settings settings, IUnitOfWork unitOfWork)
        {
            _settings = settings;
            _unitOfWork = unitOfWork;
           // _provisioningWebService = provisioningWebService;
            //_cancellationWebService = cancellationWebService;
            _settings.Save();
        }

        #region Webservice functionality
        public APIFacadeOrder POSTProvisionalOrder(string token, string json)
        {
            ProvisioningWebService _provisioningWebService = new ProvisioningWebService();
            APIFacadeOrder APIOrder = new APIFacadeOrder();
            APIOrder = _provisioningWebService.ProvisionApp(token, json);
            return APIOrder;
        }

        public void POSTCancellationOrder(string token, string json)
        {
            CancellationWebService _cancellationWebService = new CancellationWebService();
            _cancellationWebService.CancelSubscription(token, json);
            return;
        }
        #endregion

        #region Database functionality

        public OrderRow GetOrderRowByItemId(string itemId)
        {
            OrderRow orderRow = _unitOfWork.OrderRowRepository.Get(c => c.ItemID == itemId).FirstOrDefault();
            return orderRow;
        }

        public Product GetActiveProductByS1ID(string s1id)
        {
            Product product = _unitOfWork.ProductRepository.Get(c => c.StreamOneNumber == s1id && c.Active == true).FirstOrDefault();
            return product;
        }
        public Reseller GetResellerByS1ID(string s1id)
        {
            Reseller reseller = _unitOfWork.ResellerRepository.Get(c => c.CustomerID == s1id).FirstOrDefault();
            return reseller;
        }

        public Order GetOrder(int id)
        {
            Order order = _unitOfWork.OrderRepository.Get(c => c.Id == id).FirstOrDefault();
            return order;
        }
        public Reseller GetReseller(int id)
        {
            Reseller reseller = _unitOfWork.ResellerRepository.Get(c => c.Id == id).FirstOrDefault();
            return reseller;
        }

        public OrderRow GetAllOrderRows(int orderId, int orderRowId)
        {
            var returnValue = _unitOfWork.OrderRowRepository.Get(o => o.Order.Id == orderId && o.Id == orderRowId).FirstOrDefault();
            return returnValue;
        }
        public List<OrderRow> GetOrderRows(int orderId)
        {
            var returnValue = _unitOfWork.OrderRowRepository.Get(o => o.Order.Id == orderId).ToList();
            return returnValue;
        }

        public List<OrderRow> GetAllOrderRows()
        {
            var returnValue = _unitOfWork.OrderRowRepository.Get().ToList();
            return returnValue;
        }
        public List<Order> GetAllOrders()
        {
            var returnValue = _unitOfWork.OrderRepository.Get().ToList();
            return returnValue;
        }
        public List<Reseller> GetAllResellers()
        {
            var returnValue = _unitOfWork.ResellerRepository.Get().ToList();
            return returnValue;
        }


        public bool UpdateOrder(Order order)
        {
            try
            {
                _unitOfWork.OrderRepository.Update(order);
                _unitOfWork.Save();
                return true;
            }
            catch { }

            return false;
        }


        public bool UpdateOrderRow(OrderRow orderRow)
        {
            try
            {
                _unitOfWork.OrderRowRepository.Update(orderRow);
                _unitOfWork.Save();
                return true;
            }
            catch { }

            return false;
        }

        public bool UpdateReseller(Reseller reseller)
        {
            try
            {
                _unitOfWork.ResellerRepository.Update(reseller);
                _unitOfWork.Save();
                return true;
            }
            catch { }

            return false;
        }

        public bool DeleteReseller(Reseller reseller)
        {
            try
            {
                _unitOfWork.ResellerRepository.Delete(reseller);
                _unitOfWork.Save();
                return true;
            }
            catch { }

            return false;
        }

        public bool InsertOrder(Order order)
        {
            try
            {
                _unitOfWork.OrderRepository.Insert(order);
                _unitOfWork.Save();
                return true;
            }
            catch { }

            return false;
        }
        public bool InsertOrderRow(OrderRow orderRow)
        {
            try
            {
                _unitOfWork.OrderRowRepository.Insert(orderRow);
                _unitOfWork.Save();
                return true;
            }
            catch { }

            return false;
        }
        public bool InsertReseller(Reseller reseller)
        {
            try
            {
                _unitOfWork.ResellerRepository.Insert(reseller);
                _unitOfWork.Save();
                return true;
            }
            catch { }

            return false;
        }

        #endregion
    }
}