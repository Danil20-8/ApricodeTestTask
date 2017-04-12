using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Politics.Model;
using Politics.Data.Infrastructure;

namespace Politics.Service
{
    public interface IOrderService
    {
        void CreateOrder(Order order);

        Order GetOrder(int id);
        IEnumerable<Order> GetOrdersOf(int regionId);
        IEnumerable<Order> GetOrdersIn(int regionId);
        IEnumerable<Region> GetRegions(Order order);
    }

    public class OrderService : IOrderService
    {
        IOrderRepository ordersRepository;
        IRegionRepository regionsRepository;

        IUnitOfWork unitOfWork;

        public OrderService(IOrderRepository ordersRepository, IRegionRepository regionsRepository, IUnitOfWork unitOfWork)
        {
            this.ordersRepository = ordersRepository;
            this.regionsRepository = regionsRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateOrder(Order order)
        {
            ordersRepository.Add(order);
            unitOfWork.Commit();
        }

        public Order GetOrder(int id)
        {
            var order = ordersRepository.GetByID(id);
            if (order != null)
                return order;
            else
                throw new OrderIsNotExistException(id);
        }

        public IEnumerable<Order> GetOrdersOf(int regionId)
        {
            return ordersRepository.GetMany(o => o.RegionID == regionId);
        }
        public IEnumerable<Order> GetOrdersIn(int regionId)
        {
            var region = regionsRepository.GetByID(regionId);
            if (region != null)
            {
                var parents = region.GetParents(true).Select(r => r.RegionID);
                return ordersRepository.GetMany(o => o.Authority == region.Authority && parents.Contains(o.RegionID));
            }
            else
                throw new RegionIsNotExistException(regionId);
        }
        public IEnumerable<Region> GetRegions(Order order)
        {
            return order.Region.GetFlatten().Where(r => r.Authority == order.Authority);
        }
    }
}
