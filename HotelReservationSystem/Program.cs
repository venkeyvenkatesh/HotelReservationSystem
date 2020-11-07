using System;

namespace HotelReservationSystem
{
    class Program
    {

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello welcome to  Hotel Reservation System");

            DateTime startDate = new DateTime(2020, 09, 11);
            DateTime endDate = new DateTime(2020, 09, 12);
            HotelGenerator hotelName = new HotelGenerator(startDate, endDate);

           

          
            HotelGenerator.customerType = "REWARD";

            
            hotelName.AddHotel("LAKEWOOD");
            hotelName.AddHotel("BRIDGEWOOD");
            hotelName.AddHotel("RIDGEWOOD");
           
          
            hotelName.getTheMinimumFareHotel();
          
        }
    }
}
