using System;
using System.Globalization;

namespace PubSubConsole
{
    class Program
    {
        private static void Main(string[] args)
        {
            var bedSubscriber = new BedSubscriber();
            var guestSubscriber = new GuestSubscriber();
            var guestPublisher = new GuestPublisher();
            var bedPublisher = new BedPublisher();
            
            Console.WriteLine("Enter First Name : ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name : ");
            string lastName = Console.ReadLine();

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            string guestName = textInfo.ToTitleCase(firstName + " " + lastName);

            Console.WriteLine("Enter Guest Gender? Enter M or F");
            var guestGender = Console.ReadLine();

            var genderEnum = GenderEnum.Male;
            if (!string.IsNullOrEmpty(guestGender) && guestGender.ToUpper() == "F")
            {
                genderEnum = GenderEnum.Female;
            }

            guestPublisher.GuestAdded(new Guest {GuestName = guestName, Gender = genderEnum});

            Console.WriteLine("Enter total number of guest(s)? Enter number");
            var totalGuestNumber = Console.ReadLine();
            if (ValidateNumber(totalGuestNumber))
            {
                bedPublisher.BedReady(new Bed {BedNumber = Convert.ToInt16(totalGuestNumber)});
            }
            else
            {
                Console.WriteLine("It accepts number only.");
            }

            //guest unsubscribe
            guestSubscriber.GuestUnsubscribe();

            guestPublisher.GuestAdded(new Guest {GuestName = guestName, Gender = genderEnum});
           
            Console.ReadKey();
        }

        static private bool ValidateNumber(string totalGuestNumber)
        {
            int total;
            if (int.TryParse(totalGuestNumber, out total))
            {
                return true;
            }
            return false;
        }
    }

}
