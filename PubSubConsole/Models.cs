using System;
using System.Collections.Generic;

namespace PubSubConsole
{
    public class Bed
    {
        public int BedNumber { get; set; }

        public string MakeUpBed()
        {
            return  BedNumber + " bed(s) is ready.";
        }
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
