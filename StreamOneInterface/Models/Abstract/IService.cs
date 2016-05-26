using StreamOneInterface.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamOneInterface.Models.Abstract
{
    public interface IService
    {
        //CRUD Order and OrderRow
        bool UpdateOrder(Order order);
        bool UpdateOrderRow(OrderRow orderRow);
        bool InsertOrder(Order order);
        bool InsertOrderRow(OrderRow orderRow);
        List<Order> GetAllOrders();
        //List<OrderRow> GetAllOrderRows();
        List<OrderRow> GetOrderRows(int id);
        Order GetOrder(int id);
        OrderRow GetAllOrderRows(int orderId, int orderRowId);

        //CRUD Reseller entity
        bool DeleteReseller(Reseller reseller);
        bool UpdateReseller(Reseller reseller);
        bool InsertReseller(Reseller reseller);
        List<Reseller> GetAllResellers();
        //List<Reseller> GetAllResellersBasedOnAlphabet();
        Reseller GetReseller(int id);
        Reseller GetResellerByS1ID(string s1id); //Get Reseller by StreamOne reseller ID

        //Product
        Product GetActiveProductByS1ID(string s1id); //Get active product by StreamOne ID

    }
}
