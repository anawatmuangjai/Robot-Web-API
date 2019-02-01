using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Core.Entities
{
    public class Machine : BaseEntity
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string IpAddress { get; set; }
    }
}
