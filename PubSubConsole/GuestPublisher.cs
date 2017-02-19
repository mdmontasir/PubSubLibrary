using  PubSubLibrary;

namespace PubSubConsole
{
    public class GuestPublisher
    {
        public void GuestAdded(Guest guest)
        {
            this.Publish<Guest>(guest);
        }
    }
}
