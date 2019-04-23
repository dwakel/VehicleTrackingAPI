using System;
using System.Collections.Generic;
using System.Text;

namespace Gps.Core.Services
{
    public static class DistanceService
    {
        private const int RE = 6371; // Radius of the earth

        //Method that returns results of distance voilation
        public static string CalculateDistanceVoilation(double radius, double homeLat, double homeLon, double lat, double lon)
        {
            if (radius - CalculateDistance(homeLat, homeLon, lat, lon) < 0)
            {
                return string.Format(@"You are {0}
                meters out of the safety range", CalculateDistance(homeLat, homeLon, lat, lon) - radius);
            }
            return string.Empty;
        }

        //Implementation of Halfsine formular
        private static double CalculateDistance(double homeLat, double homeLon, double lat, double lon)
        {
            var dLat = deg2rad(lat - homeLat);
            var dLon = deg2rad(lon - homeLon);
            var a =
                  Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                  Math.Cos(deg2rad(homeLat)) *
                  Math.Cos(deg2rad(lat)) *
                  Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return RE * c * 1000; // distance, d = RE * c, (distance in kilometers so multiplied by 1000)
        }

        //Helper method to convert degrees to radians
        private static double deg2rad(double deg) => deg * (Math.PI / 180);
    }
}