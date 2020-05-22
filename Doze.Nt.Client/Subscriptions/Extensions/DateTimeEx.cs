using Doze.Nt.Client.Subscriptions.Structures;
using System;

namespace Doze.Nt.Client.Subscriptions.Extensions
{
    public static class DateTimeEx
    {
        public static FileTime DateTimeToFileTime(this DateTime input)
        {
            var managedFileTime = input.ToFileTime();

            return new FileTime
            {
                DateTimeLow = (int)managedFileTime,
                DateTimeHigh = (int)managedFileTime >> 32
            };
        }

        public static DateTime FileTimeToDateTime(this FileTime input)
            => DateTime.FromFileTime(((long)input.DateTimeHigh << 32) + input.DateTimeLow);

        public static DateTime LargeIntegerToDateTime(this LargeInteger input)
            => DateTime.FromFileTime(((long)input.HighPart << 32) + input.LowPart);
    }
}
