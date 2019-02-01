using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Core.Entities
{
    public class Movement : BaseEntity
    {
        public int FlightId { get; set; }
        public string Direction { get; set; }
        public Flight Flight { get; set; }
    }
}
