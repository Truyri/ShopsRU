using ShopRU.Domain.Enums;
using ShopsRU.Application.DTOs;
using ShopsRU.Application.Extensions;
using ShopsRU.Application.Interfaces;
using ShopsRU.Domain.Common;

namespace ShopsRU.Application.Services;

public abstract class UserSelector : IDisposable
{
    private readonly UserSelectorParameters _parameters;

    public UserSelector(UserSelectorParameters parameters)
    {
        _parameters = parameters;
    }

    public static UserSelector GetUserChanger(UserSelectorParameters parameters)
    {
        var instance = GetSuitableInstance(typeof(UserSelector).FindSubClasses(), parameters);
        return instance;
    }
    private static UserSelector GetSuitableInstance(IEnumerable<Type> types , UserSelectorParameters parameters)
    {
        var type = parameters.UserFinder.GetOperationTypes(parameters.CalculationParameters);

        foreach (var @class in types)
        {
            try
            {
                var instance = Activator.CreateInstance(@class, new object[] { parameters }) as UserSelector;
                var isSuitable = instance.IsSuitable(type);

                if (isSuitable != true)
                {
                    instance.Dispose();
                    continue;
                }

                return instance;
            }
            catch (System.Exception ex)
            {
                throw new Exception("Error: " + ex);
            }
        }

        throw new NotImplementedException("System can not found any user type for given operation type. Type: " + type.ToString());
    }
    protected abstract bool IsSuitable(UserTypes type);
    
    public abstract Task<InvoiceDto> CalculationAmount(CalculationParameters model);
    
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}