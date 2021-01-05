using System.Collections.Generic;

namespace TwelveDays.Tests
{
    public class GiftsRepo
    {
        public static Dictionary<string, string> Get()
        {
            return new Dictionary<string, string>()
            {
                {"One", "partridge in a pear tree"},
                {"Two", "turtle doves"},
                {"Three", "French hens"},
                {"Four", "calling birds"},
                {"Five", "GOLDEN rings"},
                {"Six", "geese a laying"},
                {"Seven", "swans a swimming"},
                {"Eight", "maids a milking"},
                {"Nine", "ladies dancing"},
                {"Ten", "lords a leaping"},
                {"Eleven", "pipers piping"},
                {"Twelve", "drummers drumming"},
            };
        }
    }
}