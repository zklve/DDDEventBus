using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.X.EventBus
{
    public delegate void Handler();

    public class OrderEventBus
    {
        private readonly OrderEntity _order;

        public event Handler CreateOrderHandler;

        public OrderEventBus(OrderEntity order)
        {
            _order = order;
            CreateOrderHandler += _order.Handle;
        }

        public void Publish()
        {
            CreateOrderHandler();
        }

    }
}
