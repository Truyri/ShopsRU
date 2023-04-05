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
using ShopRU.Persistence.EntitySeeders;
using ShopsRU.Application.Services;
using ShopsRU.Domain.Common;
using static ShopsRU.Application.Features.Commands.ProductBuyCommand;

namespace ShopRU.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection)
        {

            DatabaseInitiliazer();
            serviceCollection.AddTransient<IUserRepositoryAsync<UserEntity>, UserRepository<UserEntity>>();
            serviceCollection.AddTransient<IUserFinder, UserFinder>();
            serviceCollection.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepository<>));
            serviceCollection.AddScoped<IRequestHandler<ProductBuyCommand, InvoiceDto>, ProductBuyCommandHandler>();
        }

        private static void DatabaseInitiliazer()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "ShopRUAppDbConnection")
                .Options;
            
            var context = new ApplicationDbContext(options);
            UserSeeds.SeedAsync(context);
        }
    }
}
