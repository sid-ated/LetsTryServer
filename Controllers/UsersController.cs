using LetsTry.Entities;
using LetsTry.Repositories;
using LetsTry.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsTry.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository repository;

        public UsersController(IUsersRepository repository)
        {
            this.repository = repository;
        }


        [HttpGet("{id}/view")]
        public async Task<ActionResult<UserDto>> GetUserAsync(Guid id)
        {
            var user = await repository.GetUserAsync(id);
            if(user is null)
            {
                return NotFound();
            }
            return Ok(user.AsDto());
        }

        [HttpGet("{firstName}%{lastName}/query")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersByNameAsync(string firstName, string lastName)
        {
            var users = await repository.GetUsersByNameAsync(firstName, lastName);
            if (users.Count()==0)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = (await repository.GetUsersAsync())
                        .Select(user => user.AsDto());
            return users;
        }


        /*[HttpPut("{id}/update")]
        public async Task<ActionResult> UpdateUserAsync(Guid id, UpdateUserDto UserDto)
        {
            var existingUser = await repository.GetUserAsync(id);

            if(existingUser is null)
            {
                return NotFound();
            }

            User updatedUser = existingUser with
            {
                FirstName = UserDto.FirstName,
                LastName = UserDto.LastName,
                DateOfBirth = UserDto.DateOfBirth,
                PlaceOfBirth = UserDto.PlaceOfBirth,
                MobileNumber = UserDto.MobileNumber,
                EmailId = UserDto.EmailId
            };

            await repository .UpdateUserAsync(updatedUser);

            return NoContent();
        }*/

        /*[HttpDelete("{id}/delete")]
        public async Task<ActionResult> DeleteUserAsync(Guid id)
        {
            var existingUser = await repository.GetUserAsync(id);

            if (existingUser is null)
            {
                return NotFound();
            }

            await repository .DeleteUserAsync(id);

            return NoContent();
        }*/
    }
}
