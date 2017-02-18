using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubSubLibrary;

namespace PubSubConsole
{
    public class RoomSubscriber
    {
        public RoomSubscriber()
        {
            this.Subscribe<Room>(r => { Console.WriteLine(r.MakeUpRoom()); });
        }

        public void RoomUnsubscribe()
        {
            this.Unsubscribe<Room>();
        }
    }
}
