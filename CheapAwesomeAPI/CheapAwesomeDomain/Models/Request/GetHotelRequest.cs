using System;
using System.Collections.Generic;
using System.Text;

namespace CheapAwesome.Domain.Models.Request
{
    public class GetHotelRequest
    {
        public int destId { get; set; }
        public int noOfNights { get; set; }
    }
}
