using System;

namespace PubSubLibrary
{
    static public class Extensions
    {
        static private readonly PubSub Hub = new PubSub();

        static public void Publish<T>(this object obj, T data)
        {
            Console.WriteLine(obj.GetType() + " Published");
            Hub.Publish(obj, data);
        }

        static public void Subscribe<T>(this object obj, Action<T> handler)
        {
            Console.WriteLine(obj.GetType() + " Subscribed");
            Hub.Subscribe(obj, handler);
        }

        static public void Unsubscribe<T>(this object obj)
        {
            Console.WriteLine(obj.GetType() + " Unsubscribed");
            Hub.Unsubscribe(obj, (Action<T>)null);
        }
    }
}
