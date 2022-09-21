using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.MeterReaderCompanyServices.Extensions
{
    public static class StringExtensions
    {

        public static string Mask(this string source, int start, int maskLength)
        {
            return source.Mask(start, maskLength, '*');
        }

        public static string Mask(this string source, int start, int maskLength, char maskCharacter)
        {
            if (start > source.Length - 1)
            {
                throw new ArgumentException("Start position is greater than string length");
            }

            if (maskLength > source.Length)
            {
                throw new ArgumentException("Mask length is greater than string length");
            }

            if (start + maskLength > source.Length)
            {
                throw new ArgumentException("Start position and mask length imply more characters than are present");
            }

            string mask = new string(maskCharacter, maskLength);
            string unMaskStart = source.Substring(0, start);
            string unMaskEnd = source.Substring(start + maskLength, source.Length - 1 - maskLength);

            return unMaskStart + mask + unMaskEnd;

        }
    }
}
