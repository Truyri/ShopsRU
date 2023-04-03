using MediatR;
using ShopRU.Domain.Enums;
using ShopsRU.Application.DTOs;
using ShopsRU.Application.Interfaces;
using ShopsRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Features.Commands
{
    public class ProductBuyCommand : IRequest<InvoiceDto>
    {
        public Guid UserId { get; set; }
        public bool IsGrocery { get; set; }
        public decimal Amount { get; set; }

        public class ProductBuyCommandHandler : IRequestHandler<ProductBuyCommand, InvoiceDto>
        {
            private readonly IUserRepositoryAsync<UserEntity> _userRepository;

            public ProductBuyCommandHandler(IUserRepositoryAsync<UserEntity> userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<InvoiceDto> Handle(ProductBuyCommand request, CancellationToken cancellationToken)
            {
                var uer = await _userRepository.GetAllAsync();
                UserEntity? user = await _userRepository.GetById(request.UserId);
                decimal percentage = await CalculatePercentage(user);
                var discount = CalculateDiscount(request.Amount, request.IsGrocery, percentage);


                var invoice = new InvoiceDto
                {
                    InvoiceNumber = Guid.NewGuid(),
                    TotalAmount = request.Amount - discount.Result,
                    DiscountAmount = discount.Result
                };


                return invoice;
            }
        }
        private static async Task<decimal> CalculateDiscount(decimal amount,bool isGrocery,decimal rate)
        {
            decimal discount = 0;

            if (!isGrocery)
            {
               discount = amount * rate;
              
               discount += Math.Floor(amount / 100) * 5m; // $5 discount for every $100 spent
            }

            return discount;
        }
        private static async Task<decimal> CalculatePercentage(UserEntity user)
        {
            decimal rate = 0;

            if (user.UserType == UserTypes.Employee)
            {
                rate = 0.3m;
            }
            else if (user.UserType == UserTypes.Affiliate)
            {
                rate = 0.1m;
            }
            else if (user.UserType == UserTypes.Customer && (DateTime.Now - user.CreatedDate).TotalDays > 365 * 2)
            {
                rate = 0.05m;
            }

            return rate;
        }
    }
}
