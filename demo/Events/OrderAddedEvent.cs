using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Framework.EventBus
{
    public class OrderAddedEvent : BaseEvent
    {

        public OrderEntity Order { set; get; }

    }
}
