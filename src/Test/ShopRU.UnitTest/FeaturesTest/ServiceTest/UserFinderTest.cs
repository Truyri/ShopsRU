using ShopRU.Domain.Enums;
using ShopsRU.Application.DTOs;
using ShopsRU.Application.Features.Commands;
using ShopsRU.Application.Interfaces;
using ShopsRU.Application.Services;
using ShopsRU.Domain.Common;
using ShopsRU.Domain.Entities;

namespace UnitTest.FeaturesTest.ServiceTest;

public class UserFinderTest
{
    private UserFinder _userFinder;
    private readonly Mock<IUserRepositoryAsync<UserEntity>> _userRepositorAsyncMock;
 
    
    public UserFinderTest()
    {
        _userRepositorAsyncMock = new Mock<IUserRepositoryAsync<UserEntity>>();
    }
    
    [Fact]
    public async Task Handle_WhenNotIsGrocery_ReturnsInvoiceDtoWithAmount_GetOperationType_ForCustomer()
    {
        _userFinder = new UserFinder(_userRepositorAsyncMock.Object);
        
        var calculationParameters = new CalculationParameters
        {
            UserId = Guid.NewGuid(),
            Amount = 80
        };
        var user = new UserEntity
        {
            Id = Guid.Parse("b34d5b8f-9a68-4b2a-b437-648c8d7341bd"),
            FirstName = "Marc",
            LastName = "Raiden",
            UserType = UserTypes.Customer,
        };
        
        _userRepositorAsyncMock.Setup(uf => uf.GetById(It.IsAny<Guid>())).Returns(Task.FromResult(user));
     
        var result = _userFinder.GetOperationTypes(calculationParameters);

        Assert.True(result == UserTypes.Customer);
    }    
    [Fact]
    public async Task Handle_WhenNotIsGrocery_ReturnsInvoiceDtoWithAmount_GetOperationType_ForEmployee()
    {
        _userFinder = new UserFinder(_userRepositorAsyncMock.Object);
        
        var calculationParameters = new CalculationParameters
        {
            UserId = Guid.NewGuid(),
            Amount = 80
        };
        var user = new UserEntity
        {
            Id = Guid.Parse("b34d5b8f-9a68-4b2a-b437-648c8d7341bd"),
            FirstName = "Marc",
            LastName = "Raiden",
            UserType = UserTypes.Employee,
        };
        
        _userRepositorAsyncMock.Setup(uf => uf.GetById(It.IsAny<Guid>())).Returns(Task.FromResult(user));
     
        var result = _userFinder.GetOperationTypes(calculationParameters);

        Assert.True(result == UserTypes.Employee);
    }    
    [Fact]
    public async Task Handle_WhenNotIsGrocery_ReturnsInvoiceDtoWithAmount_GetOperationType_ForAffiliate()
    {
        _userFinder = new UserFinder(_userRepositorAsyncMock.Object);
        
        var calculationParameters = new CalculationParameters
        {
            UserId = Guid.NewGuid(),
            Amount = 80
        };
        var user = new UserEntity
        {
            Id = Guid.Parse("b34d5b8f-9a68-4b2a-b437-648c8d7341bd"),
            FirstName = "Marc",
            LastName = "Raiden",
            UserType = UserTypes.Affiliate,
        };
        
        _userRepositorAsyncMock.Setup(uf => uf.GetById(It.IsAny<Guid>())).Returns(Task.FromResult(user));
     
        var result = _userFinder.GetOperationTypes(calculationParameters);

        Assert.True(result == UserTypes.Affiliate);
    }    
    [Fact]
    public async Task Handle_WhenNotIsGrocery_ReturnsInvoiceDtoWithAmount_GetOperationType_ForNone()
    {
        _userFinder = new UserFinder(_userRepositorAsyncMock.Object);
        
        var calculationParameters = new CalculationParameters
        {
            UserId = Guid.NewGuid(),
            Amount = 80
        };
        var user = new UserEntity
        {
            Id = Guid.Parse("b34d5b8f-9a68-4b2a-b437-648c8d7341bd"),
            FirstName = "Marc",
            LastName = "Raiden",
            UserType = UserTypes.None,
        };
        
        _userRepositorAsyncMock.Setup(uf => uf.GetById(It.IsAny<Guid>())).Returns(Task.FromResult(user));
     
        var result = _userFinder.GetOperationTypes(calculationParameters);

        Assert.True(result == UserTypes.None);
    }    
    
}