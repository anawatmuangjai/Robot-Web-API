using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Core.Entities
{
    public class Status : BaseEntity
    {
        public string StatusName { get; set; }
        public string Note { get; set; }
    }
}
