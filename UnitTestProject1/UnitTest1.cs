using HotelReservationSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        /// <summary>
        /// Returns the minimum fare for regular customers week days.
        /// </summary>
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


        /// <summary>
        /// Returns the minimum fare for reward customers week days.
        /// </summary>
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



        /// <summary>
        /// Returns the minimum fare for regular customers including week end.
        /// </summary>
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

        /// <summary>
        /// Returns the minimum fare for reward customers including week end.
        /// </summary>
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


        /// <summary>
        /// Given the invalid dates throws exception.
        /// </summary>
        [TestMethod]

        public void GivenInvalidDates_throwsException()
        {
            HotelException.ExceptionType expected = HotelException.ExceptionType.INVALID_DATE;


            try
            {
                DateTime startDate = new DateTime(2020, 09, 13);
                DateTime endDate = new DateTime(2020, 09, 12);
                HotelGenerator hotelName = new HotelGenerator(startDate, endDate);
            }
            catch (HotelException he)
            {
                HotelException.ExceptionType actual;
                actual = he.type;
                Assert.AreEqual(expected, actual);
            }


        }


        /// <summary>
        /// Given the invalid customer type throws exception.
        /// </summary>
        [TestMethod]
        public void GivenInvalidCustomerType_throwsException()
        {
            HotelException.ExceptionType expected = HotelException.ExceptionType.INVALID_CUSTOMER_TYPE;


            try
            {
                DateTime startDate = new DateTime(2020, 09, 11);
                DateTime endDate = new DateTime(2020, 09, 12);
                HotelGenerator hotelName = new HotelGenerator(startDate, endDate);
                HotelGenerator.customerType = "RARD";

                hotelName.AddHotel("LAKEWOOD");
                hotelName.AddHotel("BRIDGEWOOD");
                hotelName.AddHotel("RIDGEWOOD");


            }
            catch (HotelException he)
            {
                HotelException.ExceptionType actual;
                actual = he.type;
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
