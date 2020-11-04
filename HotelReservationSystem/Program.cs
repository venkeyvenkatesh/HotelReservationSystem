using System;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello welcome to  Hotel Reservation System");

            DateTime startDate = new DateTime(2020, 03, 16);
            DateTime endDate = new DateTime(2020, 03, 18);
            HotelGenerator hotelName = new HotelGenerator(startDate, endDate);
            hotelName.AddHotel("LAKEWOOD", CustomerType.REGULAR);
            hotelName.AddHotel("BRIDGEHOOD", CustomerType.REGULAR);
            hotelName.AddHotel("RIDGEHOOD", CustomerType.REGULAR);
            hotelName.getTheMinimumFareHotel();

        }
    }
}
