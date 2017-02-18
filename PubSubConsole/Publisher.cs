using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  PubSubLibrary;

namespace PubSubConsole
{
    public class Publisher
    {
        public Publisher()
        {
            
        }

        public void RoomAdded(Room room)
        {
            this.Publish<Room>(room);
        }

        public void GuestAdded(Guest guest)
        {
            this.Publish<Guest>(guest);
        }
    }
}
