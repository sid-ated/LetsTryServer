using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsTry.Entities
{
    public record User
    {
        public Guid Id { get; init; }

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public DateTimeOffset DateOfBirth { get; init; }

        public string MobileNumber { get; set; }

        public string PlaceOfBirth { get; set; }

        public string EmailId { get; set; }

        internal bool IsSatisfiedBy(User quser)
        {
            throw new NotImplementedException();
        }
    }
}
