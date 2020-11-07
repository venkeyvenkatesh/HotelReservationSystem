using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
   public class HotelException:ApplicationException
    {

        public enum ExceptionType
        {
           INVALID_DATE,
            INVALID_CUSTOMER_TYPE,
            INVALID_HOTEL_TYPE
        }

        public ExceptionType type;

        public HotelException(ExceptionType type,string message):base(message)
        {
            this.type = type;
        }

    }
}
