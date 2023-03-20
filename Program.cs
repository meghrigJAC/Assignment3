using System;
using System.Diagnostics;

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
    enum Days
    {
        Monday=1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday
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
                "284.77,283.05,286.89,280.26,03-01-2023",
                "276.46,277.14,278.32,269.52,03-02-2023",
                "280.30,284.39,285.51,277.95,03-03-2023",
                "284.83,283.03,286.56,280.80,03-06-2023",
                "280.41,267.36,283.10,267.19,03-07-2023",
                "266.86,267.90,270.92,264.13,03-08-2023",
                "176.60,106.11,177.55,100.18,03-09-2023"
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
            
            decimal MaxPrice = decimal.MinValue;
            decimal MinPrice = decimal.MaxValue;
            decimal totalAverage = 0m;
            DateTime minDate= DateTime.Today, maxDate= DateTime.Today;

            Console.WriteLine($"Assignment 3 - programming 2 - Winter 2023");
            Console.WriteLine($"Report generated on {DateTime.Now.ToString("D")} by {"enter your name"}");
            Console.WriteLine();

            Console.WriteLine($"{"Day",-10} {"Opening Price",-20} {"Closing Price",-20} {"Lowest Price",-20} {"Highest Price",-20}  {"Average Price",-20} {"Date",-40} ");

            foreach (AssetPrices data in dailyPrices)
            {
                decimal average = data.GetAveragePrice();
                Console.WriteLine($"{(Days)data.date.DayOfWeek,-10}: {data.OpeningPrice,-20} {data.ClosingPrice,-20} {data.LowestPrice,-20} {data.HighestPrice,-20:n2} {average,-20:n2} {data.date.ToString("D"),-40} ");
                if (MaxPrice < data.HighestPrice)
                {
                    MaxPrice = data.HighestPrice;
                    minDate = data.date;
                }
                if (MinPrice > data.LowestPrice)
                {
                    MinPrice = data.LowestPrice;
                    maxDate = data.date;
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
