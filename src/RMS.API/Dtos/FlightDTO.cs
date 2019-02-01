using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMS.API.Dtos
{
    public class FlightDTO
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public int TransportRouteId { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
    }
}
