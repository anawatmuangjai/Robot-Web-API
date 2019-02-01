using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RMS.API.Dtos
{
    public class MovementDTO
    {
        public int Id { get; set; }

        [Required]
        public int FlightId { get; set; }

        [Required]
        [StringLength(10)]
        public string Direction { get; set; }
    }
}
