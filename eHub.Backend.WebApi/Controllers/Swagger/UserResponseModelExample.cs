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
                FirstName = "Isaac",
                LastName = "Martín",
                Email = "isaacmartin.dev@example.es",
                BirthDate = "28/02/1995"
                // Password
            };
        }
    }
}
