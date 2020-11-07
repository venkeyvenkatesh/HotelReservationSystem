using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelReservationSystem
{



    public class HotelGenerator
    {
        public static string customerType;

        public List<Hotels> hotelList = new List<Hotels>();
        public Dictionary<Hotels, int> hotelFareDictionary = new Dictionary<Hotels, int>();

        int WeekDayRate, WeekEndRate, Rating,minFare=9999;


        DateTime startDate, endDate;


        public string minFareHotel;
      


        /// <summary>
        /// Initializes a new instance of the <see cref="HotelGenerator"/> class.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        public HotelGenerator(DateTime startDate, DateTime endDate)
        {
            this.startDate = startDate;
            this.endDate = endDate;
        }


        /// <summary>
        /// Adds the hotel.
        /// </summary>
        /// <param name="name">The name.</param>
        public void AddHotel(string name)
        {
            if(!(customerType.Equals("REWARD")||customerType.Equals("REGULAR")))
            {
                throw new HotelException(HotelException.ExceptionType.INVALID_CUSTOMER_TYPE, "Invalid Customer passed");
            }

            if (name.Equals("LAKEWOOD"))
            {
                Rating = 3;
                if (customerType.Equals("REGULAR"))
                {
                    WeekDayRate = 110;
                    WeekEndRate = 90;

                }

                else 
                {
                    WeekDayRate = 80;
                    WeekEndRate = 80;

                }
                
            }
            else if (name.Equals("BRIDGEWOOD"))
            {
                Rating = 4;
                if (customerType.Equals("REGULAR"))
                {
                    WeekDayRate = 160;
                    WeekEndRate = 60;

                }
                else
                {
                    WeekDayRate = 110;
                    WeekEndRate = 50;

                }
            }
            else if (name.Equals("RIDGEWOOD"))
            {
                Rating = 5;
                if (customerType.Equals("REGULAR"))
                {
                    WeekDayRate = 220;
                    WeekEndRate = 150;

                }
                else
                {
                    WeekDayRate = 100;
                    WeekEndRate = 40;

                }

            }
            else
            {
                throw new HotelException(HotelException.ExceptionType.INVALID_HOTEL_TYPE, "Invald hotel type passed");
            }




            Hotels hotels = new Hotels(name, WeekDayRate, WeekEndRate, Rating);
            hotelList.Add(hotels);

        }


        /// <summary>
        /// Calculates the rent between days.
        /// </summary>
        /// <param name="hotel">The hotel.</param>
        /// <returns></returns>
        public int calculateRentBetweenDays(Hotels hotel)
        {
         if(startDate>endDate)
            {
                throw new HotelException(HotelException.ExceptionType.INVALID_DATE, "INAVLID_DATES_PASSED");

            }

            TimeSpan days = endDate.Subtract(startDate);
            DateTime date = startDate;
            int totalFare = 0;
            for (int i = 0; i <= days.Days; i++)
            {
                DayOfWeek day = date.DayOfWeek;
                if ((day.Equals(DayOfWeek.Saturday)) || (day.Equals(DayOfWeek.Sunday)))
                {
                    totalFare = totalFare + hotel.WeekEndRate;
                }
                else
                {
                   

                    totalFare = totalFare + hotel.WeekDayRate;
                }

                date = date.AddDays(1);
            }
            return totalFare;
        }


        /// <summary>
        /// Gets the minimum fare hotel.
        /// </summary>
        /// <returns></returns>
       public int getTheMinimumFareHotel()
        {
           // int min = 9999;
            int maxRating = 0;
            foreach (var hotel in hotelList)
            {
                int newfare = calculateRentBetweenDays(hotel);
                hotelFareDictionary.Add(hotel, newfare);
                if (newfare < minFare)
                {
                    minFare = newfare;
                 
                }
            }
            Hotels reqHotel = null;
          
            foreach (var list in hotelFareDictionary)
            {
                if (list.Value == minFare)
                {
                    if (list.Key.Rating > maxRating)
                    {

                        maxRating = list.Key.Rating;
                        reqHotel = list.Key;
                        minFareHotel = reqHotel.HotelName;


                    }
                }

            }

            Console.WriteLine("Min fare hotel is " + reqHotel.HotelName + "\n" + "Rating " + reqHotel.Rating + "\n" + "min fare is " + hotelFareDictionary[reqHotel]);
            return minFare;
        }


    }

}

