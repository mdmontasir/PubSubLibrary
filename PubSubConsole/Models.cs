using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubConsole
{
    public class Room
    {
        public int RoomNumber { get; set; }

        public string MakeUpRoom()
        {
            return "Room " + RoomNumber + " is ready.";
        }

    }

    public enum GenderEnum : int
    {
        Male=1,
        Female
    }

    public class Guest
    {
        public Dictionary<GenderEnum, string> GenderDictionary = new Dictionary<GenderEnum, string>();

        public Guest()
        {
            GenderDictionary.Add(GenderEnum.Male, "Mr.");
            GenderDictionary.Add(GenderEnum.Female, "Ms.");
        }
        public string GuestName { get; set; }
        public GenderEnum Gender { get; set; }
        public string GuestStatus()
        {
            return String.Format("{0} {1} is OnBoard", GenderDictionary[Gender], GuestName);
        }
    }
}
