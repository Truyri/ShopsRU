using ShopRU.Domain.Enums;
using ShopsRU.Application.Interfaces;
using ShopsRU.Domain.Common;
using ShopsRU.Domain.Entities;

namespace ShopsRU.Application.Services;

public class UserFinder : IUserFinder

{
    private readonly IUserRepositoryAsync<UserEntity> _userRepository;

    public UserFinder(IUserRepositoryAsync<UserEntity> userRepository)
    {
        _userRepository = userRepository;
    }

    public UserTypes GetOperationTypes(CalculationParameters parameters)
    {
        UserEntity user = _userRepository.GetById(parameters.UserId).Result;
        
        if (user.UserType == UserTypes.Affiliate)
        {
            return UserTypes.Affiliate;
        }
        if (user.UserType == UserTypes.Customer)
        {
            return UserTypes.Customer;
        }
        if (user.UserType == UserTypes.Employee)
        {
            return UserTypes.Employee;
        }
        
        return UserTypes.None;
    }
}