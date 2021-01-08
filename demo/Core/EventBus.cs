using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace Framework.EventBus
{
    public class EventBus
    {

        private static EventBus _eventBus = null;

        private static Dictionary<Type, List<Type>> _eventMapping = new Dictionary<Type, List<Type>>();  // 在这个字典中，key存储的是事件，而value中存储的是事件处理程序


        private EventBus() { }
        /// <summary>
        /// 单例
        /// </summary>
        /// <returns></returns>
        public static EventBus Instance()
        {
            if (_eventBus == null)
            {
                _eventBus = new EventBus();
                MapEvent2Handler();
            }
            return _eventBus;
        }



        /// <summary>
        /// 发布
        /// 这里没有用到队列之类的东西，使用的是直接调用的方式
        /// </summary>
        /// <param name="eventData"></param>
        public void Publish(BaseEvent eventData)
        {
            // 找出这个事件对应的处理者
            Type eventType = eventData.GetType();

            if (_eventMapping.ContainsKey(eventType) == true)
            {
                foreach (Type item in _eventMapping[eventType])
                {
                    MethodInfo mi = item.GetMethod("Handle");
                    if (mi != null)
                    {
                        object o = Activator.CreateInstance(item);
                        mi.Invoke(o, new object[] { eventData });
                    }
                }

            }
        }





        /// <summary>
        /// 将事件与事件处理程序映射到一起
        /// 使用元数据来进行注册
        /// </summary>
        static void MapEvent2Handler()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();

            foreach (Type type in types)
            {
                Type handlerInterfaceType = type.GetInterface("IEventHandler`1");  // 事件处理者

                if (handlerInterfaceType != null) // 若是事件处理者，则以其泛型参数为key，事件处理者的集合为value添加到映射中
                {
                    Type eventType = handlerInterfaceType.GetGenericArguments()[0]; // 这里只有一个
                    // 查找是否存在key
                    if (_eventMapping.Keys.Contains(eventType))
                    {
                        List<Type> handlerTypes = _eventMapping[eventType];
                        handlerTypes.Add(type);
                        _eventMapping[eventType] = handlerTypes;
                    }
                    else // 存在则添加
                    {
                        List<Type> handlerTypes = new List<Type>();
                        handlerTypes.Add(type);
                        _eventMapping.Add(eventType, handlerTypes);
                    }
                }
            }
        }

    }
}
