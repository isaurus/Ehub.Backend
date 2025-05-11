using eHub.Backend.Domain.Models;
using Swashbuckle.AspNetCore.Filters;

namespace eHub.Backend.WebApi.Controllers.Swagger
{
    public class UserModelExample : IExamplesProvider<UserModel>
    {
        public UserModel GetExamples()
        {
            return new UserModel
            {
                FirstName = "Isaac",
                LastName = "Martín",
                Email = "isaacmartin.dev@example.es",
                BirtDate = new DateOnly(1995, 2, 28)
                // Password
            };
        }
    }
}
