using PubSubLibrary;

namespace PubSubConsole
{
    internal class BedPublisher
    {

        public void BedReady(Bed bed)
        {
            this.Publish<Bed>(bed);
        }
    }
}
