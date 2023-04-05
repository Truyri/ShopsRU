using ShopRU.Domain.Enums;
using ShopsRU.Application.CommonMethods;
using ShopsRU.Application.Constants;
using ShopsRU.Application.DTOs;
using ShopsRU.Domain.Common;

namespace ShopsRU.Application.Services;

public class AffiliateAmountCalculation : UserSelector
{
    protected override bool IsSuitable(UserTypes type) => type == UserTypes.Affiliate;

    public override async Task<InvoiceDto> CalculationAmount(CalculationParameters model)
    {
        model.Amount = DiscountCalculator.CalculateDiscount(model.Amount).Result;
        
        return new InvoiceDto() { TotalAmount = model.Amount -(model.Amount * DiscountRates.AffiliateRate), InvoiceNumber = Guid.NewGuid()};  
    }

    public AffiliateAmountCalculation(UserSelectorParameters parameters) : base(parameters)
    {
    }
}