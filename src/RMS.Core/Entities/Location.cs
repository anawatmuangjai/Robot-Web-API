using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Core.Entities
{
    public class Location : BaseEntity
    {
        public string LocationName { get; set; }
        public string LocationCode { get; set; }
    }
}
