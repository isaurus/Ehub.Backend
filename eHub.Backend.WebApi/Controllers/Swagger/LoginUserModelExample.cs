using eHub.Backend.Domain.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Diagnostics.CodeAnalysis;

namespace eHub.Backend.WebApi.Controllers.Swagger
{
    [ExcludeFromCodeCoverage]
    public class LoginUserModelExample : IExamplesProvider<LoginUserModel>
    {
        public LoginUserModel GetExamples()
        {
            return new LoginUserModel
            {
                Email = "JohnDoe@example.com",
                Password = "123456789"
            };
        }
    }
}
