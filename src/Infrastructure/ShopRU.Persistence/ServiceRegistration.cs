using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopRU.Persistence.Context;
using ShopRU.Persistence.Repositories;
using ShopsRU.Application.DTOs;
using ShopsRU.Application.Features.Commands;
using ShopsRU.Application.Interfaces;
using ShopsRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShopsRU.Application.Features.Commands.ProductBuyCommand;

namespace ShopRU.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase("ShopRUAppDbConnection");
            });

            serviceCollection.AddTransient<IUserRepositoryAsync<UserEntity>, UserRepository<UserEntity>>();
            serviceCollection.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepository<>));
            serviceCollection.AddScoped<IRequestHandler<ProductBuyCommand, InvoiceDto>, ProductBuyCommandHandler>();
        }
    }
}
