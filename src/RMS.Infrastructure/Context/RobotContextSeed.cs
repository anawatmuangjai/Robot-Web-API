using RMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Infrastructure.Context
{
    public static class RobotContextSeed
    {
        public static async Task SeedAsync(RobotContext robotContext)
        {
            if (!robotContext.Statuses.Any())
            {
                robotContext.Statuses.AddRange(GetPreconfiguredStatuses());
                await robotContext.SaveChangesAsync();
            }

            if (!robotContext.Locations.Any())
            {
                robotContext.Locations.AddRange(GetPreconfiguredLocations());
                await robotContext.SaveChangesAsync();
            }

            if (!robotContext.Machines.Any())
            {
                robotContext.Machines.AddRange(GetPreconfiguredMachines());
                await robotContext.SaveChangesAsync();
            }
        }

        private static IEnumerable<Status> GetPreconfiguredStatuses()
        {
            return new List<Status>()
            {
                new Status() { StatusName = "Stop", Note = "Free" },
                new Status() { StatusName = "Running", Note = "On the way" },
                new Status() { StatusName = "Pause", Note = "Stop wait start" },
                new Status() { StatusName = "Wait", Note = "Wait request" },
                new Status() { StatusName = "Error", Note = "Have problem" },
            };
        }

        private static IEnumerable<Location> GetPreconfiguredLocations()
        {
            return new List<Location>()
            {
                new Location() { LocationName = "Laser Room", LocationCode = "X1" },
                new Location() { LocationName = "Material Room", LocationCode = "X2" },
                new Location() { LocationName = "Kitting Room", LocationCode = "X3" },
                new Location() { LocationName = "Production", LocationCode = "X4" },
            };
        }

        private static IEnumerable<Machine> GetPreconfiguredMachines()
        {
            return new List<Machine>()
            {
                new Machine()
                {
                    Name = "RD4",
                    Number = "001",
                    IpAddress = "11.11.11.11"
                },
            };
        }
    }
}
