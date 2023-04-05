using ShopsRU.Application.DTOs;
using ShopsRU.Application.Features.Commands;

namespace ShopsRU.Application.CommonMethods;

public static class DiscountCalculator
{
    public static async Task<decimal> CalculateDiscount(decimal amount)
    {
        if (amount >= 100)
        {
            decimal discount = 0;
            
            discount += Math.Floor(amount / 100) * 5m;

            return amount - discount;
        }

        return amount;
    }
}