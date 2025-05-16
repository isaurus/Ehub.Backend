using eHub.Backend.Domain.Enums;
using eHub.Backend.Domain.Models;
using Swashbuckle.AspNetCore.Filters;

namespace eHub.Backend.WebApi.Controllers.Swagger
{
    public class UserResponseModelExample : IExamplesProvider<UserResponseModel>
    {
        public UserResponseModel GetExamples()
        {
            return new UserResponseModel
            {
                Email = "isaacmartin.dev@example.es",
                PasswordHash = "",
                ProfilePicUrl = "https://www.flaticon.com/free-icon-font/user_3917688?related_id=3917688",
                FirstName = "Isaac",
                LastName = "Martín",
                BirthDate = "28/02/1995",
                Country = "Spain",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
        }
    }
}
