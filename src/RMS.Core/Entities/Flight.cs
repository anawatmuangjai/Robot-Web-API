using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Core.Entities
{
    public class Flight : BaseEntity
    {
        public int MachineId { get; set; }
        public int TransportRouteId { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public Machine Machine { get; set; }
        public TransportRoute TransportRoute { get; set; }
    }
}
