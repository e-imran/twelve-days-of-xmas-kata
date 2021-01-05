using System;
using System.Collections.Generic;
using System.Linq;

namespace TwelveDays.Tests
{
    public interface ITwelveDaysOfChristmas
    {
        string GetVerse(int verseNumber);
        string GetSong();
    }
    public sealed class TwelveDaysOfChristmas : ITwelveDaysOfChristmas
    {
        private IIOHelper helper;
        public TwelveDaysOfChristmas(IIOHelper helper)
        {
            this.helper = helper;
        }

        public Dictionary<string, string> Gifts => GiftsRepo.Get();
        public IList<string> Days => DaysRepo.Get();

        public string GetVerse(int verseNumber)
        {
            try
            {
                string day = string.Empty;
                string quantity = string.Empty;

                if (verseNumber == 1)
                {
                    day = Days[verseNumber - 1];
                    quantity = Gifts.Keys.ToList()[verseNumber - 1];
                }
                else
                {
                    day = Days[verseNumber - 1];
                    quantity = Gifts.Keys.ToList()[verseNumber - 1];
                }

                var gift = Gifts[quantity];

                var firstVerse = $"On the {day} day of Christmas my true love gave to me";
                var secondVerse = String.Empty;

                if (verseNumber == 1)
                {
                    secondVerse = $"A {gift}";
                }
                else
                {
                    secondVerse = $"{quantity} {gift}";
                }

                var verse = firstVerse + Environment.NewLine + secondVerse;

                return verse;
            }

            catch (ArgumentOutOfRangeException ex)
            {
                return ex.Message;
            }
        }

        public string GetSong()
        {
            var giftList = new List<string>();

            for (int i = 1; i <= 12; i++)
            {
                var quantity = Gifts.ToList()[i - 1].Key;
                var gift = Gifts.ToList()[i - 1].Value;
                var ordinal = Days[i - 1];

                if (!giftList.Any())
                {
                    giftList.Add(GetVerse(i));
                    giftList.Add("\r\n");
                }
                else
                {
                    giftList.Add("\r\n");
                    giftList.Add(GetVerse(i));
                    giftList.Add("\r\n");

                    for (int n = i - 2; n >= 0; n--)
                    {
                        var quantityContext = Gifts.ToList()[n].Key;
                        var giftContext = Gifts.ToList()[n].Value;

                        if (n == 0)
                        {
                            giftList.Add($"And a {giftContext}");
                            giftList.Add("\r\n");
                        }
                        else
                        {
                            giftList.Add($"{quantityContext} {giftContext}");
                            giftList.Add("\r\n");
                        }
                    }
                }
            }

            var output = string.Join("", giftList);

            helper.LogOutputToTextFile(output);

            return output;
        }
    }
}