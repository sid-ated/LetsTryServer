using LetsTry.Dtos;
using LetsTry.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LetsTry.Repositories
{
    public interface IUsersRepository
    {
        Task<User> GetUserAsync(Guid id);

        Task<IEnumerable<User>> GetUsersAsync();

        Task<IEnumerable<User>> GetUsersByNameAsync(string firstName, string lastName);

        Task<User> GetExactUserAsync(CreatedUserDto user);

        Task CreateUserAsync(CreatedUserDto UserDto);

        Task UpdateUserAsync(User user);

        Task DeleteUserAsync(Guid id);

        Task<Boolean> KycVerificationAsync(CreatedUserDto userDto);
    }
}