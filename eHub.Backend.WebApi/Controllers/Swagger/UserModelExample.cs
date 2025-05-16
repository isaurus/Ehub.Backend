using System.Diagnostics.CodeAnalysis;
using eHub.Backend.Domain.Enums;
using eHub.Backend.Domain.Models;
using Swashbuckle.AspNetCore.Filters;

namespace eHub.Backend.WebApi.Controllers.Swagger
{
    [ExcludeFromCodeCoverage]
    public class UserModelExample : IExamplesProvider<UserModel>
    {
        public UserModel GetExamples()
        {
            return new UserModel
            {
                Id = 1,
                Email = "isaacmartin.dev@example.es",
                PasswordHash = "",
                ProfilePicUrl = "https://www.flaticon.com/free-icon-font/user_3917688?related_id=3917688",
                FirstName = "Isaac",
                LastName = "Martín",
                BirthDate = new DateOnly(1995, 2, 28),
                Country = (int)Country.Spain
            };
        }
    }
}
