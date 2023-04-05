using MediatR;
using ShopRU.Domain.Enums;
using ShopsRU.Application.DTOs;
using ShopsRU.Application.Interfaces;
using ShopsRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopsRU.Application.CommonMethods;
using ShopsRU.Application.Services;
using ShopsRU.Domain.Common;

namespace ShopsRU.Application.Features.Commands
{
    public class ProductBuyCommand : IRequest<InvoiceDto>
    {
        public Guid UserId { get; set; }
        public bool IsGrocery { get; set; }
        public decimal Amount { get; set; }

        public class ProductBuyCommandHandler : IRequestHandler<ProductBuyCommand, InvoiceDto>
        {
            private readonly IUserFinder _userFinder;

            public ProductBuyCommandHandler(IUserFinder userFinder)
            {
                _userFinder = userFinder;
            }

            public async Task<InvoiceDto> Handle(ProductBuyCommand request, CancellationToken cancellationToken)
            {
                InvoiceDto invoice;
                try
                {
                    if (request.IsGrocery)
                    {
                        invoice = new InvoiceDto
                        {
                            InvoiceNumber = Guid.NewGuid(),
                            TotalAmount = await DiscountCalculator.CalculateDiscount(request.Amount)
                        };
                        
                        return invoice;
                    }

                    var model = new CalculationParameters() { Amount = request.Amount, UserId = request.UserId  };
                    
                    invoice = (await UserSelector.GetUserChanger(new UserSelectorParameters { CalculationParameters = model, UserFinder = _userFinder}).CalculationAmount(model));
                    
                    return invoice;
                }
                catch (Exception e)
                {
                    throw new Exception("Error: " + e.Message);
                }
            }
        }
    }
}