using System;
using System.Collections.Generic;
using System.Linq;

namespace PubSubLibrary
{
    public class PubSub
    {
        internal class Handler
        {
            public Delegate Action { get; set; }
            public WeakReference Sender { get; set; }
            public Type Type { get; set; }
        }
       
        internal List<Handler> Handlers = new List<Handler>();

        public void Publish<T>(object sender, T data = default( T ))
        {
            var handlerList = new List<Handler>(Handlers.Count);
            var handlersToRemoveList = new List<Handler>(Handlers.Count);
            
            foreach (var handler in Handlers)
            {
                if (!handler.Sender.IsAlive)
                {
                    handlersToRemoveList.Add(handler);
                }
                else if (handler.Type.IsAssignableFrom(typeof(T)))
                {
                    handlerList.Add(handler);
                }
            }

            foreach (var l in handlersToRemoveList)
            {
                Handlers.Remove(l);
            }

            foreach (var l in handlerList)
            {
                ((Action<T>)l.Action)(data);
            }
        }

        public void Subscribe<T>(object sender, Action<T> handler)
        {
            var item = new Handler
            {
                Action = handler,
                Sender = new WeakReference(sender),
                Type = typeof(T)
            };

            Handlers.Add(item);
            
        }

        public void Unsubscribe(object sender)
        {
            var query = Handlers.Where(a => !a.Sender.IsAlive ||
                                                    a.Sender.Target.Equals(sender));

            foreach (var h in query.ToList())
            {
                Handlers.Remove(h);
            }
        }

        public void Unsubscribe<T>(object sender, Action<T> handler = null)
        {
            var query = Handlers
                .Where(a => !a.Sender.IsAlive ||
                                (a.Sender.Target.Equals(sender) && a.Type == typeof(T)));

            if (handler != null)
            {
                query = query.Where(a => a.Action.Equals(handler));
            }

            foreach (var h in query.ToList())
            {
                Handlers.Remove(h);
            }
        }
    }
}
