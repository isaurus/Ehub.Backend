using System.Diagnostics.CodeAnalysis;
using eHub.Backend.Domain.Models;
using Swashbuckle.AspNetCore.Filters;

namespace eHub.Backend.WebApi.Controllers.Swagger
{
    [ExcludeFromCodeCoverage]
    public class RegisterUserModelExample : IExamplesProvider<RegisterUserModel>
    {
        public RegisterUserModel GetExamples()
        {
            return new RegisterUserModel
            {
                Email = "JohnDoe@example.com",
                Password = ""
            };
        }
    }
}
