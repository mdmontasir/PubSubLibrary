using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubLibrary
{
    static public class Extensions
    {
        static private readonly PubSub hub = new PubSub();

        static public void Publish<T>(this object obj)
        {
            hub.Publish(obj, default(T));
        }

        static public void Publish<T>(this object obj, T data)
        {
            hub.Publish(obj, data);
        }

        static public void Subscribe<T>(this object obj, Action<T> handler)
        {
            hub.Subscribe(obj, handler);
        }

        static public void Unsubscribe(this object obj)
        {
            hub.Unsubscribe(obj);
        }

        static public void Unsubscribe<T>(this object obj)
        {
            hub.Unsubscribe(obj, (Action<T>)null);
        }

        static public void Unsubscribe<T>(this object obj, Action<T> handler)
        {
            hub.Unsubscribe(obj, handler);
        }
    }
}
