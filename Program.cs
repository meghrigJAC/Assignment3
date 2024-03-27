using System;
using System.Diagnostics;
using System.Globalization;

namespace Assignment3
{
    struct AssetPrices
    {
        public decimal OpeningPrice;
        public decimal ClosingPrice;
        public decimal HighestPrice;
        public decimal LowestPrice;
        public DateTime date;

        public decimal GetAveragePrice()
        {
            return (OpeningPrice + ClosingPrice + HighestPrice + LowestPrice) / 4;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            AssetPriceFluctuations();
        }

        public static void AssetPriceFluctuations()
        {
            string[] data =
              {
            "181.45, 175.37, 182.74, 174.87, 03-08-2024",
            "175.37, 177.66, 182.94, 174.87, 03-11-2024",
            "177.76, 177.56, 179.45, 172.58, 03-12-2024",
            "173.08, 169.49, 176.07, 169.29, 03-13-2024",
            "167.69, 162.51, 171.08, 160.42, 03-14-2024",
            "163.11, 163.51, 165.10, 160.92, 03-15-2024",
            "170.09, 173.67, 174.67, 165.90, 03-18-2024"
            };

            List<AssetPrices> dailyPrices = ProcessArray(data);
               
            DisplayData(dailyPrices);
        }

        public static List<AssetPrices> ProcessArray(string[] data)
        {
            string[] values;
            AssetPrices dailyPrice;

            List<AssetPrices> dailyPrices = new List<AssetPrices>();

            foreach (string dailyData in data)
            {
                values = dailyData.Split(",");
                dailyPrice.OpeningPrice = decimal.Parse(values[0]);
                dailyPrice.ClosingPrice = decimal.Parse(values[1]);
                dailyPrice.HighestPrice = decimal.Parse(values[2]);
                dailyPrice.LowestPrice = decimal.Parse(values[3]);
                dailyPrice.date = DateTime.Parse(values[4]);

                dailyPrices.Add(dailyPrice);
            }
            return dailyPrices;
        }
        public static void DisplayData(List<AssetPrices> dailyPrices)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");

            decimal MaxPrice = decimal.MinValue;
            decimal MinPrice = decimal.MaxValue;
            decimal totalAverage = 0m;
            DateTime minDate= DateTime.Today, maxDate= DateTime.Today;

            Console.WriteLine($"Assignment 3 - programming 2 - Winter 2024");
            Console.WriteLine($"Report generated on {DateTime.Now.ToString("D")} by {"enter your name"}");
            Console.WriteLine();

            Console.WriteLine($"{"Day",-10} {"Opening Price",-20} {"Closing Price",-20} {"Lowest Price",-20} {"Highest Price",-20}  {"Average Price",-20} {"Date",-40} ");

            foreach (AssetPrices data in dailyPrices)
            {
                decimal average = data.GetAveragePrice();
                Console.WriteLine($"{(DayOfWeek)data.date.DayOfWeek,-10}: {data.OpeningPrice,-20} {data.ClosingPrice,-20} {data.LowestPrice,-20} {data.HighestPrice,-20:n2} {average,-20:n2} {data.date.ToString("D"),-40} ");
                if (MaxPrice < data.HighestPrice)
                {
                    MaxPrice = data.HighestPrice;
                    maxDate = data.date;
                }
                if (MinPrice > data.LowestPrice)
                {
                    MinPrice = data.LowestPrice;
                    minDate = data.date;
                }
                totalAverage += average;

            }

            Console.WriteLine();
            Console.WriteLine($"{"The highest Price was:",-50} {MaxPrice} on {maxDate.ToString("d")}");
            Console.WriteLine($"{"The lowest Price was:",-50} {MinPrice} on {minDate.ToString("d")}");
            Console.WriteLine($"{"The average of all the daily average prices is:",-50} {totalAverage / dailyPrices.Count :n2}");
        }
    }
}
