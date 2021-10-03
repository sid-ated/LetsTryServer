using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LetsTry.Dtos
{
    public class CreatedUserDto
    {
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string FirstName { get; init; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string LastName { get; init; }

        [Required]
        public DateTimeOffset DateOfBirth { get; init; }

        [Required]
        [StringLength(10)]
        public string MobileNumber { get; set; }

        [Required]
        [StringLength(maximumLength: 255, MinimumLength = 5)]
        public string PlaceOfBirth { get; set; }

        [Required]
        public string EmailId { get; set; }
    }
}
