using System;
using System.Collections.Generic;
using BookStore.Enums;
using BookStore.Models;

namespace BookStore.Helpers
{
    public class DeliveryCostCalculator
    {
        public static IEnumerable<BookDeliveryOption> GetCosts(DateTime date)
        {
            return new List<BookDeliveryOption>
            {
                new BookDeliveryOption
                {
                    Type = DeliveryType.Motorbike,
                    Cost = CalculateCost(DeliveryType.Motorbike, date)
                },
                new BookDeliveryOption
                {
                    Type = DeliveryType.Train,
                    Cost = CalculateCost(DeliveryType.Train, date)
                },
                new BookDeliveryOption
                {
                    Type = DeliveryType.Aircraft,
                    Cost = CalculateCost(DeliveryType.Aircraft, date)
                }
            };
        }

        public static decimal GetCost(DeliveryType type, DateTime orderDate)
        {
            return CalculateCost(type, DateTime.Now);
        }

        static readonly Dictionary<DeliveryType, decimal> baseCosts = new Dictionary<DeliveryType, decimal>
        {
            { DeliveryType.Motorbike, 5},
            { DeliveryType.Train, 10 },
            { DeliveryType.Aircraft, 20 }
        };

        static readonly Dictionary<DeliveryType, decimal> septemberFactors = new Dictionary<DeliveryType, decimal>
        {
            { DeliveryType.Motorbike, 1.5m},
            { DeliveryType.Train, 1.8m },
            { DeliveryType.Aircraft, 2 }
        };

        static readonly Dictionary<DeliveryType, decimal> junToAugFactors = new Dictionary<DeliveryType, decimal>
        {
            { DeliveryType.Motorbike, 0.5m},
            { DeliveryType.Train, 0.8m },
            { DeliveryType.Aircraft, 0.8m }
        };


        private static decimal CalculateCost(DeliveryType type, DateTime date)
        {
            return GetBaseCost(type) * GetFactor(type, date);
        }

        private static decimal GetFactor(DeliveryType type, in DateTime date)
        {
            int month = date.Month;
            if (month == 9)
            {
                return septemberFactors[type];
            }
            else if (month >= 6 && month <= 8)
            {
                return junToAugFactors[type];
            }
            else
            {
                return 1;
            }
        }

        private static decimal GetBaseCost(DeliveryType type)
        {
            return baseCosts[type];
        }
    }
}
