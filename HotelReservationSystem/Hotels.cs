using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{

    public class Hotels
    {
        public string HotelName
        {
            get;
            set;
        }

        public int WeekDayRate
        {
            get;
            set;
        }
        public int WeekEndRate
        {
            get;
            set;
        }
        public int Rating
        {

            get;
            set;
        }


        public Hotels(string HotelName, int WeekDayRate, int WeekEndRate, int Rating)
        {
            this.HotelName = HotelName;
            this.WeekDayRate = WeekDayRate;
            this.WeekEndRate = WeekEndRate;
            this.Rating = Rating;
        }




    }


}
