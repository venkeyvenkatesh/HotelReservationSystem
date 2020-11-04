using System;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello welcome to  Hotel Reservation System");

            DateTime startDate = new DateTime(2020, 09, 11);
            DateTime endDate = new DateTime(2020, 09, 12);
            HotelGenerator hotelName = new HotelGenerator(startDate, endDate);
            hotelName.AddHotel("LAKEWOOD", CustomerType.REGULAR);
            hotelName.AddHotel("BRIDGEWOOD", CustomerType.REGULAR);
            hotelName.AddHotel("RIDGEWOOD", CustomerType.REGULAR);
            hotelName.getTheMinimumFareHotel();

        }
    }
}
