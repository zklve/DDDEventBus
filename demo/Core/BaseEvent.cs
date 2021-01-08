using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.EventBus
{
    public class BaseEvent
    {

        /// <summary>
        /// 事件发生的时间
        /// </summary>
        public DateTime EventTime { get; set; }

        /// <summary>
        /// 事件源
        /// </summary>
        public object EventSource { get; set; }


    }
}
