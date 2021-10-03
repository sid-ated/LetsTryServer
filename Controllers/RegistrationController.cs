using LetsTry.Dtos;
using LetsTry.Entities;
using LetsTry.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsTry.Controllers
{
    [ApiController]
    [Route("register")]
    public class RegistrationController : ControllerBase
    {
        private readonly IUsersRepository repository;

        public RegistrationController(IUsersRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUserAsync(CreatedUserDto user)
        {
            var existingUser = await repository.GetExactUserAsync(user);

            if (existingUser is not null)
            {
                return StatusCode(409, $"User {user.FirstName} already exists.");
            }

            var kycVerified = await repository.KycVerificationAsync(user);

            if(kycVerified == false)
            {
                return StatusCode(406, $"KYC could not be done for user {user.FirstName}.");
            }

            await repository.CreateUserAsync(user);

            var newUser = await repository.GetExactUserAsync(user);

            return RedirectToAction("GetUserAsync", "Users", new { id = newUser.Id });
        }
    }
}
