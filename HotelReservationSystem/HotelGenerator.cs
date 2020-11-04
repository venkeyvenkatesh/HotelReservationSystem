using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelReservationSystem
{

    public enum CustomerType
    {
        REGULAR
    }


    public class HotelGenerator
    {
        public List<Hotels> list = new List<Hotels>();
        public Dictionary<Hotels, int> dictionary = new Dictionary<Hotels, int>();

        int WeekDayRate, WeekEndRate, Rating;
        DateTime startDate, endDate;

        public HotelGenerator(DateTime startDate, DateTime endDate)
        {
            this.startDate = startDate;
            this.endDate = endDate;
        }
        public void AddHotel(string name, CustomerType type)
        {

            if (name.Equals("LAKEWOOD"))
            {
                Rating = 3;
                if (type.Equals(CustomerType.REGULAR))
                {
                    WeekDayRate = 110;
                    WeekEndRate = 90;

                }


            }
            else if (name.Equals("BRIDGEWOOD"))
            {
                Rating = 4;
                if (type.Equals(CustomerType.REGULAR))
                {
                    WeekDayRate = 160;
                    WeekEndRate = 40;

                }
            }
            else if (name.Equals("RIDGEWOOD"))
            {
                Rating = 5;
                if (type.Equals(CustomerType.REGULAR))
                {
                    WeekDayRate = 220;
                    WeekEndRate = 150;

                }
            }




            Hotels hotels = new Hotels(name, WeekDayRate, WeekEndRate, Rating);
            list.Add(hotels);

        }

        public int calculateRentBetweenDays(Hotels hotel)
        {
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



        public void getTheMinimumFareHotel()
        {
            int min = 9999;
           // int maxRating = 0;
            foreach (var hotel in list)
            {
                int newfare = calculateRentBetweenDays(hotel);
                dictionary.Add(hotel, newfare);
                if (newfare < min)
                {
                    min = newfare;
                }
            }
            Hotels[] reqHotel = new Hotels[3];
            int length= 0;
            foreach (var list in dictionary)
            {
                if (list.Value == min)
                {
                    reqHotel[length] = list.Key;
                    length++;
                }
            }


            for (int i = 0; i < length; i++)
            {
                Console.WriteLine("Min fare hotel is " + reqHotel[i].HotelName + "\n" + "Min fare is " + min);
            }
        }


    }

}

