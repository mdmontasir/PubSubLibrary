using System;
using PubSubLibrary;

namespace PubSubConsole
{
    public class BedSubscriber
    {
        public BedSubscriber()
        {
            this.Subscribe<Bed>(r => Console.WriteLine(r.MakeUpBed()));
        }

        public void BedUnsubscribe()
        {
            this.Unsubscribe<Bed>();
        }
    }
}
