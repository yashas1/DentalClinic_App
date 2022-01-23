using System;
using System.Linq;

namespace DentalCareBackend
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        public void GenerateAppointmentSlots(SlotList slots)
        {
            // Defining current time and start time of appointments
            DateTime currDateTime = DateTime.Now;
            DateTime startTime = new DateTime(currDateTime.Year, currDateTime.Month, currDateTime.Day, 9, 0, 0);

            // Iterator to create slots between 9AM - 5PM
            foreach (int index in Enumerable.Range(0, Slot.MaxCount))
            {
                Slot newSlot = new Slot();
                newSlot.DateTime = startTime.ToString("dddd, dd MMMM yyyy HH:mm tt");
                slots.Add(newSlot);

                startTime = startTime.AddHours(1);
            }
        }
    }
}
