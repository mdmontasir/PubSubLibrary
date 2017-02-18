using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubSubLibrary;

namespace PubSubConsole
{
    public class GuestSubscriber
    {
        public GuestSubscriber()
        {
            this.Subscribe<Guest>(r => { Console.WriteLine(r.GuestStatus()); });
        }

        public void GuestUnsubscribe()
        {
            this.Unsubscribe<Guest>();
        }
    }
}
