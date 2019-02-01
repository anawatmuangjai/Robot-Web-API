using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Core.Entities
{
    public class TransportRoute : BaseEntity
    {
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public string PathData { get; set; }
        public Origin Origin { get; set; }
        public Destination Destination { get; set; }
    }
}
