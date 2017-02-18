using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            RoomSubscriber room = new RoomSubscriber();
            GuestSubscriber guest = new GuestSubscriber();

            //guest.GuestUnsubscribe();

            Publisher pub = new Publisher();

            //input guest first name // last name

            //transfirm e f+l = full name

            //proper case the text

            //processGet;

            pub.RoomAdded(new Room { RoomNumber = 101 });
            pub.GuestAdded(new Guest { GuestName = "Montasir", Gender = GenderEnum.Male});
            pub.GuestAdded(new Guest { GuestName = "Nishat", Gender = GenderEnum.Female });

            Console.ReadKey();
        }
    }

}
