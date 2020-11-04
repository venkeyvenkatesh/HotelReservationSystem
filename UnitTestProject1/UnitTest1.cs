using HotelReservationSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ReturnMinFareForRegularCustomersWeekDays()
        {
            DateTime startDate = new DateTime(2020, 09, 10);
            DateTime endDate = new DateTime(2020, 09, 11);
            HotelGenerator hotelName = new HotelGenerator(startDate, endDate);
            HotelGenerator.customerType = "REGULAR";
            hotelName.AddHotel("LAKEWOOD");
            hotelName.AddHotel("BRIDGEWOOD");
            hotelName.AddHotel("RIDGEWOOD");

            string expectedHotel = "LAKEWOOD";
            int expected = 220;
            Assert.AreEqual(expected, hotelName.getTheMinimumFareHotel());
            Assert.AreEqual(expectedHotel, hotelName.minFareHotel);
        }


        [TestMethod]
        public void ReturnMinFareForRewardCustomersWeekDays()
        {
            DateTime startDate = new DateTime(2020, 09, 10);
            DateTime endDate = new DateTime(2020, 09, 11);
            HotelGenerator hotelName = new HotelGenerator(startDate, endDate);
            HotelGenerator.customerType = "REWARD";
            hotelName.AddHotel("LAKEWOOD");
            hotelName.AddHotel("BRIDGEWOOD");
            hotelName.AddHotel("RIDGEWOOD");

            string expectedHotel = "LAKEWOOD";
            int expected = 160;
            Assert.AreEqual(expected, hotelName.getTheMinimumFareHotel());
            Assert.AreEqual(expectedHotel, hotelName.minFareHotel);
        }




        [TestMethod]
        public void ReturnMinFareForRegularCustomersWeekEnd()
        {
            DateTime startDate = new DateTime(2020, 09, 11);
            DateTime endDate = new DateTime(2020, 09, 12);
            HotelGenerator hotelName = new HotelGenerator(startDate, endDate);
            HotelGenerator.customerType = "REGULAR";
            hotelName.AddHotel("LAKEWOOD");
            hotelName.AddHotel("BRIDGEWOOD");
            hotelName.AddHotel("RIDGEWOOD");
            // hotelName.getTheMinimumFareHotel();
            string expectedHotel = "LAKEWOOD";
            int expected = 200;
            Assert.AreEqual(expected, hotelName.getTheMinimumFareHotel());
            Assert.AreEqual(expectedHotel, hotelName.minFareHotel);
        }

        [TestMethod]
        public void ReturnMinFareForRewardCustomersWeekEnd()
        {
            DateTime startDate = new DateTime(2020, 09, 11);
            DateTime endDate = new DateTime(2020, 09, 12);
            HotelGenerator hotelName = new HotelGenerator(startDate, endDate);
            HotelGenerator.customerType = "REWARD";
            hotelName.AddHotel("LAKEWOOD");
            hotelName.AddHotel("BRIDGEWOOD");
            hotelName.AddHotel("RIDGEWOOD");

            string expectedHotel = "RIDGEWOOD";
            int expected = 140;
            Assert.AreEqual(expected, hotelName.getTheMinimumFareHotel());
            Assert.AreEqual(expectedHotel, hotelName.minFareHotel);

        }



    }
}
