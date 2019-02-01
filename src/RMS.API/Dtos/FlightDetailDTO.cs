using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMS.API.Dtos
{
    public class FlightDetailDTO
    {
        public int Id { get; set; }
        public int MachineName { get; set; }
        public int MachineNumber { get; set; }
        public int OriginName { get; set; }
        public int DetinationName { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
    }
}
