using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationReporter.Geospatial
{
    class GeospatialValidator
    {
        /// <summary>
        /// Checks to see if the given lat long is a position on earth
        /// </summary>
        /// <param name="latitude">Latitude in Decimal Degrees format</param>
        /// <param name="longitude">Longitude in Decimal Degrees format</param>
        /// <returns>True is position is valid, false otherwise</returns>
        public static bool isPositionValid(String latitude, String longitude)
        {
            //Checking for missing input
            if (String.IsNullOrEmpty(latitude) || String.IsNullOrEmpty(longitude))
            {
                return false;
            }

            try
            {
                Double latitudeDouble = Double.Parse(latitude);
                Double longitudeDouble = Double.Parse(longitude);

                if (latitudeDouble < -90 || latitudeDouble > 90)
                {
                    return false;
                }
                if (longitudeDouble < -180 || longitudeDouble > 180)
                {
                    return false;
                }
            }
            catch{ return false; }

            //The position has been validated to be a point on earth
            return true;
        }

        /// <summary>
        /// Checks to see if the given latitude is a position on earth
        /// </summary>
        /// <param name="latitude">Latitude in Decimal Degrees format</param>
        /// <returns>True is position is valid, false otherwise</returns>
        public static bool isLatitudeValid(String latitude)
        {
            bool isValid = true;

            if (String.IsNullOrEmpty(latitude))
            {
                isValid = false;
            }

            try
            {
                Double latitudeDouble = Double.Parse(latitude);
                if (latitudeDouble < -90 || latitudeDouble > 90)
                {
                    isValid = false;
                }
            }
            catch { isValid = false; }

            return isValid;
        }

        /// <summary>
        /// Checks to see if the given longitude is a position on earth
        /// </summary>
        /// <param name="longitude">Longitude in Decimal Degrees format</param>
        /// <returns>True is position is valid, false otherwise</returns>
        public static bool isLongitudeValid(String longitude)
        {
            bool isValid = true;

            if (String.IsNullOrEmpty(longitude))
            {
                isValid = false;
            }

            try
            {
                Double longitudeDouble = Double.Parse(longitude);
                if (longitudeDouble < -180 || longitudeDouble > 180)
                {
                    isValid = false;
                }
            }
            catch { isValid = false; }

            return isValid;
        }

    }
}
