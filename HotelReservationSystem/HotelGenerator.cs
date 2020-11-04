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
                    WeekEndRate = 60;

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

       

    }

}

