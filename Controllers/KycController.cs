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
    [Route("kycportal")]
    public class KycController : ControllerBase
    {
        private readonly IUsersRepository repository;

        public KycController(IUsersRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult> KycVerificationAsync(CreatedUserDto userDto)
        {
            var kycVerified = await repository.KycVerificationAsync(userDto);

            if (kycVerified == false)
            {
                return StatusCode(200, "KYC Unverified");
            }
            return Ok("KYC Verified");

        }
    }
}
