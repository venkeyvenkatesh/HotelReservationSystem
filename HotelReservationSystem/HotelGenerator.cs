﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelReservationSystem
{

  


    public class HotelGenerator
    {
        public static string customerType;
        public List<Hotels> list = new List<Hotels>();
        public Dictionary<Hotels, int> dictionary = new Dictionary<Hotels, int>();

        int WeekDayRate, WeekEndRate, Rating;
        DateTime startDate, endDate;

        public string minFareHotel;
       public  int minFare=9999;

        public HotelGenerator(DateTime startDate, DateTime endDate)
        {
            this.startDate = startDate;
            this.endDate = endDate;
        }
        public void AddHotel(string name)
        {

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



        public int getTheMinimumFareHotel()
        {
           // int min = 9999;
            int maxRating = 0;
            foreach (var hotel in list)
            {
                int newfare = calculateRentBetweenDays(hotel);
                dictionary.Add(hotel, newfare);
                if (newfare < minFare)
                {
                    minFare = newfare;
                 
                }
            }
            Hotels reqHotel = null;
          
            foreach (var list in dictionary)
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




            Console.WriteLine("Min fare hotel is " + reqHotel.HotelName + "\n" + "Rating " + reqHotel.Rating + "\n" + " fare is " + dictionary[reqHotel]);
            return minFare;
        }


    }

}

