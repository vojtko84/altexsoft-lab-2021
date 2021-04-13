using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Homework
{
    internal class HomeWork
    {
        private decimal GetFullPrice(
                                    IEnumerable<string> destinations,
                                    IEnumerable<string> clients,
                                    IEnumerable<int> infantsIds,
                                    IEnumerable<int> childrenIds,
                                    IEnumerable<decimal> prices,
                                    IEnumerable<string> currencies)
        {
            decimal fullPrice = default;

            if (!(destinations.Count() == clients.Count() && destinations.Count() == prices.Count() && destinations.Count() == currencies.Count()))
            {
                Console.WriteLine("Incorect input");
                return fullPrice;
            }

            for (int i = 0; i < destinations.Count(); i++)
            {
                var discountPrice = prices.ElementAt(i);

                if (currencies.ElementAt(i) == "EUR")
                {
                    discountPrice *= 1.19m;
                }
                if (Regex.IsMatch(destinations.ElementAt(i), "Wayne Street"))
                {
                    discountPrice += 10;
                }
                if (Regex.IsMatch(destinations.ElementAt(i), "North Heather Street"))
                {
                    discountPrice -= 5.36m;
                }
                foreach (var item in infantsIds)
                {
                    if (i == item)
                    {
                        discountPrice -= discountPrice / 2;
                    }
                }
                foreach (var item in childrenIds)
                {
                    if (i == item)
                    {
                        discountPrice -= discountPrice / 4;
                    }
                }
                if (i != 0 && i < destinations.Count())
                {
                    if (destinations.ElementAt(i).Remove(0, destinations.ElementAt(i).IndexOf(' ') + 1) == destinations.ElementAt(i - 1).Remove(0, destinations.ElementAt(i - 1).IndexOf(' ') + 1))
                    {
                        discountPrice -= discountPrice * 15 / 100;
                    }
                }

                fullPrice += discountPrice;
            }
            return fullPrice;
        }

        public decimal InvokePriceCalculatiion()
        {
            var destinations = new[]
            {
                "949 Fairfield Court, Madison Heights, MI 48071",
                "367 Wayne Street, Hendersonville, NC 28792",
                "910 North Heather Street, Cocoa, FL 32927",
                "911 North Heather Street, Cocoa, FL 32927",
                "706 Tarkiln Hill Ave, Middleburg, FL 32068",
            };

            var clients = new[]
            {
                "Autumn Baldwin",
                "Jorge Hoffman",
                "Amiah Simmons",
                "Sariah Bennett",
                "Xavier Bowers",
            };

            var infantsIds = new[] { 2 };
            var childrenIds = new[] { 3, 4 };

            var prices = new[] { 100, 25.23m, 58, 23.12m, 125 };
            var currencies = new[] { "USD", "USD", "EUR", "USD", "USD" };

            return GetFullPrice(destinations, clients, infantsIds, childrenIds, prices, currencies);
        }
    }
}