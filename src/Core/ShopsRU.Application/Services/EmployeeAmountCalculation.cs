using ShopRU.Domain.Enums;
using ShopsRU.Application.CommonMethods;
using ShopsRU.Application.Constants;
using ShopsRU.Application.DTOs;
using ShopsRU.Domain.Common;

namespace ShopsRU.Application.Services;

public class EmployeeAmountCalculation : UserSelector
{
    protected override bool IsSuitable(UserTypes type) => type == UserTypes.Employee;

    public EmployeeAmountCalculation(UserSelectorParameters parameters) : base(parameters)
    {
        
    }
    public override async Task<InvoiceDto> CalculationAmount(CalculationParameters model)
    {
        model.Amount = DiscountCalculator.CalculateDiscount(model.Amount).Result;
        
        return new InvoiceDto() { TotalAmount = model.Amount - (model.Amount * DiscountRates.EmployeeRate), InvoiceNumber = Guid.NewGuid()} ;
    }
}