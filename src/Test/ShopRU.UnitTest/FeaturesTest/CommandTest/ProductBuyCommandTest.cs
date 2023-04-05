using ShopRU.Domain.Enums;
using ShopsRU.Application.CommonMethods;
using ShopsRU.Application.DTOs;
using ShopsRU.Application.Features.Commands;
using ShopsRU.Application.Interfaces;
using ShopsRU.Application.Services;
using ShopsRU.Domain.Common;
using ShopsRU.Domain.Entities;

namespace ShopsRU.UnitTest.FeaturesTest.CommandTest;

public class ProductBuyCommandTest
{
    private readonly Mock<IUserFinder> _userFinderMock;
    private ProductBuyCommand.ProductBuyCommandHandler _handler;
    
    public ProductBuyCommandTest()
    {
        _userFinderMock = new Mock<IUserFinder>();
    }
    
    [Fact]
    public async Task Handle_WhenIsGrocery_ReturnsInvoiceDtoWithDiscountedAmount()
    {

        _handler = new ProductBuyCommand.ProductBuyCommandHandler(_userFinderMock.Object);
        var command = new ProductBuyCommand
        {
            IsGrocery = true,
            Amount = 100
        };
        var expectedInvoice = new InvoiceDto
        {
            InvoiceNumber = Guid.NewGuid(),
            TotalAmount = 95 
        };

        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(expectedInvoice.TotalAmount, result.TotalAmount);
    }
    [Fact]
    public async Task Handle_WhenNotIsGrocery_ReturnsInvoiceDtoWithAmount_ForAffiliate()
    {
        _handler = new ProductBuyCommand.ProductBuyCommandHandler(_userFinderMock.Object);

        var command = new ProductBuyCommand
        {
            IsGrocery = false,
            UserId = Guid.NewGuid(),
            Amount = 100
        };
        var userTypes = UserTypes.Affiliate;
        var expectedInvoice = new InvoiceDto
        {
            InvoiceNumber = Guid.NewGuid(),
            TotalAmount = 85.5M 
        };
        _userFinderMock.Setup(uf => uf.GetOperationTypes(It.IsAny<CalculationParameters>())).Returns(userTypes);
     
        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.Equal(expectedInvoice.TotalAmount, result.TotalAmount);
        Assert.True(result.Succeeded);
        _userFinderMock.Verify(uf => uf.GetOperationTypes(It.IsAny<CalculationParameters>()), Times.Once);
    }
    [Fact]
    public async Task Handle_WhenNotIsGrocery_ReturnsInvoiceDtoWithAmount_ForEmployee()
    {
        _handler = new ProductBuyCommand.ProductBuyCommandHandler(_userFinderMock.Object);

        var command = new ProductBuyCommand
        {
            IsGrocery = false,
            UserId = Guid.NewGuid(),
            Amount = 100
        };
        var userTypes = UserTypes.Employee;
        var expectedInvoice = new InvoiceDto
        {
            InvoiceNumber = Guid.NewGuid(),
            TotalAmount = 66.5M 
        };
        _userFinderMock.Setup(uf => uf.GetOperationTypes(It.IsAny<CalculationParameters>())).Returns(userTypes);
     
        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.Equal(expectedInvoice.TotalAmount, result.TotalAmount);
        Assert.True(result.Succeeded);
        _userFinderMock.Verify(uf => uf.GetOperationTypes(It.IsAny<CalculationParameters>()), Times.Once);
    }    
    [Fact]
    public async Task Handle_WhenNotIsGrocery_ReturnsInvoiceDtoWithAmount_ForCustomer()
    {
        _handler = new ProductBuyCommand.ProductBuyCommandHandler(_userFinderMock.Object);

        var command = new ProductBuyCommand
        {
            IsGrocery = false,
            UserId = Guid.NewGuid(),
            Amount = 100
        };
        var userTypes = UserTypes.Customer;
        var expectedInvoice = new InvoiceDto
        {
            InvoiceNumber = Guid.NewGuid(),
            TotalAmount = 90.25M 
        };
        _userFinderMock.Setup(uf => uf.GetOperationTypes(It.IsAny<CalculationParameters>())).Returns(userTypes);
     
        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.Equal(expectedInvoice.TotalAmount, result.TotalAmount);
        Assert.True(result.Succeeded);
        _userFinderMock.Verify(uf => uf.GetOperationTypes(It.IsAny<CalculationParameters>()), Times.Once);
    }    
    [Fact]
    public async Task Handle_WhenNotIsGrocery_ReturnsInvoiceDtoWithAmount_LessThanOneHundred_ForCustomer()
    {
        _handler = new ProductBuyCommand.ProductBuyCommandHandler(_userFinderMock.Object);

        var command = new ProductBuyCommand
        {
            IsGrocery = false,
            UserId = Guid.NewGuid(),
            Amount = 80
        };
        var userTypes = UserTypes.Customer;
        var expectedInvoice = new InvoiceDto
        {
            InvoiceNumber = Guid.NewGuid(),
            TotalAmount = 76 
        };
        _userFinderMock.Setup(uf => uf.GetOperationTypes(It.IsAny<CalculationParameters>())).Returns(userTypes);
     
        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.Equal(expectedInvoice.TotalAmount, result.TotalAmount);
        Assert.True(result.Succeeded);
        _userFinderMock.Verify(uf => uf.GetOperationTypes(It.IsAny<CalculationParameters>()), Times.Once);
    }    
    [Fact]
    public async Task Handle_WhenNotIsGrocery_ReturnsInvoiceDtoWithAmount_GetOperationType_Exception()
    {
        _handler = new ProductBuyCommand.ProductBuyCommandHandler(_userFinderMock.Object);

        var command = new ProductBuyCommand
        {
            IsGrocery = false,
            UserId = Guid.NewGuid(),
            Amount = 80
        };
        var userTypes = UserTypes.Customer;
        
        var exception  = await Assert.ThrowsAsync<Exception>(async () => await _handler.Handle(command, CancellationToken.None));

        Assert.Equal("Error: System can not found any user type for given operation type. Type: None",exception.Message);
    }
}