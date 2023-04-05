using ShopRU.Domain.Enums;

namespace ShopsRU.Domain.Common;

public class UserSelectorParameters
{
   public CalculationParameters CalculationParameters { get; set; }
    public IUserFinder UserFinder { get; set; }
    
}

public interface IUserFinder
{
    UserTypes GetOperationTypes(CalculationParameters parameters);
}

public class CalculationParameters
{
    public decimal Amount { get; set; }
    public Guid UserId { get; set; }
}