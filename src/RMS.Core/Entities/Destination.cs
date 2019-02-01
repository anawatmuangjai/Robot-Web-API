using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Core.Entities
{
    public class Destination : BaseEntity
    {
        public string DestinationName { get; set; }
        public string DestinationCode { get; set; }
    }
}
