﻿using Padrrif.Dto;

namespace Padrrif;

public interface IAuthUnitOfWork
{
    Task RegisterAsFarmer(User user);
    Task<TokenDto> RegisterAsEmpolyee(User user);
    Task<UserLoginDto?> Login(LoginDto loginDto);
    Task<User> MapFromUserRegistrationDtoToUser(EmployeeRegDto dto);
    Task<User> MapFromFarmerRegDtoToUser(FarmerRegDto dto);

}
