using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShakirovTranspComp.OrderClasses
{
    public abstract class RequestCreator
    {
        protected int idOrder;
        public abstract IRequest FactoryMethod();
        public abstract int CalculatePrice();

        public async Task<Order> InitializeRequestAsync(DateTime d, Transport t, Client c)
        {
            Order newOrder = await Task.Run(() =>
            DataBase.GetContext().Order.Add
            (
                new Order
                {
                    date = d,
                    price = CalculatePrice(),
                    car = t.id,
                    Client = c
                }
            ));

            DataBase.SaveChanges();
            
            idOrder = newOrder.id;

            return newOrder;
        }
    }
}
